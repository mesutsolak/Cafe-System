namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductImage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Product", "Image", c => c.String(maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "Image");
        }
    }
}
