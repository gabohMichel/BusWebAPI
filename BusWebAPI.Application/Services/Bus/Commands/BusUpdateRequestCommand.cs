using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusUpdateRequestCommand : IRequest
    {
        public int Id { get; set; }
        public int IdStatus { get; set; }
    }
}
