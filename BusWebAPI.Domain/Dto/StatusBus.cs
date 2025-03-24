using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class StatusBus
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public static implicit operator StatusBus(CatStatusBus catStatusBus)
        {
            return new StatusBus { Id = catStatusBus.Id, Label = catStatusBus.Label };
        }
    }
}
