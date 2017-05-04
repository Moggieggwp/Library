using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthenticationManager authenticationManager;

        public AccountController(IAuthenticationManager authenticationManager)
        {
            this.authenticationManager = authenticationManager;
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Sign-In";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Sign-Up";

            return View();
        }

        [Route("SignOut")]
        public ActionResult SignOut()
        {
            this.authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login");
        }
    }
}