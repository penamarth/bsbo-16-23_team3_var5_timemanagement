using Interfaces;
using ManagerActions;

namespace Roles
{
    public class Manager : IRole
    {
        public List<IAction>? GetActions()
        {
            return new List<IAction>
            {
                new TrackTaskExecutionAction(),
                new CollectStatisticsAction(),
                new MonitorWorkloadAction(),
                new CreateTaskAction(),
            };
        }
    }
}