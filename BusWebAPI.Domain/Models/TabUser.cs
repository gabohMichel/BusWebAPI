namespace BusWebAPI.Domain.Models;

public partial class TabUser
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public bool? IsAdmin { get; set; }

    public virtual ICollection<TabTicket> TabTicket { get; set; } = new List<TabTicket>();
}
