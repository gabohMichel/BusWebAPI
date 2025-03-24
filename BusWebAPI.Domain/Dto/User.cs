using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public bool IsAdmin { get; set; }
        public static implicit operator User(TabUser user)
        {
            return new User()
            {
                Id = user.Id,
                Username = user.Username,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
