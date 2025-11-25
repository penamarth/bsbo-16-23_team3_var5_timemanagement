using Interfaces;

namespace Roles
{
    public class User : IRole
    {
        public int Id { get; }
        public string Name { get; set; }
        public IRole Role { get; set; }

        public User(int id, string name, IRole role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public List<IAction>? GetActions()
        {
            return Role.GetActions();
        }

        public void PerformAction(IAction action)
        {
            action.Execute();
        }
    }
}