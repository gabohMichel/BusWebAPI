using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Domain.Dto
{
    public class Bus
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public int Capacity { get; set; }
        public int IdStatus { get; set; }
        public int IdCategory { get; set; }
        public static implicit operator Bus(TabBus bus)
        {
            return new Bus { Id = bus.Id, Plate = bus.Plate, Capacity = bus.Capacity, IdStatus = bus.IdStatus, IdCategory = bus.IdCategory };
        }
    }
}
