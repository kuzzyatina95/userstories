using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using user_stories.Models;

namespace user_stories.Controllers
{

    public class ValuesController : ApiController
    {
        [System.Web.Http.Route("api/values")]
        public IEnumerable<BusStop> GetBusStops()
        {
            BusStopsRepository db = new BusStopsRepository();

            return db.GetList();
        }

        [System.Web.Http.Route("api/values/{term}")]
        public IEnumerable<BusStop> GetBusStops(string term)
        {
            BusStopsRepository db = new BusStopsRepository();

            return db.GetList().Where(a => a.Name.ToLower().Contains(term.ToLower()));
        }

        [System.Web.Http.Route("api/values/{term}/{id:int}")]
        public IEnumerable<VoyageData> GetBusStopsWithDeparture(string term, int id)
        {
            VoyageDatasRepository db = new VoyageDatasRepository();

            return db.GetList().Where(p => p.BusStopDepartureId == id).Where(a => a.BusStopArrival.Name.ToLower().Contains(term.ToLower()));
        }

        [System.Web.Http.Route("api/values/getdatetime/{id:int}")]
        public IEnumerable<VoyageData> GetDateTime(int id)
        {
            VoyageDatasRepository db = new VoyageDatasRepository();

            return db.GetList().Where(p => p.VoyageNumber == id);
        }

    }
}
