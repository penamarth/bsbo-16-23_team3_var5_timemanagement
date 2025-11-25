using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeActions;
using Interfaces;
using ManagerActions;
using Roles;
using SystemAdministratorActions;
using Task;

namespace Controllers
{
    public class TaskManagement : ITaskStorage
    {
        private readonly IUserStorage _userStorage;
        private readonly List<Task.Task> _tasks = new();
        private int _sequence = 1;

        public TaskManagement(IUserStorage userStorage)
        {
            _userStorage = userStorage;
        }

        public Task.Task CreateTask(int managerId, string title, string description)
        {
            var manager = RequireUser(managerId);
            var task = new Task.Task(_sequence++, title, description, this);
            task.attachCreator(manager);
            _tasks.Add(task);

            Console.WriteLine($"[TaskManagement] {manager.Name} создал задачу '{task.Title}' (ID: {task.Id}).");
            manager.PerformAction(new CreateTaskAction());
            return task;
        }

        public void AssignTask(int managerId, int taskId, int assigneeId)
        {
            var manager = RequireUser(managerId);
            var task = RequireTask(taskId);
            var assignee = RequireUser(assigneeId);

            task.assignTo(assignee);
            Console.WriteLine($"[TaskManagement] {manager.Name} назначил '{task.Title}' пользователю {assignee.Name}.");
        }

        public void StartTask(int employeeId, int taskId)
        {
            var employee = RequireUser(employeeId);
            var task = RequireTask(taskId);

            task.advanceState(employee);
            employee.PerformAction(new TrackTaskStatusAction());
        }

        public void CompleteTask(int employeeId, int taskId, double workloadHours)
        {
            var employee = RequireUser(employeeId);
            var task = RequireTask(taskId);

            task.updateWorkload(workloadHours);
            task.advanceState(employee);
            employee.PerformAction(new CompleteTaskAction());
        }

        public string TrackTaskStatus(int requesterId, int taskId)
        {
            var user = RequireUser(requesterId);
            var task = RequireTask(taskId);

            var status = task.trackStatus();
            Console.WriteLine($"[TaskManagement] {user.Name} запросил статус задачи '{task.Title}': {status}");
            return status;
        }

        public IReadOnlyCollection<Task.Task> ListTasks(int requesterId)
        {
            RequireUser(requesterId);
            return _tasks.AsReadOnly();
        }

        public void MonitorWorkload(int managerId)
        {
            var manager = RequireUser(managerId);
            manager.PerformAction(new MonitorWorkloadAction());
            Console.WriteLine($"[TaskManagement] В системе { _tasks.Count } задач(и).");
        }

        public void TrackTaskExecution(int managerId)
        {
            var manager = RequireUser(managerId);
            manager.PerformAction(new TrackTaskExecutionAction());
            foreach (var task in _tasks)
            {
                Console.WriteLine($"   • {task.Title}: {task.trackStatus()}");
            }
        }

        public void CollectStatistics(int managerId)
        {
            var manager = RequireUser(managerId);
            manager.PerformAction(new CollectStatisticsAction());
            var completed = _tasks.Count(t => t.Status == TaskStatus.Completed);
            Console.WriteLine($"[TaskManagement] Завершено задач: {completed} из {_tasks.Count}.");
        }

        public void ProvideTechSupport(int adminId)
        {
            var admin = RequireUser(adminId);
            admin.PerformAction(new TechSupportAction());
        }

        public Task.Task? GetById(int taskId)
        {
            return _tasks.FirstOrDefault(t => t.Id == taskId);
        }

        public IReadOnlyCollection<Task.Task> GetAll()
        {
            return _tasks.AsReadOnly();
        }

        public Task.Task Upsert(Task.Task task)
        {
            var index = _tasks.FindIndex(existing => existing.Id == task.Id);
            if (index >= 0)
            {
                _tasks[index] = task;
            }
            else
            {
                _tasks.Add(task);
            }
            return task;
        }

        private User RequireUser(int userId)
        {
            var user = _userStorage.GetById(userId);
            if (user == null)
            {
                throw new InvalidOperationException($"Пользователь с id={userId} не найден.");
            }
            return user;
        }

        private Task.Task RequireTask(int taskId)
        {
            var task = GetById(taskId);
            if (task == null)
            {
                throw new InvalidOperationException($"Задача с id={taskId} не найдена.");
            }
            return task;
        }
    }
}


