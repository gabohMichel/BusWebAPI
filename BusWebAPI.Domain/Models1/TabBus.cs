namespace BusWebAPI.Domain.Models1
{
    public class TabBus
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public int Capacity { get; set; }
        public int IdStatus { get; set; }
        public virtual CatStatusBus StatusBus { get; set; } = new CatStatusBus();
        public int IdCategory { get; set; }
        public virtual CatCategoryBus CategoryBus { get; set; } = new CatCategoryBus();
    }
}
