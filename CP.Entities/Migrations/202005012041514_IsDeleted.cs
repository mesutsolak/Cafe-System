namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsDeleted", c => c.Boolean());
            DropColumn("dbo.User", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Status", c => c.Boolean());
            DropColumn("dbo.User", "IsDeleted");
        }
    }
}
