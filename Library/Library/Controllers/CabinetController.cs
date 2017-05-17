using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CabinetController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Cabinet";

            return View();
        }
    }
}