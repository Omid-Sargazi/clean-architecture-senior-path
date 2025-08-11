using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        bool EmailExists(string email);
    }
}