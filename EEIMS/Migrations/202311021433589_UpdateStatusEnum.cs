namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateStatusEnum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Status", c => c.Int(nullable: false));
            DropColumn("dbo.Requests", "RequestStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "RequestStatus", c => c.String());
            DropColumn("dbo.Requests", "Status");
        }
    }
}
