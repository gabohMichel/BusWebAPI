using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Ticket.Queries
{
    public class TicketListRequestQuery : IRequest<Response<IEnumerable<TicketListResponseQuery>>>
    {
        public int IdUser { get; set; }
    }
}
