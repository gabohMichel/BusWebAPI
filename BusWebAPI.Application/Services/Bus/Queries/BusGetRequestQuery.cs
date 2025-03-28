using BusWebAPI.Domain.Common;
using MediatR;

namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetRequestQuery : IRequest<Response<BusGetResponseQuery>>
    {
        public int Id { get; set; }
    }
}
