using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly BusDBContext _busDBContext;
        public BusRepository(BusDBContext busDBContext)
        {
            _busDBContext = busDBContext;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
        public async Task<Bus> Create(TabBus bus)
        {
            var b = _busDBContext.TabBus.Add(bus);
            await _busDBContext.SaveChangesAsync();
            return (Bus)b.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            return await _busDBContext.TabBus.Where(o => o.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<Bus> Get(int id)
        {
            return await _busDBContext.TabBus
                .Where(o => o.Id == id)
                .Select(o => new Bus()
                {
                    Id = o.Id,
                    Capacity = o.Capacity,
                    IdCategory = o.IdCategory,
                    Category = o.IdCategoryNavigation.Label,
                    IdStatus = o.IdStatusBus,
                    Status = o.IdStatusBusNavigation.Label,
                    Plate = o.Plates
                }).FirstOrDefaultAsync();
        }

        public async Task<List<Bus>> GetList()
        {
            return await _busDBContext.TabBus
                .Select(o => new Bus()
                {
                    Id = o.Id,
                    Capacity = o.Capacity,
                    IdCategory = o.IdCategory,
                    Category = o.IdCategoryNavigation.Label,
                    IdStatus = o.IdStatusBus,
                    Status = o.IdStatusBusNavigation.Label,
                    Plate = o.Plates
                })
                .ToListAsync();
            
        }

        public async Task<bool> Update(TabBus bus)
        {
            return await _busDBContext.TabBus.Where(o => o.Id == bus.Id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(o => o.IdStatusBus, bus.IdStatusBus)) > 0;
        }
    }
}
