using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Domain.Dto
{
    public class BusSchedule
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBus { get; set; }
        public int IdRoute { get; set; }
        public static implicit operator BusSchedule(TabBusSchedule busSchedule)
        {
            return new BusSchedule
            {
                Id = busSchedule.Id,
                ArrivingTime = busSchedule.ArrivingTime,
                DepartureTime = busSchedule.DepartureTime,
                IdBus = busSchedule.IdBus,
                IdRoute = busSchedule.IdRoute,
                IsAvailable = busSchedule.IsAvailable
            };
        }
    }
}
