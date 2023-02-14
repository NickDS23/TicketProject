using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;
using actions = TicketProject.Actions;


namespace TicketProject.Controlles
{
    public class TicketsController : Controller
    {
        private readonly TicketProjectContext _context;

        public TicketsController(TicketProjectContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
              return _context.Ticket != null ? 
                          View(await _context.Ticket.ToListAsync()) :
                          Problem("Entity set 'TicketProjectContext.Ticket'  is null.");
        }

        // GET: Tickets/Details/5
        public async Task<Ticket> Details(int? id)
        {
            var detail = new actions.DetailsAction();
            var s = await detail.OnGetAsync(id, _context);

            return detail.Ticket;
        }

        // GET: Tickets/Create
        public IActionResult OnGetCreate()
        {
            var v = new actions.CreateAction();
            return v.OnGet();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Time,Description")] Ticket ticket)
        {
            var res = new actions.CreateAction();
            await res.OnPostAsync(_context, ticket);

            return View();
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> EditGet(int? id)
        {
            var res = new actions.EditAction();
            await res.OnGetAsync(id, _context);

            return View();
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id, [Bind("Id,Title,Time,Description")] Ticket ticket)
        {
            var res = new actions.EditAction();
            await res.OnPostAsync(_context, ticket);

            return View();
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var res = new actions.DeleteAction();
            await res.OnGetAsync(id, _context);

            return View();
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = new actions.DeleteAction();
            await res.OnPostAsync(id, _context);

            return View();
        }

        private bool TicketExists(int id)
        {
          var res = new actions.EditAction();
          return res.TicketExists(id, _context);
        }
    }
}
