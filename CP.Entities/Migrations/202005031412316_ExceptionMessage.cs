namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExceptionMessage : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LogInfoes", "ExceptionMessage", c => c.String(maxLength: 500, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LogInfoes", "ExceptionMessage", c => c.String(maxLength: 150, unicode: false));
        }
    }
}
