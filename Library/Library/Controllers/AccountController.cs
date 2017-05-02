using System.Web.Mvc;

namespace Library.Controllers
{
    public class AccountController : Controller
    {
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
    }
}