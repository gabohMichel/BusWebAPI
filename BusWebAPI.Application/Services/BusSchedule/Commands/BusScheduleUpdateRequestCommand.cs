using MediatR;

namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleUpdateRequestCommand : IRequest
    {
        public int? Id { get; set; }
        public DateTime? DepartureTime { get; set; }
        public DateTime? ArrivingTime { get; set; }
        public bool? IsAvailable { get; set; }
        public int? IdBus {  get; set; }
    }
}
