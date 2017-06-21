namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Again : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ParkedVehicles", "ActualType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ParkedVehicles", "ActualType");
        }
    }
}
