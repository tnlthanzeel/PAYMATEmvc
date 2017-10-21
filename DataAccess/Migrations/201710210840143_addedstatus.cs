namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "Status");
        }
    }
}
