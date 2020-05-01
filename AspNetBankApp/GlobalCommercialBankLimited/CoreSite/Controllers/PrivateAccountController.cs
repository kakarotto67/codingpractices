using System.Web.Mvc;
using GCBL.CoreSite.Helpers;

namespace GCBL.CoreSite.Controllers
{
    [RegisteredUsers]
    public class PrivateAccountController : Controller
    {
        // GET: PrivateAccount
        public ActionResult AccountPage()
        {
            return View();
        }
    }
}