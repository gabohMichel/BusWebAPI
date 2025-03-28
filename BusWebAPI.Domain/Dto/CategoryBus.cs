using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class CategoryBus
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public static explicit operator CategoryBus(CatCategory catCategoryBus)
        {
            return new CategoryBus { Id = catCategoryBus.Id, Label = catCategoryBus.Label };
        }
    }
}
