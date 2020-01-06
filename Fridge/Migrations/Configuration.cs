using Fridge.Models;

namespace Fridge.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed partial class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
        }

        protected override void Seed(ApplicationDbContext context) 
        {
            //  This method will be called after migrating to the latest version.

            //  Load migration sample data 

            User(context);
            Category(context);
            Ingredient(context);
            Recipe(context);
            RecipeIngredient(context);
            Preparation(context);

        }
    }
}
