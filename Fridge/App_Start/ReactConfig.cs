using JavaScriptEngineSwitcher.Core;
using JavaScriptEngineSwitcher.V8;
using React;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Fridge.ReactConfig), "Configure")]

namespace Fridge
{
    public static class ReactConfig
    {
        public static void Configure()
        {
            JsEngineSwitcher.Current.DefaultEngineName = V8JsEngine.EngineName;
            JsEngineSwitcher.Current.EngineFactories.AddV8();
            // If you want to use server-side rendering of React components,
            // add all the necessary JavaScript files here. This includes
            // your components as well as all of their dependencies.
            // See http://reactjs.net/ for more information. Example:
            ReactSiteConfiguration.Configuration
                .AddScript("~/Scripts/Components/Login/Login.jsx")
                .AddScript("~/Scripts/Components/Login/LoginForm.jsx")
                .AddScript("~/Scripts/Components/Register/Register.jsx")
                .AddScript("~/Scripts/Components/Register/RegisterForm.jsx")
                .AddScript("~/Scripts/Components/Home/Home.jsx")
                .AddScript("~/Scripts/Components/Home/Banner.jsx")
                .AddScript("~/Scripts/Components/Home/RecipeCard.jsx")
                .AddScript("~/Scripts/Components/Home/IngredientCard.jsx")
                .AddScript("~/Scripts/Components/Home/WalletCards.jsx")
                .AddScript("~/Scripts/Components/Recipe/Index/Recipe.jsx")
                .AddScript("~/Scripts/Components/Recipe/Index/RecipeList.jsx")
                .AddScript("~/Scripts/Components/Recipe/Create/CreateRecipe.jsx")
                .AddScript("~/Scripts/Components/Recipe/Create/CreateRecipeForm.jsx")
                .AddScript("~/Scripts/Components/Recipe/Detail/DetailRecipe.jsx")
                .AddScript("~/Scripts/Components/Recipe/Detail/DetailRecipeInfo.jsx")
                .AddScript("~/Scripts/Components/Recipe/Edit/EditRecipe.jsx")
                .AddScript("~/Scripts/Components/Recipe/Edit/EditRecipeForm.jsx")
                .AddScript("~/Scripts/Components/Recipe/Delete/DeleteRecipe.jsx")
                .AddScript("~/Scripts/Components/Recipe/Delete/DeleteRecipeInfo.jsx")
                .AddScript("~/Scripts/Components/Ingredients/Index/Ingredients.jsx")
                .AddScript("~/Scripts/Components/Ingredients/Index/PersonalIngredientList.jsx")
                .AddScript("~/Scripts/Components/Ingredients/Create/CreateIngredientFridge.jsx")
                .AddScript("~/Scripts/Components/Ingredients/Create/IngredientFrom.jsx")
                .AddScript("~/Scripts/Components/Ingredient/Edit/AddIngredientFridge.jsx")
                .AddScript("~/Scripts/Components/Ingredient/Edit/IngredientForm.jsx")
                ;

            // If you use an external build too (for example, Babel, Webpack,
            // Browserify or Gulp), you can improve performance by disabling
            // ReactJS.NET's version of Babel and loading the pre-transpiled
            // scripts. Example:
            //ReactSiteConfiguration.Configuration
            //	.SetLoadBabel(false)
            //	.AddScriptWithoutTransform("~/Scripts/bundle.server.js")
        }
    }
}