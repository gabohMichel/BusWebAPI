using MediatR;

namespace BusWebAPI.Application.Services.Bus.Commands
{
    public class BusCreateRequestCommand : IRequest
    {
        public string? Plates {  get; set; }
        public int Capacity { get; set; }
        public int IdStatusBus { get; set; }
        public int IdCategory { get; set; }
    }
}
