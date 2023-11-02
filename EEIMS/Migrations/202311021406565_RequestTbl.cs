namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestDate = c.DateTime(nullable: false),
                        RequestStatus = c.String(),
                        Comments = c.String(),
                        EmployeeId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.EmployeeId)
                .Index(t => t.CategoryId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Category_CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Requests", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Requests", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Requests", new[] { "Category_CategoryId" });
            DropIndex("dbo.Requests", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Requests", new[] { "CategoryId" });
            DropIndex("dbo.Requests", new[] { "EmployeeId" });
            DropTable("dbo.Requests");
        }
    }
}
