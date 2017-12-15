namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class profilepicurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "ProfilePicUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "ProfilePicUrl");
        }
    }
}
