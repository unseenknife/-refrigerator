using System.Collections.Generic;
using System.Linq;
using Fridge.Models;
using System.Web.Http;

namespace Fridge.Controllers
{
    public class ApiIngredientController : ApiController
    {

        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/ApiIngredient
        public List<Ingredient> Get()
        {
            return _db.Ingredients.ToList();
        }

        /// <summary>
        /// Gets personal list of ingredients
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>List with ingredients of from that user Id</returns>
        public List<UserIngredientList> GetPersonal(string userId)
        {
            //Get user ingredient list & normal ingredient list
            var userIngredient = _db.UserIngredients.ToList();
            var ingredients = _db.Ingredients.ToList();

            //Check what ingredients belong to certain user Id
            var ingredientIdList = userIngredient.FindAll(x => x.UserId == userId);

            List<UserIngredientList> personalIngredients = new List<UserIngredientList>();

            foreach (var ingredientId in ingredientIdList)
            {
                //Find ingredient in normal ingredient list with every id of the user ingredient list
                var userIngredientDetails = ingredients.Find(x => x.Id == ingredientId.IngredientId);

                //Makes new list
                var userIngredientList = new UserIngredientList()
                {
                    Id = userIngredientDetails.Id, Name = userIngredientDetails.Name, Quantity = ingredientId.Quantity, Unit = userIngredientDetails.Unit
                };

                //Add list to return value
                personalIngredients.Add(userIngredientList);


            }

            return personalIngredients;

        }

        /// <summary>
        /// Get image for amount of ingredients user owns
        /// </summary>
        /// <param name="userId">Id from user</param>
        /// <returns>Image</returns>
        public string GetHomePersonal(string userId)
        {
            //Get all users and ingredients
            var userIngredient = _db.UserIngredients.ToList();

            //Filter on user Id
            var ingredientIdList = userIngredient.FindAll(x => x.UserId == userId);
            string image = "../Content/Images/EmptyFridge.jpg";

            //If user owns more than 5 ingredients the image changes
            if (ingredientIdList.Count >= 5)
            {
                image = "../Content/Images/FullFridge.jpg";
                return image;
            }

            return image;

        }

        //GET: api/ApiIngredient/5
        public Ingredient Get(int id)
        {
            return _db.Ingredients.Find(id);
        }
    }
}
