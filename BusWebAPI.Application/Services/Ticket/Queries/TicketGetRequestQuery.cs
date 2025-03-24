using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Ticket.Queries
{
    public class TicketGetRequestQuery : IRequest<Response<TicketGetResponseQuery>>
    {
        public int IdUser { get; set; }
        public int IdTicket { get; set; }
    }
}
