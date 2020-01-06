using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Fridge.Models;

namespace Fridge.Controllers
{
    public class ApiRecipeController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/ApiIngredient
        public List<Recipe> Get()
        {
            return _db.Recipes.ToList();
        }

        /// <summary>
        /// Gets detail of 1 recipe 
        /// </summary>
        /// <param name="id">Recipe Id</param>
        /// <returns>Recipe data</returns>
        [HttpPost]
        public Recipe GetDetail([FromBody] int id)
        {
            return _db.Recipes.Find(id);
        }
    }
}