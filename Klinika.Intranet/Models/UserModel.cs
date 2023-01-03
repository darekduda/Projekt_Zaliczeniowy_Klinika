namespace Klinika.Intranet.Models
{
    public class UserModel
    {
        public UserModel(string userId, string userName, string role)
        {
            UserId = userId;
            UserName = userName;
            Role = role;
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}
