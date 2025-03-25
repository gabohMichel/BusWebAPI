namespace BusWebAPI.Domain.Models;

public partial class CatCategory
{
    public int Id { get; set; }

    public string? Label { get; set; }

    public virtual ICollection<TabBus> TabBus { get; set; } = new List<TabBus>();
}
