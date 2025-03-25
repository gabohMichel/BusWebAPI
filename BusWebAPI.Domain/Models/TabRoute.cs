namespace BusWebAPI.Domain.Models;

public partial class TabRoute
{
    public int Id { get; set; }

    public string? DeparturePoint { get; set; }

    public string? ArrivingPoint { get; set; }

    public double? Distance { get; set; }

    public virtual ICollection<TabBusSchedule> TabBusSchedule { get; set; } = new List<TabBusSchedule>();
}
