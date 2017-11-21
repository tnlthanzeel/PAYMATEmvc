namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcolumnakmal : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "akmal", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "akmal");
        }
    }
}
