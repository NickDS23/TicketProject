using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketProject.Data;
using TicketProject.Models;
using ctr  = TicketProject.Controlles;

namespace TicketProject.Pages.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly TicketProject.Data.TicketProjectContext _context;

        public CreateModel(TicketProject.Data.TicketProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
           var res = new ctr.TicketsController(_context); 
           return res.OnGetCreate();
        }

        [BindProperty]
        public Ticket Ticket { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var res = new ctr.TicketsController(_context);
            await res.Create(Ticket);

            return RedirectToPage("./Index");
        }
    }
}
