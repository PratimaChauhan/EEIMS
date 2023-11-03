namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableAttributesUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 100));
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
