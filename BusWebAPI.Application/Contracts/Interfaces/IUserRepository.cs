using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<User> Get(int id);
        Task<User> Get(string userName, string pwd);
        Task<List<User>> GetList();
        Task<User> Create(TabUser user);
        Task<bool> Update(TabUser user);
        Task<bool> Delete(int id);
    }
}
