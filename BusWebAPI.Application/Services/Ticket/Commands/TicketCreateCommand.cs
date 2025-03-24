using MediatR;

namespace BusWebAPI.Application.Services.Ticket.Commands
{
    public class TicketCreateCommand : IRequest
    {
        public decimal Price { get; set; }
        public int IdUser { get; set; }
        public int IdBusSchedule { get; set; }
    }
}
