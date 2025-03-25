namespace BusWebAPI.Domain.Models1
{
    public class RelBusSeatTicket
    {
        public int Id { get; set; }
        public int Seat { get; set; }
        public int IdTicket { get; set; }
        public virtual TabTicket Ticket { get; set; } = new TabTicket();
    }
}
