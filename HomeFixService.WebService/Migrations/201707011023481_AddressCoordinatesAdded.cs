namespace HomeFixService.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressCoordinatesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddresses", "Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.UserAddresses", "Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAddresses", "Longitude");
            DropColumn("dbo.UserAddresses", "Latitude");
        }
    }
}
