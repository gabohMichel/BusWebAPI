using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusDeleteRequestCommand : IRequest
    {
        public int? Id { get; set; }
    }
}
