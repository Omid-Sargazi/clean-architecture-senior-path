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
        }

        public bool IsValid()
        {
            return Email.Contains("@") && Password.Length >= 6;
        }
    }
}