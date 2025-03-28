namespace BusWebAPI.Application.Services.Bus.Queries
{
    public class BusGetListResponseQuery
    {
        public int Id { get; set; }
        public string? Plate { get; set; }
        public int? Capacity { get; set; }
        public int? IdStatus { get; set; }
        public string? Status { get; set; }
        public int? IdCategory { get; set; }
        public string? Category { get; set; }
    }
}
