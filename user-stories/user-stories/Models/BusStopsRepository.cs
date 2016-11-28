using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using user_stories.Models;

namespace user_stories.Models
{
    public class BusStopsRepository : IRepository<BusStop>
    {
        private ApplicationDbContext db;

        public BusStopsRepository()
        {
            this.db = new ApplicationDbContext();
        } 

        public IEnumerable<BusStop> GetList()
        {
            return db.BusStops;
        }

        public BusStop Get(int id)
        {
            return db.BusStops.Find(id);
        }

        public void Create(BusStop busStop)
        {
            db.BusStops.Add(busStop);
        }

        public void Update(BusStop busStop)
        {
            db.Entry(busStop).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            BusStop busStop = db.BusStops.Find(id);
            if (busStop != null)
                db.BusStops.Remove(busStop);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}