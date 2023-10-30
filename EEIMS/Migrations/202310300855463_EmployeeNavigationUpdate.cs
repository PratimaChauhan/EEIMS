namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeNavigationUpdate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "Id");
            AddForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Id", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "Id" });
        }
    }
}
