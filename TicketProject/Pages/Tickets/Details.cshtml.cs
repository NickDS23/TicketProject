using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;
using ctr = TicketProject.Controlles;

namespace TicketProject.Pages.Tickets
{
    public class DetailsModel : PageModel
    {
        private readonly TicketProject.Data.TicketProjectContext _context;

        public DetailsModel(TicketProject.Data.TicketProjectContext context)
        {
            _context = context;
        }

      public Ticket Ticket { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var contr = new ctr.TicketsController(_context);
            var s = await contr.Details(id);

            Ticket = s;

            return Page();
        }
    }
}
