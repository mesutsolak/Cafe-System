namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "Status");
        }
    }
}
