using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration
    {
        /// <summary>
        /// Automatic data migration for the Recipe table
        /// </summary>
        /// <param name="context"> The database connection </param>
        public void Recipe(ApplicationDbContext context)
        {
            context.Recipes.AddOrUpdate(i => i.Name,
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "Broodje ei", PrepareTime = 5, Servings = 1, Description = "Broodje ei" },
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "Hamburger", PrepareTime = 30, Servings = 1, Description = "Ouderwetse hamburger" },
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "Banaan", PrepareTime = 0, Servings = 1, Description = "Gezonde banaan" },
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "GroenteMix", PrepareTime = 0, Servings = 2, Description = "Gezonde mix voor de liefhebber" },
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "Garnalen", PrepareTime = 15, Servings = 1, Description = "Lekkerste manier om garnalen te koken" },
                new Recipe() { UserId = "661d5be6-2e0a-47a6-b17a-64662429e98c", Name = "Appel", PrepareTime = 1, Servings = 1, Description = "Geschilde lekkere appel" });

            context.SaveChanges();
        }
    }
}
