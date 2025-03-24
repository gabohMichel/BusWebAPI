using BusWebAPI.Domain.Models;

namespace BusWebAPI.Infrastructure.Context
{
    public class DbContext
    {
        public DbSet<TabUser> User { get; }
        public DbContext() 
        { 
            User = new DbSet<TabUser>();
        }
    }
}
