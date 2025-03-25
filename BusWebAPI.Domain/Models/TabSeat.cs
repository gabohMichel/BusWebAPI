namespace BusWebAPI.Domain.Models;

public partial class TabSeat
{
    public int Id { get; set; }

    public string? Seat { get; set; }

    public int? IdTicket { get; set; }

    public virtual TabTicket? IdTicketNavigation { get; set; }
}
