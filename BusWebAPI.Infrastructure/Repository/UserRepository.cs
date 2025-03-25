using BusWebAPI.Application.Contracts.Interfaces;
using BusWebAPI.Domain.Dto;
using BusWebAPI.Domain.Models;
using BusWebAPI.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace BusWebAPI.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BusDBContext _busDbContext;

        public UserRepository(BusDBContext busDbContext)
        {
            _busDbContext = busDbContext;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            GC.Collect();
        }
        public async Task<User> GetUser(int id)
        {
            return (User)await _busDbContext.TabUser.FindAsync(id);
        }
        public async Task<List<User>> GetUsers()
        {
            return await _busDbContext.TabUser.Select(o => (User)o).ToListAsync();
        }
        public async Task<User> GetUser(string userName, string pwd)
        {
            var u = await _busDbContext.TabUser.Where(o => o.UserName == userName && o.Password == pwd).FirstOrDefaultAsync();
            return (User)u;
        }
        public async Task<User> CreateUser(TabUser user)
        {
            var o = await _busDbContext.TabUser.AddAsync(user);
            _busDbContext.SaveChanges();

            return (User)o.Entity;
        }
        public async Task<User> UpdateUser(TabUser user)
        {
            var rowsAffected = await _busDbContext.TabUser.Where(o => o.Id == user.Id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(o => o.Password, user.Password));
            //var rowsAffected = _busDbContext.SaveChanges();
            if (rowsAffected == 0)
                return null;
            return (User)user;
        }
        public async Task<bool> DeleteUser(TabUser user)
        {
            var rowsAffected = await _busDbContext.TabUser.Where(o => o.Id == user.Id)
                .ExecuteDeleteAsync();
            if (rowsAffected == 0)
                return false;
            return true;
        }
    }
}
