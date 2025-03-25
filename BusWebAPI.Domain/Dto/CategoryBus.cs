using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Domain.Dto
{
    public class CategoryBus
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public static implicit operator CategoryBus(CatCategoryBus catCategoryBus)
        {
            return new CategoryBus { Id = catCategoryBus.Id, Label = catCategoryBus.Label };
        }
    }
}
