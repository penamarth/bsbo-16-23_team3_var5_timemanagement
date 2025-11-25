using Roles;
using Task;

namespace TaskStates
{
    public class NewTaskState : ITaskState
    {
        public string Name => "Новая";
        public TaskStatus Status => TaskStatus.Created;

        public void FinishCurrentState(Task.Task task, User actor)
        {
            Console.WriteLine($"[STATE] {actor.Name} запускает задачу '{task.Title}' в работу.");
            task.SetState(new InProgressTaskState());
        }
    }
}


