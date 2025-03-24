namespace BusWebAPI.Domain.Models
{
    public class TabRoute
    {
        public int Id { get; set; }
        public string DeparturePoint { get; set; }
        public string ArrivingPoint { get; set; }
        public float Distance { get; set; }
    }
}
