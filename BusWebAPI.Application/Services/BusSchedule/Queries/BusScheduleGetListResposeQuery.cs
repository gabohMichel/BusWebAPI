namespace BusWebAPI.Application.Services.BusSchedule.Queries
{
    public class BusScheduleGetListResposeQuery
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBus { get; set; }
        public string? BusPlates { get; set; }
        public string? BusCategory { get; set; }
        public int IdRoute { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
    }
}
