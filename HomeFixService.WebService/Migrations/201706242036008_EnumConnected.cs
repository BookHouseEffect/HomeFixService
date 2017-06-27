namespace HomeFixService.WebService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EnumConnected : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfessions", "ProfessionId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserProfessions", "ProfessionId");
            AddForeignKey("dbo.UserProfessions", "ProfessionId", "dbo.Professions", "Id", cascadeDelete: true);
            DropColumn("dbo.UserProfessions", "TheProfession");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserProfessions", "TheProfession", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserProfessions", "ProfessionId", "dbo.Professions");
            DropIndex("dbo.UserProfessions", new[] { "ProfessionId" });
            DropColumn("dbo.UserProfessions", "ProfessionId");
        }
    }
}
