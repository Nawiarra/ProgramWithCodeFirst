namespace WoodWorkshop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Fluent_Api : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WoodFurnitureOrders", "FullName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WoodFurnitureOrders", "FullName", c => c.String());
        }
    }
}
