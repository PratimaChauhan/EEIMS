namespace EEIMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateEquipment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Equipments", "EquipmentStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Equipments", "EquipmentStatus", c => c.Int(nullable: false));
        }
    }
}
