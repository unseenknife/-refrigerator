using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fridge.Models
{
    // Model for the Ingredient table
    public class Ingredient
    {
        [Key] public int Id { get; set; }
        [StringLength(255)] [Required] public string Name { get; set; }
        [Required] public decimal Price { get; set; }
        [Required] public int Quantity { get; set; }
        [StringLength(10)] [Required] public string Unit { get; set; }
        [Required] public int? CategoryId { get; set; }
        [StringLength(500)] public string Description { get; set; }

        // Set the foreign key IngredientId in the tables RecipeIngredients and UserIngredients
        [ForeignKey("IngredientId")] public virtual List<RecipeIngredient> RecipeIngredients { get; set; }
        [ForeignKey("IngredientId")] public virtual List<UserIngredient> UserIngredients { get; set; }

    }
}
