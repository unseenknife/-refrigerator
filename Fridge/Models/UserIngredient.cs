using System.ComponentModel.DataAnnotations;

namespace Fridge.Models
{
    // Model for the UserIngredient table
    public class UserIngredient
    {
        [Key] public int Id { get; set; }
        [Required] public string UserId { get; set; }
        [Required] public int IngredientId { get; set; }
        [Required] public int Quantity { get; set; }

    }
}
