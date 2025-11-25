using Roles;
using Task;

namespace TaskStates
{
    public class ClosedTaskState : ITaskState
    {
        public string Name => "Закрыта";
        public TaskStatus Status => TaskStatus.Completed;

        public void FinishCurrentState(Task.Task task, User actor)
        {
            Console.WriteLine($"[STATE] {actor.Name} попытался изменить закрытую задачу '{task.Title}'. Состояние не поменялось.");
        }
    }
}


