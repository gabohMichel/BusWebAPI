using BusWebAPI.Domain.Models;

namespace BusWebAPI.Domain.Dto
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public static explicit operator User(TabUser user)
        {
            if (user == null)
                return null;

            return new User()
            {
                Id = user.Id,
                Username = user.UserName ?? string.Empty,
                IsAdmin = user.IsAdmin ?? false
            };
        }
    }
}
