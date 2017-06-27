namespace HomeFixService.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RatingOptimization : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RatingSum", c => c.Long(nullable: false));
            AddColumn("dbo.Users", "RatingCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "RatingCount");
            DropColumn("dbo.Users", "RatingSum");
        }
    }
}
