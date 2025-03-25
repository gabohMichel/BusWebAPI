using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Domain.Dto
{
    public class Route
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivingPoint { get; set; }
        public float Distance { get; set; }
        public static implicit operator Route(TabRoute route)
        {
            return new Route { Id = route.Id, DeparturePoint = route.DeparturePoint, ArrivingPoint = route.ArrivingPoint, Distance = route.Distance };
        }
    }
}
