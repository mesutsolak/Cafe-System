namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryIsDeletedColumnAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "IsDeleted", c => c.Boolean(nullable: false));
         }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.Product", new[] { "CategoryId" });
            AlterColumn("dbo.Category", "Name", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Product", "Amount", c => c.Int());
            AlterColumn("dbo.Product", "Price", c => c.Int());
            AlterColumn("dbo.Product", "CategoryId", c => c.Int());
            DropColumn("dbo.Category", "IsDeleted");
            CreateIndex("dbo.Product", "CategoryId");
            AddForeignKey("dbo.Product", "CategoryId", "dbo.Category", "Id");
            RenameTable(name: "dbo.General", newName: "Generals");
        }
    }
}
