namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class araupdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(nullable: false, maxLength: 75, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Product", "Name", c => c.String(maxLength: 75, unicode: false));
        }
    }
}
