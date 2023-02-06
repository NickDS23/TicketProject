using System.ComponentModel.DataAnnotations;

namespace TicketProject.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Time { get; set; }
        public string? Description { get; set; }
    }
}
