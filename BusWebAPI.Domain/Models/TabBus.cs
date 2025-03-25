namespace BusWebAPI.Domain.Models;

public partial class TabBus
{
    public int Id { get; set; }

    public string? Plates { get; set; }

    public int? Capacity { get; set; }

    public int? IdStatusBus { get; set; }

    public int? IdCategory { get; set; }

    public virtual CatCategory? IdCategoryNavigation { get; set; }

    public virtual CatStatusBus? IdStatusBusNavigation { get; set; }
}
