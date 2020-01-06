using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fridge.Models
{
    // Model for the Category table
    public class Category
    {
        [Key] public int Id { get; set; }
        [StringLength(255)] [Required] public string Name { get; set; }
        

        // Set the foreign key CategoryId in the table Ingredients
        [ForeignKey("CategoryId")] public virtual List<Ingredient> Ingredients { get; set; }


    }
}
