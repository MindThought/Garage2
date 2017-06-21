namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Really : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "ActualType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "ActualType", c => c.Int(nullable: false));
        }
    }
}
