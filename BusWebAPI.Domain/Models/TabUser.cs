using BusWebAPI.Domain.Common;

namespace BusWebAPI.Domain.Models
{
    public class TabUser : IEntiryBase
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
