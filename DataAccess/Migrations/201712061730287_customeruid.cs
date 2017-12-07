namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customeruid : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "CustomerGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "CustomerGuid");
        }
    }
}
