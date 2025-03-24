namespace BusWebAPI.Application.Services.BusSchedule.Commands
{
    public class BusScheduleUpdateCommand
    {
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
    }
}
