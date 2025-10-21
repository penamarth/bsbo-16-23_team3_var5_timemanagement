using Roles;

namespace Task
{
    public enum TaskStatus
    {
        Created,
        InProgress,
        Completed,
        Rejected,
    }

    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public double Workload { get; set; }

        public Task(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
            Status = TaskStatus.Created;
            Workload = 0;
        }

        public string getTaskDetails()
        {
            return $"id: {Id}\nstatus: {fetchStatusString()}\ndescription: {Description}\nworkload: {Workload}\n";
        }

        public void markAsCompleted()
        {
            Status = TaskStatus.Completed;
        }

        public void assignTo(User user)
        {
            Console.WriteLine($"Задача присвоена пользователю {user.Name}!");
        }

        public string trackStatus()
        {
            return fetchStatusString();
        }

        private string fetchStatusString()
        {
            string status = "";
            switch (this.Status)
            {
                case TaskStatus.Created:
                    status = "Создана";
                    break;
                case TaskStatus.InProgress:
                    status = "Выполняется";
                    break;
                case TaskStatus.Completed:
                    status = "Выполнена";
                    break;
                case TaskStatus.Rejected:
                    status = "Отказана";
                    break;
                default:
                    status = "Неизвестный статус";
                    break;
            }
            return status;
        }
    }
    
    public class AssignedTask
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }

        
    }
}