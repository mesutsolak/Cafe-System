namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileAddColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "ProfileImage", c => c.Binary());
            AlterColumn("dbo.User", "Username", c => c.String(nullable: false, maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Username", c => c.String(maxLength: 150, unicode: false));
            DropColumn("dbo.User", "ProfileImage");
        }
    }
}
