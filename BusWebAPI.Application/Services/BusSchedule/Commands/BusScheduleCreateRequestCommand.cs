using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleCreateRequestCommand : IRequest
    {
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBus { get; set; }
        public int IdRoute { get; set; }
    }
}
