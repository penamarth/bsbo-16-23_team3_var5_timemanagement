namespace Interfaces
{
    public interface ITaskStorage
    {
        Task.Task? GetById(int taskId);
        IReadOnlyCollection<Task.Task> GetAll();
        Task.Task Upsert(Task.Task task);
    }
}


