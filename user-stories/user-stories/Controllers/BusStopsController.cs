using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using user_stories.Models;

namespace user_stories.Controllers
{
    [Authorize]
    public class BusStopsController : Controller
    {
        IRepository<BusStop> db;

        public BusStopsController()
        {
            db = new BusStopsRepository();
        }

        // GET: BusStops
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.Create(busStop);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(busStop);
        }

        public ActionResult Edit(int id)
        {
            BusStop busStop = db.Get(id);
            return View(busStop);
        }

        [HttpPost]
        public ActionResult Edit(BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                db.Update(busStop);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(busStop);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            BusStop busStop = db.Get(id);
            return View(busStop);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Find(int idBusStop)
        {
            BusStop busStop = db.Get(idBusStop);
            return View(busStop);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}