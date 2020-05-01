using System.Web.Mvc;
using System.Web.Security;
using GCBL.CoreSite.Helpers;
using GCBL.CoreSite.Models;

namespace GCBL.CoreSite.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (AuthHelper.IsValidUser(model.Name, model.Password))
            {
                FormsAuthentication.SetAuthCookie(model.Name, false);
                return RedirectToLocal(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (AuthHelper.TryRegisterUserAccount(model.Name, model.Password))
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid registration attempt.");
            return View(model);
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}