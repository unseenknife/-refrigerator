using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fridge.Models
{
    // Model for the Recipe table
    public class Recipe
    {
        [Key] public int Id { get; set; }
        [Required] public string UserId { get; set; }
        [StringLength(255)] [Required] public string Name { get; set; }
        [Required] public int PrepareTime { get; set; }
        [Required] public int Servings { get; set; }
        [StringLength(500)] public string Description { get; set; }

        // Set the foreign key RecipeId in the tables Preparations and RecipeIngredients
        [ForeignKey("RecipeId")] public virtual List<Preparation> Preparations { get; set; }
        [ForeignKey("RecipeId")] public virtual List<RecipeIngredient> RecipeIngredients { get; set; }

    }
}
