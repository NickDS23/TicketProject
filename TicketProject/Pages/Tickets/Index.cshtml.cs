using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketProject.Pages.Tickets
{
    public class IndexModel : PageModel
    {
        private readonly TicketProject.Data.TicketProjectContext _context;

        public IndexModel(TicketProject.Data.TicketProjectContext context)
        {
            _context = context;
        }

        public IList<Ticket> Ticket { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Titles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? CreationTime { get; set; }

        public async Task OnGetAsync()
        {
            var tickets = from t in _context.Ticket
                          select t;

            if (!string.IsNullOrEmpty(SearchString))
            {
                tickets = tickets.Where(s => s.Title.Contains(SearchString));
            }

            Ticket = await _context.Ticket.ToListAsync();
        }
    }
}
