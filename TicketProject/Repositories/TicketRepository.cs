using System;
using System.Collections.Generic;
using System.Linq;
using TicketProject.Data;
using TicketProject.Models;
using TicketProject.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TicketProject.Controllers
{
    public class TicketRepository : IRepository<Ticket>
    {
        private TicketProject.Data.TicketProjectContext db;

        public TicketRepository(TicketProject.Data.TicketProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Ticket> GetAll()
        {
            return db.Ticket;
        }

        public Ticket Get(int id)
        {
            return db.Ticket.Find(id);
        }

        public void Create(Ticket book)
        {
            db.Ticket.Add(book);
        }

        public void Update(Ticket book)
        {
            db.Entry(book).State = EntityState.Modified;
        }

        public IEnumerable<Ticket> Find(Func<Ticket, Boolean> predicate)
        {
            return db.Ticket.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Ticket book = db.Ticket.Find(id);
            if (book != null)
                db.Ticket.Remove(book);
        }
    }
}
