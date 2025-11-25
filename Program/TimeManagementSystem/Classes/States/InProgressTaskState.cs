using Roles;
using Task;

namespace TaskStates
{
    public class InProgressTaskState : ITaskState
    {
        public string Name => "В работе";
        public TaskStatus Status => TaskStatus.InProgress;

        public void FinishCurrentState(Task.Task task, User actor)
        {
            Console.WriteLine($"[STATE] {actor.Name} завершает работу над задачей '{task.Title}'.");
            task.SetState(new ClosedTaskState());
        }
    }
}


