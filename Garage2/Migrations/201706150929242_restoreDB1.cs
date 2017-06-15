namespace Garage2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restoreDB1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ParkedVehicles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ParkedVehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
    }
}
