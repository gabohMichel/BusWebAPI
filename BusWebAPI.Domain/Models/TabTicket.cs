namespace BusWebAPI.Domain.Models;

public partial class TabTicket
{
    public int Id { get; set; }

    public decimal? Price { get; set; }

    public int? IdUser { get; set; }

    public int? IdBusSchedule { get; set; }

    public virtual TabBusSchedule? IdBusScheduleNavigation { get; set; }

    public virtual TabUser? IdUserNavigation { get; set; }

    public virtual ICollection<TabSeat> TabSeat { get; set; } = new List<TabSeat>();
}
