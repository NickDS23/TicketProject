using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;

namespace TicketProject.Actions
{
    public class DeleteAction : PageModel
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
            }
            else
            {
                Ticket = ticket;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, TicketProjectContext context)
        {
            if (id == null ||context.Ticket == null)
            {
                return NotFound();
            }
            var ticket = await context.Ticket.FindAsync(id);

            if (ticket != null)
            {
                Ticket = ticket;
                context.Ticket.Remove(Ticket);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
