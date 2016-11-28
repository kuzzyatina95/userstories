using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class VoyageDatasRepository : IRepository<VoyageData>
    {
        private ApplicationDbContext db;

        public VoyageDatasRepository()
        {
            this.db = new ApplicationDbContext();
        }

        public IEnumerable<VoyageData> GetList()
        {
            return db.VoyageDatas.Include(b=>b.BusStopArrival).Include(b=>b.BusStopDeparture);
        }

        public VoyageData Get(int id)
        {
            return db.VoyageDatas.Find(id);
        }

        public void Create(VoyageData voyageData)
        {
            db.VoyageDatas.Add(voyageData);
        }

        public void Update(VoyageData voyageData)
        {
            db.Entry(voyageData).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            VoyageData voyageData = db.VoyageDatas.Find(id);
            if (voyageData != null)
                db.VoyageDatas.Remove(voyageData);
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