namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirm_email_property_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "EmailConfirmed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "EmailConfirmed");
        }
    }
}
