using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using user_stories.Models;

namespace user_stories.Controllers
{
    [Authorize]
    public class VoyageDatasController : Controller
    {
        IRepository<VoyageData> db;

        public VoyageDatasController()
        {
            db = new VoyageDatasRepository();
        }

        // GET: VoyageDatas
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        // GET: VoyageDatas/Create
        public ActionResult Create()
        {
            IRepository<BusStop> db1 = new BusStopsRepository();

            SelectList arriaval = new SelectList(db1.GetList(), "Id", "Name");
            SelectList departure = new SelectList(db1.GetList(), "Id", "Name");

            ViewBag.Arriaval = arriaval;
            ViewBag.Departure = departure;

            return View();
        }

        // POST: VoyageDatas/Create
        [HttpPost]
        public ActionResult Create(VoyageData voyageData)
        {
            if (ModelState.IsValid)
            {
                db.Create(voyageData); ;
                db.Save();
                return RedirectToAction("Index");
            }

            IRepository<BusStop> db1 = new BusStopsRepository();

            SelectList arriaval = new SelectList(db1.GetList(), "Id", "Name");
            SelectList departure = new SelectList(db1.GetList(), "Id", "Name");

            ViewBag.Arriaval = arriaval;
            ViewBag.Departure = departure;

            return View(voyageData);
        }

        // GET: VoyageDatas/Edit/5
        public ActionResult Edit(int id)
        {
            VoyageData voyageData = db.Get(id);

            IRepository<BusStop> db1 = new BusStopsRepository();

            SelectList arriaval = new SelectList(db1.GetList(), "Id", "Name");
            SelectList departure = new SelectList(db1.GetList(), "Id", "Name");

            ViewBag.Arriaval = arriaval;
            ViewBag.Departure = departure;

            return View(voyageData);
        }

        // POST: VoyageDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VoyageData voyageData)
        {
            if (ModelState.IsValid)
            {
                db.Update(voyageData);
                db.Save();
                return RedirectToAction("Index");
            }

            IRepository<BusStop> db1 = new BusStopsRepository();

            SelectList arriaval = new SelectList(db1.GetList(), "Id", "Name");
            SelectList departure = new SelectList(db1.GetList(), "Id", "Name");

            ViewBag.Arriaval = arriaval;
            ViewBag.Departure = departure;

            return View(voyageData);
        }

        public ActionResult BuyOrReserv(int id)
        {
            TicketsRepository dbTickets = new TicketsRepository();

            List<int> numb = new List<int>();

            var tickets = dbTickets.GetList().Where(p => p.Order.VoyageData.Id==id);

            var seatNumbers = db.Get(id);

            for(int i = 0; i < seatNumbers.NumberOfSeats; i++)
            {
                Ticket ticket = tickets.FirstOrDefault(p => p.PassengerSeatNumber == i + 1);
                if (ticket == null)
                {
                    numb.Add(i+1);
                }
            }

            SelectList seatList = new SelectList(numb);

            ViewBag.SeatList = seatList;

            Ticket newTicket = new Ticket()
            {
                Order = new Order()
                {
                    VoyageData = db.Get(id)
                }
            };

            return View(newTicket);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuyOrReserv(Ticket ticket)
        {
            TicketsRepository dbTickets = new TicketsRepository();

            if (ModelState.IsValid)
            {
                Ticket newTicket = new Ticket()
                {
                    Order = new Order()
                    {
                        VoyageId = ticket.Order.VoyageData.Id,
                        Status = ticket.Status
                    },
                    Status = ticket.Status,
                    PassengerDocumentNumber = ticket.PassengerDocumentNumber,
                    PassengerSeatNumber = ticket.PassengerSeatNumber,
                    PassengerFirstAndLastName = ticket.PassengerFirstAndLastName
                };

                dbTickets.Create(newTicket);
                dbTickets.Save();
        
                return RedirectToAction("Index");
            }

            return View(ticket);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            VoyageData voyageData = db.Get(id);
            return View(voyageData);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            db.Save();
            return RedirectToAction("Index");
        }

        public ActionResult VoyagesList(int? id)
        {
            return PartialView("_VoyagesListPartial", db.GetList().Where(d => d.BusStopDepartureId == id));
        }

        public ActionResult VoyageInfo(int id)
        {
            var a = db.GetList().Where(p => p.VoyageNumber == id);
            return View(db.GetList().Where(p => p.VoyageNumber == id));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
