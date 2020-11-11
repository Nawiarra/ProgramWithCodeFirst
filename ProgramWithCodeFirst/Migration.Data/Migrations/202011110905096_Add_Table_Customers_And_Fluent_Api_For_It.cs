namespace WoodWorkshop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Customers_And_Fluent_Api_For_It : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        FullName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WoodFurnitureOrders", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.WoodFurnitureOrders", "CustomerId");
            AddForeignKey("dbo.WoodFurnitureOrders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.WoodFurnitureOrders", "PhoneNumber");
            DropColumn("dbo.WoodFurnitureOrders", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WoodFurnitureOrders", "FullName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.WoodFurnitureOrders", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
            DropForeignKey("dbo.WoodFurnitureOrders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.WoodFurnitureOrders", new[] { "CustomerId" });
            DropColumn("dbo.WoodFurnitureOrders", "CustomerId");
            DropTable("dbo.Customers");
        }
    }
}
