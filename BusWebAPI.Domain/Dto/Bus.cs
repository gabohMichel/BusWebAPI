using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class Bus
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public int? Capacity { get; set; }
        public int? IdStatus { get; set; }
        public string? Status { get; set; }
        public int? IdCategory { get; set; }
        public string? Category { get; set; }
        public static explicit operator Bus(TabBus bus)
        {
            return new Bus 
            { 
                Id = bus.Id, 
                Plate = bus.Plates, 
                Capacity = bus.Capacity, 
                IdStatus = bus.IdStatusBus, 
                Status = bus.IdStatusBusNavigation?.Label,
                IdCategory = bus.IdCategory,
                Category = bus.IdCategoryNavigation?.Label
            };
        }
    }
}
