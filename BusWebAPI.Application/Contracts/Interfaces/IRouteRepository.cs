using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IRouteRepository
    {
        Task<Route> Get(int id);
        Task<List<Route>> GetList(string? departurePoint = null, string? arrivingPoint = null);
        Task<Route> Create(TabRoute route);
        Task<bool> Update(TabRoute route);
        Task<bool> Delete(int id);
    }
}
