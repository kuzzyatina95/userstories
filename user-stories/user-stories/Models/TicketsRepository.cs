using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace user_stories.Models
{
    public class TicketsRepository : IRepository<Ticket>
    {
        private ApplicationDbContext db;

        public TicketsRepository()
        {
            this.db = new ApplicationDbContext();
        }

        public IEnumerable<Ticket> GetList()
        {
            return db.Tickets.Include(p => p.Order.VoyageData);
        }

        public Ticket Get(int id)
        {
            return db.Tickets.Find(id);
        }

        public void Create(Ticket ticket)
        {
            db.Tickets.Add(ticket);
        }

        public void Update(Ticket ticket)
        {
            db.Entry(ticket).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket != null)
                db.Tickets.Remove(ticket);
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