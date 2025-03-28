using BusWebAPI.Domain.Dto;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IStatusBusRepository
    {
        Task<List<StatusBus>> GetList();
    }
}
