using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Fridge.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Uses apiWalletController to get personal wallet of user
        /// </summary>
        /// <returns>Wallet</returns>
        public decimal GetWallet()
        {
            ApiWalletController apiWalletController = new ApiWalletController();
            return apiWalletController.Get(User.Identity.GetUserId());
        }

        /// <summary>
        /// Redirects to the index of home
        /// </summary>
        /// <returns>Redirect</returns>
        public RedirectToRouteResult Home()
        {
            return RedirectToAction("Index");
        }
    }
}
