using Roles;
using Task;

namespace TaskStates
{
    public interface ITaskState
    {
        string Name { get; }
        TaskStatus Status { get; }
        void FinishCurrentState(Task.Task task, User actor);
    }
}


