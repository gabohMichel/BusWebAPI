using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.Repository
{
    public class CategoryBusRepository : ICategoryBusRepository
    {
        private readonly BusDBContext _busDBContext;

        public CategoryBusRepository(BusDBContext busDBContext)
        {
            _busDBContext = busDBContext;
        }

        public async Task<List<CategoryBus>> GetList()
        {
            return await _busDBContext.CatCategory.Select(o => (CategoryBus)o).ToListAsync();
        }
    }
}
