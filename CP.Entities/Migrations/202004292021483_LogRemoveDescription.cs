namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogRemoveDescription : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Log", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Log", "Description", c => c.String(unicode: false, storeType: "text"));
        }
    }
}
