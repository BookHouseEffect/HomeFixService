namespace HomeFixService.WebService.Migrations
{
    using System.Data.Entity.Migrations;
    using HomeFixService.WebService.Extensions;
    using HomeFixService.WebService.Models.EntityFramework;
    using HomeFixService.WebService.Models.Enums;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeFixService.WebService.Models.Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HomeFixService.WebService.Models.Context.DatabaseContext context)
        {
            context.Professions.SeedEnumValues<Professions, ProfessionsEnum>(@enum => @enum);
            context.SaveChanges();

            context.Currencies.SeedEnumValues<Currencies, CurrencyEnum>(@enum => @enum);
            context.SaveChanges();
        }
    }
}
