namespace BusWebAPI.Application.Services.Route.Queries
{
    public class RouteGetListResponseQuery
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
        public decimal? Distance { get; set; }
    }
}
