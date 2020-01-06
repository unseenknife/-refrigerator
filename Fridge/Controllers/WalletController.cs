using System.Linq;
using System.Web.Mvc;
using Fridge.Models;

namespace Fridge.Controllers
{
    public class WalletController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Decrease wallet value after buying an ingredient
        /// </summary>
        /// <param name="userId"> The id of the user </param>
        /// <param name="ingredientId"> The id of the ingredient you buy </param>
        public void WalletDecrease(string userId, int ingredientId)
        {
            // Get ingredient price from database
            var ingredientPrice = (from ingredient in db.Ingredients
                                   where ingredient.Id == ingredientId
                                   select ingredient.Price).FirstOrDefault();

            // Get users wallet value from database
            var walletValue = (from user in db.Users
                               where user.Id == userId
                               select user.Wallet).FirstOrDefault();

            // Set new wallet value
            var newWalletValue = walletValue - ingredientPrice;

            // Update wallet value in database
            db.Database.ExecuteSqlCommand("UPDATE aspnetusers SET Wallet={0} WHERE Users.Id = {1}", newWalletValue, userId);
        }

        
        /// <summary>
        /// When called with cache timeout, increase the wallet by the allowance amount.
        /// </summary>
        public void AllowanceIncrease()
        {
            var users = db.Users.ToArray();

            foreach (var user in users)
            {
                var newWallet = user.Wallet + 35;
                string sql = $"UPDATE aspnetusers SET Wallet = {newWallet} where Id = '{user.Id}'";
                db.Database.ExecuteSqlCommand(sql.Replace(",", "."));
                db.SaveChanges();
            }
        }
    }
}