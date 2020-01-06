using System;
using System.Linq;
using System.Web.Mvc;
using Fridge.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace Fridge.Controllers
{
    [Authorize]
    public class IngredientController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Ingredient
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ingredient/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Add or update a users ingredient
        /// </summary>
        /// <param name="model"> The model of the Ingredient </param>
        // POST: Ingredient/Create
        [HttpPost]
        [Authorize]
        public RedirectToRouteResult Create(Ingredient model)
        {
            _db.Ingredients.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Ingredient/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: Ingredient/Edit/5
        [HttpPost]

        [Authorize]
        public ActionResult Edit(Ingredient model)
        {
            // Get ingredient match from database ingredient
            var id = Convert.ToInt32(model.Name);
            var ingredient = _db.Ingredients.SingleOrDefault(b => b.Id == id);

            // Get UserId from logged in user
            var currentUserId = User.Identity.GetUserId();

            // Get current logged in user
            var user = _db.Users.SingleOrDefault(b => b.Id == currentUserId);

            decimal totalCost = 0;

            if (ingredient != null)
            {
                totalCost = ingredient.Price * model.Quantity;
            }

            // Get user ingredient matching name and userid
            var userIngredient = _db.UserIngredients.SingleOrDefault(b =>
                b.IngredientId == ingredient.Id && b.UserId == currentUserId);

            if (user != null && user.Wallet >= totalCost)
            {
                // If given user ingredient does not exist
                if (userIngredient == null)
                {
                    // Add new user ingredient
                    if (ingredient != null)
                        _db.UserIngredients.Add(new UserIngredient
                        {
                            UserId = currentUserId,
                            IngredientId = ingredient.Id,
                            Quantity = model.Quantity * ingredient.Quantity
                        });
                }
                else
                {
                    // Add to ingredient Quantity and save to database
                    if (ingredient != null) userIngredient.Quantity += (model.Quantity * ingredient.Quantity);
                }
                user.Wallet -= totalCost;
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Decreases ingredients from user when recipe is cooked
        /// </summary>
        /// <param name="recipeId"> The id of the recipe </param>
        public void IngredientDecrease(int recipeId)
        {
            // Get UserId string
            var currentUserId = User.Identity.GetUserId();

            // Get ingredient id's from the recipe
            var recipeIngredients = (from ingredients in _db.RecipeIngredients
                                     where ingredients.RecipeId == recipeId
                                     select ingredients.IngredientId).ToArray();

            // Foreach ingredient from recipe
            foreach (var recipeIngredient in recipeIngredients)
            {
                // Get quantity ingredient needed for recipe
                var quantityIngredient = (from ingredient in _db.RecipeIngredients
                                          where ingredient.IngredientId == recipeIngredient
                                          select ingredient.Quantity).First();

                // Get quantity user has of ingredient
                var quantityIngredientUser = (from userIngredient in _db.UserIngredients
                                              where userIngredient.UserId == currentUserId &&
                                                    userIngredient.IngredientId == recipeIngredient
                                              select userIngredient.Quantity).First();

                // Set new quantity value
                var newQuantityIngredients = quantityIngredientUser - quantityIngredient;

                // Update new quantity value in database
                _db.Database.ExecuteSqlCommand("UPDATE UserIngredients SET Quantity={0} WHERE UserId = {1} AND IngredientId = {2}", newQuantityIngredients, currentUserId, recipeIngredient);
            }
        }

        /// <summary>
        /// Get a list of personal ingredients
        /// </summary>
        /// <returns>Personal ingredient json</returns>
        public string PersonalIngredientList()
        {
            ApiIngredientController apiIngredientController = new ApiIngredientController();
            return JsonConvert.SerializeObject(apiIngredientController.GetPersonal(User.Identity.GetUserId()));
        }

        /// <summary>
        /// Gets an image for ingredient card home
        /// </summary>
        /// <returns>Image url json</returns>
        public string PersonalIngredientHomeList()
        {
            ApiIngredientController apiIngredientController = new ApiIngredientController();
            return JsonConvert.SerializeObject(apiIngredientController.GetHomePersonal(User.Identity.GetUserId()));
        }

    }
}