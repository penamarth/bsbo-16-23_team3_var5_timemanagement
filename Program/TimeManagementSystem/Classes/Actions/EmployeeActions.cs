using Interfaces;

namespace EmployeeActions
{
    public class TrackTaskStatusAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Статус задачи проверен!");
        }
    }

    public class CompleteTaskAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача выполнена!");
        }
    }
}