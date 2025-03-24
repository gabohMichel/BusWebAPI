using System;

namespace BusWebAPI.Domain.Models
{
    public class TabBusSchedule
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public bool IsAvailable { get; set; }
        public int IdBus { get; set; }
        public virtual TabBus Bus { get; set; } = new TabBus();
        public int IdRoute { get; set; }
        public virtual TabRoute Route { get; set;} = new TabRoute();
    }
}
