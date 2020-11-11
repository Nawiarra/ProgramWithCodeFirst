namespace WoodWorkshop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Test_Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Epoxys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WoodFurnitureOrders", "EpoxyId", c => c.Int(nullable: false));
            CreateIndex("dbo.WoodFurnitureOrders", "EpoxyId");
            AddForeignKey("dbo.WoodFurnitureOrders", "EpoxyId", "dbo.Epoxys", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WoodFurnitureOrders", "EpoxyId", "dbo.Epoxys");
            DropIndex("dbo.WoodFurnitureOrders", new[] { "EpoxyId" });
            DropColumn("dbo.WoodFurnitureOrders", "EpoxyId");
            DropTable("dbo.Epoxys");
        }
    }
}
