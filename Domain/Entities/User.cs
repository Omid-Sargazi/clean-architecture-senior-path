namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public User(string email, string password)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
        }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Email) && 
                   Email.Contains("@") && 
                   !string.IsNullOrEmpty(Password) && 
                   Password.Length >= 6;
        }
    }
}