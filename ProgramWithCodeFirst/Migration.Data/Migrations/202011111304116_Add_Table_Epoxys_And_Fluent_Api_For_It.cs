namespace WoodWorkshop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Table_Epoxys_And_Fluent_Api_For_It : DbMigration
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
            
            CreateTable(
                "dbo.WoodFurnitureOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Date = c.String(nullable: false, maxLength: 20),
                        FurnitureTypeId = c.Int(nullable: false),
                        Color = c.String(nullable: false, maxLength: 20),
                        WoodTypeId = c.Int(nullable: false),
                        EpoxyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Epoxys", t => t.EpoxyId, cascadeDelete: true)
                .ForeignKey("dbo.FurnitureTypes", t => t.FurnitureTypeId, cascadeDelete: true)
                .ForeignKey("dbo.WoodTypes", t => t.WoodTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.FurnitureTypeId)
                .Index(t => t.WoodTypeId)
                .Index(t => t.EpoxyId);
            
            CreateTable(
                "dbo.Epoxys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false, maxLength: 30),
                        Price = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FurnitureTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        Size = c.String(nullable: false, maxLength: 20),
                        Varnish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                        BoardThickness = c.Single(nullable: false),
                        Price = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WoodFurnitureOrders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.WoodFurnitureOrders", "WoodTypeId", "dbo.WoodTypes");
            DropForeignKey("dbo.WoodFurnitureOrders", "FurnitureTypeId", "dbo.FurnitureTypes");
            DropForeignKey("dbo.WoodFurnitureOrders", "EpoxyId", "dbo.Epoxys");
            DropIndex("dbo.WoodFurnitureOrders", new[] { "EpoxyId" });
            DropIndex("dbo.WoodFurnitureOrders", new[] { "WoodTypeId" });
            DropIndex("dbo.WoodFurnitureOrders", new[] { "FurnitureTypeId" });
            DropIndex("dbo.WoodFurnitureOrders", new[] { "CustomerId" });
            DropTable("dbo.WoodTypes");
            DropTable("dbo.FurnitureTypes");
            DropTable("dbo.Epoxys");
            DropTable("dbo.WoodFurnitureOrders");
            DropTable("dbo.Customers");
        }
    }
}
