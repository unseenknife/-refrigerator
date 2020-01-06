using System.ComponentModel.DataAnnotations;

namespace Fridge.Models
{
    // Model for the Preparation table
    public class Preparation
    {
        [Key] public int Id { get; set; }
        [Required] public int? RecipeId { get; set; }
        [Required] public int Order { get; set; }
        [StringLength(500)] public string Description { get; set; }

    }
}
