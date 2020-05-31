namespace CP.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CartIsDeletedAdd : DbMigration
    {
        public override void Up()
        {

            AddColumn("dbo.Cart", "IsDeleted", c => c.Boolean());
            DropColumn("dbo.Cart", "IsDelete");
        }

        public override void Down()
        {
            AddColumn("dbo.Cart", "IsDelete", c => c.Boolean());
            DropColumn("dbo.Cart", "IsDeleted");
        }
    }
}
