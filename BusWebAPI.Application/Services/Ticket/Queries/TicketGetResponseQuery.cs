namespace BusWebAPI.Application.Services.Ticket.Queries
{
    public class TicketGetResponseQuery
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? NameRoute { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivingTime { get; set; }
        public DateTime TotalTime { get; set; }
        public string? Seats { get; set; }
        public bool IsAvailable { get; set; }
    }
}
