using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketProject.Data;
using TicketProject.Models;

namespace TicketProject.Actions
{
    public class CreateAction: PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(TicketProjectContext context, Ticket ticket)
        {
            if (!ModelState.IsValid || context.Ticket == null || ticket == null)
            {
                return Page();
            }

            context.Ticket.Add(ticket);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
