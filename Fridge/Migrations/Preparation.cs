using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration
    {
        /// <summary>
        /// Automatic data migration for the Preparation table
        /// </summary>
        /// <param name="context"> The database connection </param>
        public void Preparation(ApplicationDbContext context)
        {
            context.Preparations.AddOrUpdate(i => i.Id,
                new Preparation() { RecipeId = 1, Order = 1, Description = "Doe boter in de pan" },
                new Preparation() { RecipeId = 1, Order = 2, Description = "Breek het ei in de pan en kook deze" },
                new Preparation() { RecipeId = 1, Order = 3, Description = "Als deze is gebakken, zet het ei op het brood" },
                new Preparation() { RecipeId = 2, Order = 1, Description = "Doe boten in de pan" },
                new Preparation() { RecipeId = 2, Order = 2, Description = "Zet hamburger in de pan" },
                new Preparation() { RecipeId = 2, Order = 3, Description = "Wanneer hamburger gaar is stop deze op brood" },
                new Preparation() { RecipeId = 2, Order = 4, Description = "Bak nu de uitjes in de pan" },
                new Preparation() { RecipeId = 2, Order = 5, Description = "Zet op de hamburger mayonaise en ketchup" },
                new Preparation() { RecipeId = 3, Order = 1, Description = "Pak de banaan en schil deze" },
                new Preparation() { RecipeId = 4, Order = 1, Description = "Doe olie in de pan" },
                new Preparation() { RecipeId = 4, Order = 2, Description = "Zet groente in de pan" },
                new Preparation() { RecipeId = 4, Order = 3, Description = "Wacht totdat groente is gekookt" },
                new Preparation() { RecipeId = 4, Order = 4, Description = "Zet groente op een bord" },
                new Preparation() { RecipeId = 5, Order = 1, Description = "Doe boter in de pan" },
                new Preparation() { RecipeId = 5, Order = 2, Description = "Doe garnalen in de pan" },
                new Preparation() { RecipeId = 5, Order = 3, Description = "Als de garnalen gaar zijn, haal de garnalen uit de pan en op een bord" },
                new Preparation() { RecipeId = 6, Order = 1, Description = "Pak een mes" },
                new Preparation() { RecipeId = 6, Order = 2, Description = "Schil de appel" });

            context.SaveChanges();
        }
    }
}
