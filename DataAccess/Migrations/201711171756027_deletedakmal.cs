namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedakmal : DbMigration
    {
        public override void Up()
        {
            DropColumn("Models.Customer", "akmal");
        }
        
        public override void Down()
        {
            AddColumn("Models.Customer", "akmal", c => c.String());
        }
    }
}
