using Interfaces;

namespace ManagerActions
{
    public class TrackTaskExecutionAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача отслеживается!");
        }
    }

    public class CollectStatisticsAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Статистика успешно собрана!");
        }
    }

    public class MonitorWorkloadAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Отчет о рабочей нагрузке предоставлен!");
        }
    }

    public class CreateTaskAction : IAction
    {
        public void Execute()
        {
            Console.WriteLine("Задача создана!");
        }
    }
}