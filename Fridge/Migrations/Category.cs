using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration
    {
        /// <summary>
        /// Automatic data migration for the Category table
        /// </summary>
        /// <param name="context"> The database connection </param>
        public void Category(ApplicationDbContext context)
            {
                context.Categories.AddOrUpdate(i => i.Name,
                    new Category() { Name = "Pasta's" },
                    new Category() { Name = "Groenten" },
                    new Category() { Name = "Fruit" },
                    new Category() { Name = "Overig" },
                    new Category() { Name = "Vis" },
                    new Category() { Name = "Vlees" });

                context.SaveChanges();
        }
    }
}
