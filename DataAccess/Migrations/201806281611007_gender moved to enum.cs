namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gendermovedtoenum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Models.Customer", "GenderID", "Lookup.Gender");
            DropIndex("Models.Customer", new[] { "GenderID" });
            AddColumn("Models.Customer", "Gender", c => c.Int(nullable: false));
            DropColumn("Models.Customer", "GenderID");
            DropTable("Lookup.Gender");
        }
        
        public override void Down()
        {
            CreateTable(
                "Lookup.Gender",
                c => new
                    {
                        GenderId = c.Int(nullable: false, identity: true),
                        GenderType = c.String(),
                    })
                .PrimaryKey(t => t.GenderId);
            
            AddColumn("Models.Customer", "GenderID", c => c.Int(nullable: false));
            DropColumn("Models.Customer", "Gender");
            CreateIndex("Models.Customer", "GenderID");
            AddForeignKey("Models.Customer", "GenderID", "Lookup.Gender", "GenderId", cascadeDelete: true);
        }
    }
}
