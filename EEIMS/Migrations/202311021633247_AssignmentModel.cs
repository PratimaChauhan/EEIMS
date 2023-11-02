namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignmentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignId = c.Int(nullable: false, identity: true),
                        AssignDate = c.DateTime(nullable: false),
                        ExpectedReturnDate = c.DateTime(nullable: false),
                        ActualReturnDate = c.DateTime(nullable: false),
                        assignStatus = c.Int(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Employee_EmployeeId = c.Int(),
                        Equipment_EquipmentId = c.Int(),
                    })
                .PrimaryKey(t => t.AssignId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Equipments", t => t.Equipment_EquipmentId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.EmployeeId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Equipment_EquipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Assignments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Assignments", "Equipment_EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Assignments", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.Assignments", new[] { "Equipment_EquipmentId" });
            DropIndex("dbo.Assignments", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.Assignments", new[] { "EmployeeId" });
            DropIndex("dbo.Assignments", new[] { "EquipmentId" });
            DropTable("dbo.Assignments");
        }
    }
}
