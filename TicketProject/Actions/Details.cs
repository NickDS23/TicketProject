using Microsoft.AspNetCore.Mvc;
using page = Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketProject.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TicketProject.Data;

namespace TicketProject.Actions
{
    public class DetailsAction: PageModel
    {
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id, TicketProjectContext context)
        {
            if (id == null || context.Ticket == null)
            {
                return NotFound();
            }

            var ticket = await context.Ticket.FirstOrDefaultAsync(m => m.Id == id);

            if (ticket == null)
            {
                return NotFound();
            } else {

                Ticket = ticket;
            }

            return Page();
        }
    }


}
