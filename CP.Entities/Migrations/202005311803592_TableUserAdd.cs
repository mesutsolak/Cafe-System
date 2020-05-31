namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUserAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Table", "User_Id", c => c.Int());
            CreateIndex("dbo.Table", "User_Id");
            AddForeignKey("dbo.Table", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Table", "User_Id", "dbo.User");
            DropIndex("dbo.Table", new[] { "User_Id" });
            DropColumn("dbo.Table", "User_Id");
        }
    }
}
