namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModel_NavigationWithEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        RequestDate = c.DateTime(nullable: false),
                        ApprovalStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Requests", new[] { "EmployeeId" });
            DropTable("dbo.Requests");
        }
    }
}
