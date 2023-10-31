namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EquipmentAndCategoryWithRealtions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        EquipmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ItemModel = c.String(),
                        SerialNumber = c.String(),
                        Description = c.String(),
                        EquipmentStatus = c.Boolean(nullable: false),
                        IsAssigned = c.Boolean(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EquipmentId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            AddColumn("dbo.Requests", "RequestStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "ApprovalStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "ApprovalStatus", c => c.Int(nullable: false));
            DropForeignKey("dbo.Equipments", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Equipments", new[] { "CategoryId" });
            DropColumn("dbo.Requests", "RequestStatus");
            DropTable("dbo.Equipments");
            DropTable("dbo.Categories");
        }
    }
}
