using EmployeeActions;
using Interfaces;

namespace Roles
{
    public class Employee : IRole
    {
        public List<IAction>? GetActions()
        {
            return new List<IAction>
            {
                new TrackTaskStatusAction(),
                new CompleteTaskAction()
            };
        }
    }
}