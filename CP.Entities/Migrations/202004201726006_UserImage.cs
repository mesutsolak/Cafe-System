namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Image", c => c.Binary());
            DropColumn("dbo.User", "ProfileImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "ProfileImage", c => c.Binary());
            DropColumn("dbo.User", "Image");
        }
    }
}
