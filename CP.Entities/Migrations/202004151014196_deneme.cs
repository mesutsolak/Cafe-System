namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deneme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campaign",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false, storeType: "text"),
                        OldPrice = c.Int(),
                        NewPrice = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CampProduct",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CampaignId = c.Int(),
                        ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Campaign", t => t.CampaignId)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .Index(t => t.CampaignId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 75, unicode: false),
                        CategoryId = c.Int(),
                        ProductDetail = c.String(unicode: false, storeType: "text"),
                        Information = c.String(unicode: false, storeType: "text"),
                        Price = c.Int(),
                        Amount = c.Int(),
                        Views = c.Int(),
                        Rating = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, unicode: false),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150, unicode: false),
                        ImageId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Images", t => t.ImageId)
                .Index(t => t.ImageId);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        ProductId = c.Int(),
                        Description = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 150, unicode: false),
                        Email = c.String(maxLength: 150, unicode: false),
                        FirstName = c.String(maxLength: 150, unicode: false),
                        Password = c.String(),
                        LastName = c.String(maxLength: 150, unicode: false),
                        IsConfirm = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        TableId = c.Int(),
                        ProductId = c.Int(),
                        Amount = c.Int(),
                        TotalPrice = c.Int(),
                        IsComplete = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId)
                .ForeignKey("dbo.Table", t => t.TableId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.TableId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.OrderHistory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        OrderId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.OrderId);
            
            CreateTable(
                "dbo.Table",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyInformation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationGeneral = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 175, unicode: false),
                        ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationName = c.String(maxLength: 175, unicode: false),
                        ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phone = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        ContactId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contact", t => t.ContactId)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(unicode: false, storeType: "text"),
                        LogStatusId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogStatus", t => t.LogStatusId)
                .Index(t => t.LogStatusId);
            
            CreateTable(
                "dbo.LogStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 150, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MusicClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MusicName = c.String(unicode: false, storeType: "text"),
                        IsApproved = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MusicList",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MusicName = c.String(unicode: false, storeType: "text"),
                        Order = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Log", "LogStatusId", "dbo.LogStatus");
            DropForeignKey("dbo.Phones", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Locations", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Contact");
            DropForeignKey("dbo.Order", "UserId", "dbo.User");
            DropForeignKey("dbo.Order", "TableId", "dbo.Table");
            DropForeignKey("dbo.Order", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderHistory", "UserId", "dbo.User");
            DropForeignKey("dbo.OrderHistory", "OrderId", "dbo.Order");
            DropForeignKey("dbo.Comment", "UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Menu", "ImageId", "dbo.Images");
            DropForeignKey("dbo.Category", "ImageId", "dbo.Images");
            DropForeignKey("dbo.CampProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.CampProduct", "CampaignId", "dbo.Campaign");
            DropIndex("dbo.Log", new[] { "LogStatusId" });
            DropIndex("dbo.Phones", new[] { "ContactId" });
            DropIndex("dbo.Locations", new[] { "ContactId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.OrderHistory", new[] { "OrderId" });
            DropIndex("dbo.OrderHistory", new[] { "UserId" });
            DropIndex("dbo.Order", new[] { "ProductId" });
            DropIndex("dbo.Order", new[] { "TableId" });
            DropIndex("dbo.Order", new[] { "UserId" });
            DropIndex("dbo.Comment", new[] { "ProductId" });
            DropIndex("dbo.Comment", new[] { "UserId" });
            DropIndex("dbo.Menu", new[] { "ImageId" });
            DropIndex("dbo.Category", new[] { "ImageId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.CampProduct", new[] { "ProductId" });
            DropIndex("dbo.CampProduct", new[] { "CampaignId" });
            DropTable("dbo.MusicList");
            DropTable("dbo.MusicClaim");
            DropTable("dbo.LogStatus");
            DropTable("dbo.Log");
            DropTable("dbo.Phones");
            DropTable("dbo.Locations");
            DropTable("dbo.Emails");
            DropTable("dbo.Contact");
            DropTable("dbo.CompanyInformation");
            DropTable("dbo.Table");
            DropTable("dbo.OrderHistory");
            DropTable("dbo.Order");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
            DropTable("dbo.Menu");
            DropTable("dbo.Images");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.CampProduct");
            DropTable("dbo.Campaign");
        }
    }
}
