using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using user_stories.Models;

namespace user_stories.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AutocompleteSearchBusStops(string term)
        {
            BusStopsRepository db = new BusStopsRepository();

            var models = db.GetList().Where(a => a.Name.ToLower().Contains(term.ToLower()))
                            .Select(a => new { value = a.Name, id = a.Id })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }
    }
}