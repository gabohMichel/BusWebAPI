namespace BusWebAPI.Domain.Models;

public partial class CatStatusBus
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<TabBus> TabBus { get; set; } = new List<TabBus>();
}
