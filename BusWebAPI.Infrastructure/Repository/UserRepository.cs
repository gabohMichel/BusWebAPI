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
        public async Task<User> Get(int id)
        {
            return (User)await _busDbContext.TabUser.FindAsync(id);
        }
        public async Task<List<User>> GetList()
        {
            return await _busDbContext.TabUser.Select(o => (User)o).ToListAsync();
        }
        public async Task<User> Get(string userName, string pwd)
        {
            var u = await _busDbContext.TabUser.Where(o => o.UserName == userName && o.Password == pwd).FirstOrDefaultAsync();
            return (User)u;
        }
        public async Task<User> Create(TabUser user)
        {
            var o = await _busDbContext.TabUser.AddAsync(user);
            _busDbContext.SaveChanges();

            return (User)o.Entity;
        }
        public async Task<bool> Update(TabUser user)
        {
            var rowsAffected = await _busDbContext.TabUser.Where(o => o.Id == user.Id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(o => o.Password, user.Password));
            
            return rowsAffected > 0;
        }
        public async Task<bool> Delete(int id)
        {
            var rowsAffected = await _busDbContext.TabUser.Where(o => o.Id == id)
                .ExecuteDeleteAsync();
            return rowsAffected > 0;
        }
    }
}
