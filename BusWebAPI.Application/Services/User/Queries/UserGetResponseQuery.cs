namespace BusWebAPI.Application.Services.User.Queries
{
    public class UserGetResponseQuery
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}
