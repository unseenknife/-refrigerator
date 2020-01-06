using System.ComponentModel.DataAnnotations;

namespace Fridge.Models
{
    // Model for the RecipeIngredient table
    public class RecipeIngredient
    {
        [Key] public int Id { get; set; }
        [Required] public int? RecipeId { get; set; }
        [Required] public int? IngredientId { get; set; }
        [Required] public int Quantity { get; set; }

    }
}
