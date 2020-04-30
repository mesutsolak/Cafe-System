namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LogDataColumnAdd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Log", "Data", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Log", "Data", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
