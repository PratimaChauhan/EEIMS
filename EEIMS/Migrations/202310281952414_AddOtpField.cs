namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOtpField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "OTP", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "OTP");
        }
    }
}
