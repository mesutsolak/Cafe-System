namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CampaignAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Campaign", "IsShow", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Campaign", "IsShow");
        }
    }
}
