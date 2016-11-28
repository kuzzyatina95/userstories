using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using user_stories.Models;

namespace user_stories.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VoyagesList()
        {
            VoyageDatasRepository db = new VoyageDatasRepository();
            return PartialView("_VoyagesListPartial", db.GetList());
        }

        public ActionResult BusStopsList()
        {
            BusStopsRepository db = new BusStopsRepository();
            return PartialView("_BusStopsListPartial", db.GetList());
        }

        public ActionResult FindVoyage()
        {
            ViewBag.Answer = "";
            return View();
        }
    }
}