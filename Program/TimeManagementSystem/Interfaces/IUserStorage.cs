using Roles;

namespace Interfaces
{
    public interface IUserStorage
    {
        User? GetById(int userId);
        IReadOnlyCollection<User> GetAll();
        void Add(User user);
    }
}


