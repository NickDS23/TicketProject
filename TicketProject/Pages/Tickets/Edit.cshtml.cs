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
using ctr = TicketProject.Controlles;

namespace TicketProject.Pages.Tickets
{
    public class EditModel : PageModel
    {
        private readonly TicketProject.Data.TicketProjectContext _context;

        public EditModel(TicketProject.Data.TicketProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var res = new ctr.TicketsController(_context);
            await res.EditGet(id);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var res = new ctr.TicketsController(_context);
            await res.EditPost(Ticket.Id, Ticket);


            return RedirectToPage("./Index");
        }
    }
}
