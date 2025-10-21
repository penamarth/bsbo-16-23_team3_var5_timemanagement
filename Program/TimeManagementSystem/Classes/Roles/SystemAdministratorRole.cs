using Interfaces;
using SystemAdministratorActions;

namespace Roles
{
    public class SystemAdministrator : IRole
    {
        public List<IAction>? GetActions()
        {
            return new List<IAction>
            {
                new TechSupportAction()
            };
        }
    }
}