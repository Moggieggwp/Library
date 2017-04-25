using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class SearchResultController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Results";

            return View();
        }
    }
}