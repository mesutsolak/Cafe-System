namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPhoto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Photo", c => c.Binary());
            DropColumn("dbo.User", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Image", c => c.Binary());
            DropColumn("dbo.User", "Photo");
        }
    }
}
