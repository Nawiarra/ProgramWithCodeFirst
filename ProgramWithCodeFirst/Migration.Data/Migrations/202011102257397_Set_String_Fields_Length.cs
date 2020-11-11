namespace WoodWorkshop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_String_Fields_Length : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FurnitureTypes", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.FurnitureTypes", "Size", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.WoodFurnitureOrders", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.WoodFurnitureOrders", "Date", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.WoodFurnitureOrders", "Color", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.WoodTypes", "TypeName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.WoodTypes", "Price", c => c.String(nullable: false, maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WoodTypes", "Price", c => c.String());
            AlterColumn("dbo.WoodTypes", "TypeName", c => c.String());
            AlterColumn("dbo.WoodFurnitureOrders", "Color", c => c.String());
            AlterColumn("dbo.WoodFurnitureOrders", "Date", c => c.String());
            AlterColumn("dbo.WoodFurnitureOrders", "PhoneNumber", c => c.String());
            AlterColumn("dbo.FurnitureTypes", "Size", c => c.String());
            AlterColumn("dbo.FurnitureTypes", "Name", c => c.String());
        }
    }
}
