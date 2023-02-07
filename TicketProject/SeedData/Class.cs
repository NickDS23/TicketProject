using Microsoft.EntityFrameworkCore;
using TicketProject.Data;

namespace TicketProject.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new  TicketProjectContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<TicketProjectContext>>()))
        {
            if (context == null || context.Ticket == null)
            {
                throw new ArgumentNullException("Null RazorPagesContext");
            }

            
            if (context.Ticket.Any())
            {
                return;   // DB has been seeded
            }

            context.Ticket.AddRange(
                new Ticket
                {
                    Title = "Task to do #1",
                    Description = "First test task",
                    Time = DateTime.Parse("13:05:02"),
                },

                 new Ticket
                 {
                     Title = "Task to do #3",
                     Description = "Second test task",
                     Time = DateTime.Parse("14:25:10"),
                 },

                 new Ticket
                 {
                     Title = "Task to do #2",
                     Description = "Third test task",
                     Time = DateTime.Parse("15:55:22"),
                 }
            );
            context.SaveChanges();

            if (context.Ticket.Any())
            {
                return;
            }
        }
    }
}
