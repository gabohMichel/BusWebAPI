using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class BusSeatTicket
    {
        public int Id { get; set; }
        public int Seat { get; set; }
        public int IdTicket { get; set; }
        public static implicit operator BusSeatTicket(RelBusSeatTicket relBusSeatTicket)
        {
            return new BusSeatTicket { Id = relBusSeatTicket.Id, IdTicket = relBusSeatTicket.IdTicket, Seat = relBusSeatTicket.Seat };
        }
    }
}
