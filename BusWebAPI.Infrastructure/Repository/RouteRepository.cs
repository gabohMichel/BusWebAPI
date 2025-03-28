using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.Repository
{
    public class RouteRepository : IRouteRepository
    {
        private readonly BusDBContext _busDBContext;

        public RouteRepository(BusDBContext busDBContext)
        {
            _busDBContext = busDBContext;
        }

        public async Task<Route> Create(TabRoute route)
        {
            var ent = await _busDBContext.TabRoute.AddAsync(route);
            await _busDBContext.SaveChangesAsync();
            return (Route)ent.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            return await _busDBContext.TabRoute.Where(o => o.Id == id).ExecuteDeleteAsync() > 0;
        }

        public async Task<Route> Get(int id)
        {
            var r = await _busDBContext.TabRoute.FindAsync(id);
            return (Route)r;
        }

        public async Task<List<Route>> GetList(string? departurePoint = null, string? arrivingPoint = null)
        {
            var q = _busDBContext.TabRoute.AsQueryable();
            if (!string.IsNullOrWhiteSpace(departurePoint)) 
                q.Where(o => o.DeparturePoint == departurePoint);    
            if (!string.IsNullOrWhiteSpace(arrivingPoint))
                q.Where(o => o.ArrivingPoint == arrivingPoint);
            return await _busDBContext.TabRoute.Select(o => (Route)o).ToListAsync();
        }

        public async Task<bool> Update(TabRoute route)
        {
            var rowAffected = await _busDBContext.TabRoute
                .Where(o => o.Id == route.Id)
                .ExecuteUpdateAsync(setters =>
                    setters
                    .SetProperty(o => o.Distance, route.Distance)
                );
            return rowAffected > 0;
        }
    }
}
