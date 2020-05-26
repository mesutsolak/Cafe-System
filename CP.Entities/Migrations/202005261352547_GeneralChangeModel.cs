namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralChangeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Generals", "Image", c => c.String(maxLength: 500));
            DropColumn("dbo.Generals", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Generals", "Picture", c => c.String(maxLength: 500));
            DropColumn("dbo.Generals", "Image");
        }
    }
}
