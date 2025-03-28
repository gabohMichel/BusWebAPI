using BusWebAPI.Domain.Dto;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface ICategoryBusRepository
    {
        Task<List<CategoryBus>> GetList();
    }
}
