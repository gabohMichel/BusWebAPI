using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;

namespace BusWebAPI.Application.Contracts.Interfaces
{
    public interface IUserRepository : IDisposable
    {
        Task<User> GetUser(int id);
        Task<User> GetUser(string userName, string pwd);
        Task<List<User>> GetUsers();
        Task<User> CreateUser(TabUser user);
        Task<User> UpdateUser(TabUser user);
        Task<bool> DeleteUser(TabUser user);
    }
}
