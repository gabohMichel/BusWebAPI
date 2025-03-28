using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class Route
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
        public decimal Distance { get; set; }
        public static explicit operator Route(TabRoute route)
        {
            return new Route { Id = route.Id, DeparturePoint = route.DeparturePoint, ArrivingPoint = route.ArrivingPoint, Distance = (decimal)route.Distance };
        }
    }
}
