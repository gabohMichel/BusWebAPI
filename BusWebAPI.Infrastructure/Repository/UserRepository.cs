using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;
using BusWebAPI.Infrastructure.Context;

namespace BusWebAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;

        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
        public async Task<User> GetUser(int id)
        {
            return (User)_dbContext.User.Get(id);
        }
        public async Task<List<User>> GetUsers()
        {
            return (List<User>)_dbContext.User.GetList();
        }
    }
}
