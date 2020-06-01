namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignProductTypeName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Campaign", "Image", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Campaign", "Image", c => c.String(maxLength: 250));
        }
    }
}
