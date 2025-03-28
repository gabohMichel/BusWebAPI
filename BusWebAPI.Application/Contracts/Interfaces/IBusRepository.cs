using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IBusRepository
    {
        Task<Bus> Get(int id);
        Task<List<Bus>> GetList();
        Task<Bus> Create(TabBus bus);
        Task<bool> Update(TabBus bus);
        Task<bool> Delete(int id);
    }
}
