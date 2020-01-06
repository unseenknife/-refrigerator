using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Fridge.Models;
using Microsoft.AspNet.Identity;

namespace Fridge.Controllers
{
    [Authorize]
    public class RecipeController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get details of recipe
        /// </summary>
        /// <param name="id">Id of the recipe</param>
        /// <returns>Recipe</returns>
        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Find recipe by id
            var recipe = _db.Recipes.Find(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Add a recipe in Recipe table
        /// </summary>
        /// <param name="recipe"> The recipe </param>
        // POST: Recipe/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Recipe recipe)
        {
            if (recipe == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Add new recipe
            var currentUserId = User.Identity.GetUserId();
            if (currentUserId == null) return View();
            _db.Recipes.Add(new Recipe
            {
                UserId = currentUserId,
                Name = recipe.Name,
                PrepareTime = recipe.PrepareTime,
                Servings = recipe.Servings,
                Description = recipe.Description
            });
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            return View();
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            if (recipe == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find recipe by id
            var recipeToUpdate = _db.Recipes.Find(recipe.Id);
            // Find current user
            var currentUserId = User.Identity.GetUserId();
            // Check if user made the recipe
            if (currentUserId != recipe.UserId)
            {
                return RedirectToAction("Index");
            }
            //Update recipe in database
            if (recipeToUpdate != null) _db.Recipes.AddOrUpdate(recipe);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int? id)
        {
            // recipe id not present
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find recipe by id
            var recipe = _db.Recipes.Find(id);
            // If no recipe is found
            if (recipe == null)
            {
                return HttpNotFound();
            }
            // Find current user
            var currentUserId = User.Identity.GetUserId();
            // Check if user made the recipe
            if (currentUserId != recipe.UserId)
            {
                return RedirectToAction("Index");
            }

            return View("Delete", recipe);
        }

        /// <summary>
        /// Deletes recipe from tables
        /// </summary>
        /// <param name="recipe"> model of recipe </param>
        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(Recipe recipe)
        {
            // Find recipe by id
            var recipeDelete = _db.Recipes.Find(recipe.Id);
            // Find current user
            var currentUserId = User.Identity.GetUserId();
            // Check if user made the recipe
            if (recipeDelete != null && currentUserId != recipeDelete.UserId)
            {
                return RedirectToAction("Index");
            }
            //remove recipe from database
            if (recipeDelete != null) _db.Recipes.Remove(recipeDelete);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Add recipeIngredient in RecipeIngredient table
        /// </summary>
        /// <param name="recipeIngredient"> The recipeIngredient </param>
        public void RecipeIngredientAdd(RecipeIngredient recipeIngredient)
        {
            _db.RecipeIngredients.Add(recipeIngredient);
            _db.SaveChanges();
        }

        /// <summary>
        /// Add preparation in Preparation table
        /// </summary>
        /// <param name="preparation"> The preparation </param>
        public void PreparationAdd(Preparation preparation)
        {
            _db.Preparations.Add(preparation);
            _db.SaveChanges();
        }

        /// <summary>
        /// Checking and updating ingredients to recipe
        /// </summary>
        /// <param name="id">recipe id</param>
        /// <returns>redirect to action Index</returns>
        public ActionResult Prepare(int? id)
        {
            // recipe id not present
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Find recipe by id
            var recipe = _db.Recipes.Find(id);
            // If no recipe is found
            if (recipe == null)
            {
                return HttpNotFound();
            }

            //Get recipe ingredient list
            var recipeIngredientsList = _db.RecipeIngredients.ToList();

            //Get user ingredient list & normal ingredient list
            var userIngredient = _db.UserIngredients.ToList();
            var ingredients = _db.Ingredients.ToList();

            //Filter recipe ingredient list on recipe id
            var recipeIngredientIdList = recipeIngredientsList.FindAll(x => x.RecipeId == recipe.Id);

            //Check what ingredients belong to certain user Id
            var userIngredientIdList = userIngredient.FindAll(x => x.UserId == User.Identity.GetUserId());

            List<UserIngredientList> personalIngredients = new List<UserIngredientList>();

            foreach (var ingredientId in userIngredientIdList)
            {
                //Find ingredient in normal ingredient list with every id of the user ingredient list
                var userIngredientDetails = ingredients.Find(x => x.Id == ingredientId.IngredientId);

                //Makes new list
                var userIngredientList = new UserIngredientList()
                {
                    Id = userIngredientDetails.Id,
                    Name = userIngredientDetails.Name,
                    Quantity = ingredientId.Quantity,
                    Unit = userIngredientDetails.Unit
                };

                //Add list to return value
                personalIngredients.Add(userIngredientList);
            }

            foreach (var recipeIngredientId in recipeIngredientIdList)
            {
                //Find ingredient in personal ingredient list with every id of the recipe ingredient list
                var recipeIngredientDetails = personalIngredients.Find(x => x.Id == recipeIngredientId.IngredientId);

                //If doenst exist in list it'll cancel your action and redirect
                if (recipeIngredientDetails == null)
                {
                    return RedirectToAction("Index");
                }

                //Gets the quantity of ingredient from recipe list
                var recipeIngredientQuantity = recipeIngredientIdList.Find(x => x.IngredientId == recipeIngredientDetails.Id).Quantity;

                //Chances personal ingredient quantity
                var personalUpdate = userIngredientIdList.Find(x => x.IngredientId == recipeIngredientDetails.Id);
                personalUpdate.Quantity = recipeIngredientDetails.Quantity - recipeIngredientQuantity;

                //If ingredient is 0 it'll delete it from fridge
                if (personalUpdate.Quantity == 0)
                {
                    _db.UserIngredients.Remove(personalUpdate);
                    _db.SaveChanges();
                }

                //if ingredient is above 
                if (personalUpdate.Quantity > 0)
                {
                    _db.UserIngredients.AddOrUpdate(personalUpdate);
                    _db.SaveChanges();
                }

            }

            return RedirectToAction("Index");
        }
    }
}