using BusWebAPI.Domain.Models1;

namespace BusWebAPI.Infrastructure.Context1
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
