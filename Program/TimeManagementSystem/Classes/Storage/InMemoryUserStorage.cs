using Interfaces;
using Roles;
using System.Collections.Generic;
using System.Linq;

namespace Storage
{
    public class InMemoryUserStorage : IUserStorage
    {
        private readonly Dictionary<int, User> _users = new();

        public void Add(User user)
        {
            _users[user.Id] = user;
        }

        public IReadOnlyCollection<User> GetAll()
        {
            return _users.Values.ToList().AsReadOnly();
        }

        public User? GetById(int userId)
        {
            _users.TryGetValue(userId, out var user);
            return user;
        }
    }
}


