using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class BusSchedule
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBus { get; set; }
        public string? BusPlates {  get; set; }
        public string? BusCategory {  get; set; }
        public int IdRoute { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }

        public static explicit operator BusSchedule(TabBusSchedule busSchedule)
        {
            return new BusSchedule
            {
                Id = busSchedule.Id,
                ArrivingTime = (DateTime)busSchedule.ArrivingTime,
                DepartureTime = (DateTime)busSchedule.DepartureTime,
                IdBus = (int)busSchedule.IdBus,
                IdRoute = (int)busSchedule.IdRoute,
                IsAvailable = (bool)busSchedule.IsAvailable
            };
        }
    }
}
