using BusWebAPI.Domain.Dto;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<List<User>> GetUsers();
    }
}
