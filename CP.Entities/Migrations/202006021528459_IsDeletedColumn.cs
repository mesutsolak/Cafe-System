namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Rate", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Table", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.UserRoles", "IsDeleted", c => c.Boolean());
            AddColumn("dbo.Roles", "IsDeleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Campaign", "Title", c => c.String(nullable: false, maxLength: 25, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campaign", "Title", c => c.String(maxLength: 25, unicode: false));
            DropColumn("dbo.Roles", "IsDeleted");
            DropColumn("dbo.UserRoles", "IsDeleted");
            DropColumn("dbo.Table", "IsDeleted");
            DropColumn("dbo.Rate", "IsDeleted");
            DropColumn("dbo.Comment", "IsDeleted");
        }
    }
}
