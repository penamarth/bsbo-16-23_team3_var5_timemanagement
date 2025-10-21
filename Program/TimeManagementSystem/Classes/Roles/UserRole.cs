using Interfaces;

namespace Roles
{
    public class User : IRole
    {
        public string Name { get; set; }
        public IRole Role { get; set; }

        public User(string name, IRole role)
        {
            Name = name;
            Role = role;
        }

        public List<IAction>? GetActions()
        {
            return null;
        }

        public void PerformAction(IAction action)
        {
            action.Execute();
        }
    }
}