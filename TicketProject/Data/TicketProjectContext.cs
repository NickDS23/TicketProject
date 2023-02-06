using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketProject.Models;

namespace TicketProject.Data
{
    public class TicketProjectContext : DbContext
    {
        public TicketProjectContext (DbContextOptions<TicketProjectContext> options)
            : base(options)
        {
        }

        public DbSet<TicketProject.Models.Ticket> Ticket { get; set; } = default!;
    }
}
