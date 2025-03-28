using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.Repository
{
    public class StatusBusRepository : IStatusBusRepository
    {
        private readonly BusDBContext _busDBContext;

        public StatusBusRepository(BusDBContext busDBContext)
        {
            _busDBContext = busDBContext;
        }

        public async Task<List<StatusBus>> GetList()
        {
            return await _busDBContext.CatStatusBus.Select(o => (StatusBus)o).ToListAsync();
        }
    }
}
