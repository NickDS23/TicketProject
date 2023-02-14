using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;

namespace TicketProject.Actions
{
    public class EditAction: PageModel
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
            Ticket = ticket;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(TicketProjectContext context, Ticket ticket1)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(ticket1).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(Ticket.Id, context))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        public bool TicketExists(int id, TicketProjectContext context)
        {
            return (context.Ticket?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
