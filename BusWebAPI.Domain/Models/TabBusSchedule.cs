namespace BusWebAPI.Domain.Models;

public partial class TabBusSchedule
{
    public int Id { get; set; }

    public DateTime? DepartureTime { get; set; }

    public DateTime? ArrivingTime { get; set; }

    public bool? IsAvailable { get; set; }

    public int? IdBus { get; set; }

    public int? IdRoute { get; set; }

    public virtual TabRoute? IdRouteNavigation { get; set; }

    public virtual ICollection<TabTicket> TabTicket { get; set; } = new List<TabTicket>();
}
