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
    public class DeleteModel : PageModel
    {
        private readonly TicketProject.Data.TicketProjectContext _context;

        public DeleteModel(TicketProject.Data.TicketProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var res = new ctr.TicketsController(_context);
            await res.Delete(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
  
            var res = new ctr.TicketsController(_context);
            await res.DeleteConfirmed(id);

            return RedirectToPage("./Index");
        }
    }
}
