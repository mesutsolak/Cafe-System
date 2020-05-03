namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogTypeEdit : DbMigration
    {
        public override void Up()
        {
              AlterColumn("dbo.LogInfoes", "Type", c => c.String(maxLength: 150, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "ProductDetail", c => c.String(unicode: false, storeType: "text"));
        }
    }
}
