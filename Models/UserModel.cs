namespace PrestoTraxSite.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public UserModel()
        {
            this.Id = 0;
            this.Username = "";
            this.Email = "";
            this.Password = "";
        }

        public UserModel(int id, string username, string email, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.Password = password;
        }
    }
}
