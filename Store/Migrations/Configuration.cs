namespace Store.Migrations
{
    using Store.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Store.Models.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Store.Models.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Genres.AddOrUpdate(
              p => p.Name,
                new Genre { Name = "pop" },
                new Genre { Name = "mpb" },
                new Genre { Name = "classical" },
                new Genre { Name = "rock" }
                );
            //
        }
    }
}
