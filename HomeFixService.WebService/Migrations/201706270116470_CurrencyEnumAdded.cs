namespace HomeFixService.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CurrencyEnumAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        CurrencySign = c.String(nullable: false, maxLength: 100),
                        CurrencyFullName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Professions", "ProfessionName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Professions", "ProfessionDescription", c => c.String(maxLength: 100));
            AddColumn("dbo.ProfessionServices", "ServiceUnitId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProfessionServices", "ServiceUnitId");
            AddForeignKey("dbo.ProfessionServices", "ServiceUnitId", "dbo.Currencies", "Id", cascadeDelete: true);
            DropColumn("dbo.Professions", "Name");
            DropColumn("dbo.Professions", "Description");
            DropColumn("dbo.ProfessionServices", "CurrencyUsed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProfessionServices", "CurrencyUsed", c => c.Int(nullable: false));
            AddColumn("dbo.Professions", "Description", c => c.String(maxLength: 100));
            AddColumn("dbo.Professions", "Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.ProfessionServices", "ServiceUnitId", "dbo.Currencies");
            DropIndex("dbo.ProfessionServices", new[] { "ServiceUnitId" });
            DropColumn("dbo.ProfessionServices", "ServiceUnitId");
            DropColumn("dbo.Professions", "ProfessionDescription");
            DropColumn("dbo.Professions", "ProfessionName");
            DropTable("dbo.Currencies");
        }
    }
}
