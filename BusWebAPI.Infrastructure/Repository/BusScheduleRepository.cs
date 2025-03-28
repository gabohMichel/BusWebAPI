using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BusWebAPI.Infrastructure.Repository
{
    public class BusScheduleRepository : IBusScheduleRepository
    {
        private readonly BusDBContext _busDBContext;

        public BusScheduleRepository(BusDBContext busDBContext)
        {
            _busDBContext = busDBContext;
        }

        public async Task<BusSchedule> Create(TabBusSchedule busSchedule)
        {
            var ent = await _busDBContext.TabBusSchedule.AddAsync(busSchedule);
            await _busDBContext.SaveChangesAsync();
            return (BusSchedule) ent.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            return await _busDBContext.TabBusSchedule
                .Where(o => o.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<BusSchedule> Get(int id)
        {
            var bs = await _busDBContext.TabBusSchedule
                .Select(o => new BusSchedule()
                {
                    Id = o.Id,
                    DepartureTime = (DateTime)o.DepartureTime,
                    ArrivingTime = (DateTime)o.ArrivingTime,
                    DeparturePoint = o.IdRouteNavigation.DeparturePoint,
                    ArrivingPoint = o.IdRouteNavigation.ArrivingPoint,
                    IdBus = (int)o.IdBus,
                    BusPlates = o.IdBusNavigation.Plates,
                    BusCategory = o.IdBusNavigation.IdCategoryNavigation.Label,
                    IdRoute = (int)o.IdRoute,
                    IsAvailable = (bool)o.IsAvailable
                })
                .FirstOrDefaultAsync();
            return bs;
        }

        public async Task<List<BusSchedule>> GetList(
            DateTime? departureTime = null,
            DateTime? arrivingTime = null,
            bool? castDateTimeToDate = null,
            string? departurePoint = null,
            string? arrivingPoint = null,
            int? idBus = null,
            string? plates = null,
            int? idRoute = null,
            bool? isAvailable = null,
            int[] notContainsId = null
            )
        {
            var q = _busDBContext.TabBusSchedule.AsQueryable();
            if(notContainsId.Length != null && notContainsId.Any())
                q.Where(o => !notContainsId.Contains(o.Id));
            if (isAvailable != null)
                q.Where(o => o.IsAvailable == isAvailable);
            if (idBus != null && idBus != 0)
                q.Where(o => o.IdBus == idBus);
            if (idRoute != null && idRoute != 0)
                q.Where(o => o.IdRoute == idRoute);

            if (departureTime != null)
                if(castDateTimeToDate ?? false)
                    q.Where(o => o.DepartureTime.Value.Date >= departureTime.Value.Date);
                else
                    q.Where(o => o.DepartureTime >= departureTime);

            if (arrivingTime != null)
                if (castDateTimeToDate ?? false)
                    q.Where(o => o.ArrivingTime.Value.Date <= arrivingTime.Value.Date);
                else
                    q.Where(o => o.ArrivingTime <= departureTime);

            if (!string.IsNullOrWhiteSpace(plates))
                q.Where(o => o.IdBusNavigation.Plates == plates);
            if (!string.IsNullOrWhiteSpace(departurePoint))
                q.Where(o => o.IdRouteNavigation.DeparturePoint == departurePoint);
            if (!string.IsNullOrWhiteSpace(arrivingPoint))
                q.Where(o => o.IdRouteNavigation.ArrivingPoint == arrivingPoint);
                        
            return await q.Select(o => new BusSchedule()
            {
                Id = o.Id,
                DepartureTime = (DateTime)o.DepartureTime,
                ArrivingTime = (DateTime)o.ArrivingTime,
                DeparturePoint = o.IdRouteNavigation.DeparturePoint,
                ArrivingPoint = o.IdRouteNavigation.ArrivingPoint,
                IdBus = (int)o.IdBus,
                BusPlates = o.IdBusNavigation.Plates,
                BusCategory = o.IdBusNavigation.IdCategoryNavigation.Label,
                IdRoute = (int)o.IdRoute,
                IsAvailable = (bool)o.IsAvailable
            }).ToListAsync();
        }

        public async Task<bool> Update(TabBusSchedule busSchedule)
        {
            return await _busDBContext.TabBusSchedule
                .ExecuteUpdateAsync(setters => 
                    setters
                    .SetProperty(o => o.DepartureTime, busSchedule.DepartureTime)
                    .SetProperty(o => o.ArrivingTime, busSchedule.ArrivingTime)
                    .SetProperty(o => o.IdBus, busSchedule.IdBus)
                    .SetProperty(o => o.IdRoute, busSchedule.IdRoute)
                    .SetProperty(o => o.IsAvailable, busSchedule.IsAvailable)
                ) > 0;
        }
    }
}
