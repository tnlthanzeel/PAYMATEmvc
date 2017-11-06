namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dateofbirth_added : DbMigration
    {
        public override void Up()
        {
            AddColumn("Models.Customer", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("Models.Customer", "DateOfBirth");
        }
    }
}
