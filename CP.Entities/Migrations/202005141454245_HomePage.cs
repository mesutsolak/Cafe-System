namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HomePage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HomePages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header1 = c.String(maxLength: 20),
                        Description = c.String(maxLength: 250),
                        Header2 = c.String(maxLength: 20),
                        Description2 = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);

            //    AddColumn("dbo.Slider", "Title", c => c.String(maxLength: 25));
            //    AlterColumn("dbo.Slider", "Description", c => c.String(maxLength: 75, unicode: false));
        }

        public override void Down()
        {
            //AlterColumn("dbo.Slider", "Description", c => c.String(maxLength: 500, unicode: false));
            //DropColumn("dbo.Slider", "Title");
            DropTable("dbo.HomePages");
        }
    }
}
