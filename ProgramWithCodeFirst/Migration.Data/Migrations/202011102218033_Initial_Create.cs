namespace WoodWorkshop.Data.Migrations
{
    using System;
    
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FurnitureTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.String(),
                        Varnish = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WoodFurnitureOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        FullName = c.String(),
                        Date = c.String(),
                        FurnitureTypeId = c.Int(nullable: false),
                        Color = c.String(),
                        WoodTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FurnitureTypes", t => t.FurnitureTypeId, cascadeDelete: true)
                .ForeignKey("dbo.WoodTypes", t => t.WoodTypeId, cascadeDelete: true)
                .Index(t => t.FurnitureTypeId)
                .Index(t => t.WoodTypeId);
            
            CreateTable(
                "dbo.WoodTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        BoardThickness = c.Single(nullable: false),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WoodFurnitureOrders", "WoodTypeId", "dbo.WoodTypes");
            DropForeignKey("dbo.WoodFurnitureOrders", "FurnitureTypeId", "dbo.FurnitureTypes");
            DropIndex("dbo.WoodFurnitureOrders", new[] { "WoodTypeId" });
            DropIndex("dbo.WoodFurnitureOrders", new[] { "FurnitureTypeId" });
            DropTable("dbo.WoodTypes");
            DropTable("dbo.WoodFurnitureOrders");
            DropTable("dbo.FurnitureTypes");
        }
    }
}
