using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Domain.Dto
{
    public class Ticket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int IdUser { get; set; }
        public int IdSchedule { get; set; }
        public static implicit operator Ticket(TabTicket ticket)
        {
            return new Ticket { Id = ticket.Id, Price = ticket.Price, IdSchedule = ticket.IdSchedule, IdUser = ticket.IdUser };
        }
    }
}
