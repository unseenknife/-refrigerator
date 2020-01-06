using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration
    {
        /// <summary>
        /// Automatic data migration for the RecipeIngredient table
        /// </summary>
        /// <param name="context"> The database connection </param>
        public void RecipeIngredient(ApplicationDbContext context)
        {
            context.RecipeIngredients.AddOrUpdate(i => i.Id,
                new RecipeIngredient() { RecipeId = 1, IngredientId = 40, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 1, IngredientId = 44, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 1, IngredientId = 59, Quantity = 2 },
                new RecipeIngredient() { RecipeId = 1, IngredientId = 39, Quantity = 10 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 40, Quantity = 2 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 46, Quantity = 4 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 49, Quantity = 4 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 74, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 51, Quantity = 10 },
                new RecipeIngredient() { RecipeId = 2, IngredientId = 20, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 3, IngredientId = 29, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 4, IngredientId = 8, Quantity = 100 },
                new RecipeIngredient() { RecipeId = 4, IngredientId = 11, Quantity = 50 },
                new RecipeIngredient() { RecipeId = 4, IngredientId = 14, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 4, IngredientId = 13, Quantity = 1 },
                new RecipeIngredient() { RecipeId = 5, IngredientId = 61, Quantity = 100 },
                new RecipeIngredient() { RecipeId = 5, IngredientId = 39, Quantity = 10 },
                new RecipeIngredient() { RecipeId = 6, IngredientId = 27, Quantity = 1 });

            context.SaveChanges();
        }
    }
}
