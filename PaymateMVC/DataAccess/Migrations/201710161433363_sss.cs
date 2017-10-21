namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sss : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("Models.Customer", "Gender_GenderId", "Lookup.Gender");
            DropIndex("Models.Customer", new[] { "Gender_GenderId" });
            RenameColumn(table: "Models.Customer", name: "Gender_GenderId", newName: "GenderId");
            AlterColumn("Models.Customer", "GenderId", c => c.Int(nullable: false));
            CreateIndex("Models.Customer", "GenderId");
            AddForeignKey("Models.Customer", "GenderId", "Lookup.Gender", "GenderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("Models.Customer", "GenderId", "Lookup.Gender");
            DropIndex("Models.Customer", new[] { "GenderId" });
            AlterColumn("Models.Customer", "GenderId", c => c.Int());
            RenameColumn(table: "Models.Customer", name: "GenderId", newName: "Gender_GenderId");
            CreateIndex("Models.Customer", "Gender_GenderId");
            AddForeignKey("Models.Customer", "Gender_GenderId", "Lookup.Gender", "GenderId");
        }
    }
}
