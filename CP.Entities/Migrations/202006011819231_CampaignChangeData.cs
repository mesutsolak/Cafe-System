namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignChangeData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CampProduct", "CampaignId", "dbo.Campaign");
            DropForeignKey("dbo.CampProduct", "ProductId", "dbo.Product");
            DropIndex("dbo.CampProduct", new[] { "CampaignId" });
            DropIndex("dbo.CampProduct", new[] { "ProductId" });
            AddColumn("dbo.Campaign", "Title", c => c.String(maxLength: 25, unicode: false));
            AddColumn("dbo.Campaign", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Campaign", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Campaign", "Image", c => c.String(maxLength: 250));
            AddColumn("dbo.Campaign", "IsDeleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Campaign", "OldPrice");
            DropColumn("dbo.Campaign", "NewPrice");
            DropTable("dbo.CampProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CampProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(),
                        ProductId = c.Int(),
                        IsShow = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Campaign", "NewPrice", c => c.Int());
            AddColumn("dbo.Campaign", "OldPrice", c => c.Int());
            DropColumn("dbo.Campaign", "IsDeleted");
            DropColumn("dbo.Campaign", "Image");
            DropColumn("dbo.Campaign", "Amount");
            DropColumn("dbo.Campaign", "Price");
            DropColumn("dbo.Campaign", "Title");
            CreateIndex("dbo.CampProduct", "ProductId");
            CreateIndex("dbo.CampProduct", "CampaignId");
            AddForeignKey("dbo.CampProduct", "ProductId", "dbo.Product", "Id");
            AddForeignKey("dbo.CampProduct", "CampaignId", "dbo.Campaign", "Id");
        }
    }
}
