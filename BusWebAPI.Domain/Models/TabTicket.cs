namespace BusWebAPI.Domain.Models
{
    public class TabTicket
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int IdUser { get; set; }
        public virtual TabUser User { get; set; } = new TabUser();
        public int IdSchedule { get; set; }
        public virtual TabBusSchedule Schedule { get; set; } = new TabBusSchedule();
    }
}
