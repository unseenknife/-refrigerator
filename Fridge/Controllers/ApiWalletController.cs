using System.Linq;
using Fridge.Models;
using System.Web.Http;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;


namespace Fridge.Controllers
{

    [Authorize]
    public class ApiWalletController : ApiController
    {
        private ApplicationDbContext _db = new ApplicationDbContext();


        [Authorize]
        // GET: api/ApiIngredient
        public decimal Get(string userid)    
        {
            // Get current logged in user
            var user = _db.Users.SingleOrDefault(b => b.Id == userid);
            return user.Wallet;
        }
    }
}
