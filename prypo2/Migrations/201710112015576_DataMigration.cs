namespace prypo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateRegister", c => c.DateTime(nullable: false));
            AddColumn("dbo.AspNetUsers", "Adult", c => c.Boolean(nullable: false));
            AddColumn("dbo.AspNetUsers", "Horor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Horor");
            DropColumn("dbo.AspNetUsers", "Adult");
            DropColumn("dbo.AspNetUsers", "DateRegister");
        }
    }
}
