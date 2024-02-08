namespace Middleware.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string name, string password, bool isAdmin)
        {
            Id = new Guid();
            Name = name;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
