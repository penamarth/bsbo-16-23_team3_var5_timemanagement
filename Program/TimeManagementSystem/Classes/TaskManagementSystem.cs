using System;
using System.Collections.Generic;
using Roles;
using Storage;

namespace Controllers
{
    public enum UserRoleType
    {
        Employee,
        Manager,
        SystemAdministrator
    }

    public class TaskManagementSystem
    {
        private readonly InMemoryUserStorage _userStorage = new();
        private readonly TaskManagement _taskManagement;
        private int _userSequence = 1;

        public TaskManagementSystem()
        {
            _taskManagement = new TaskManagement(_userStorage);
        }

        public User CreateUser(string name, UserRoleType roleType)
        {
            var role = roleType switch
            {
                UserRoleType.Employee => new Employee(),
                UserRoleType.Manager => new Manager(),
                UserRoleType.SystemAdministrator => new SystemAdministrator(),
                _ => throw new ArgumentOutOfRangeException(nameof(roleType), roleType, "Неизвестная роль.")
            };

            var user = new User(_userSequence++, name, role);
            _userStorage.Add(user);
            return user;
        }

        public User? GetUserById(int id)
        {
            return _userStorage.GetById(id);
        }

        public IReadOnlyCollection<User> ListUsers()
        {
            return _userStorage.GetAll();
        }

        public Task.Task CreateTask(User manager, string title, string description)
        {
            return _taskManagement.CreateTask(manager.Id, title, description);
        }

        public void AssignTask(User manager, Task.Task task, User assignee)
        {
            _taskManagement.AssignTask(manager.Id, task.Id, assignee.Id);
        }

        public void TrackTaskExecution(User manager)
        {
            _taskManagement.TrackTaskExecution(manager.Id);
        }

        public void MonitorWorkload(User manager)
        {
            _taskManagement.MonitorWorkload(manager.Id);
        }

        public string TrackTaskStatus(User requester, Task.Task task)
        {
            return _taskManagement.TrackTaskStatus(requester.Id, task.Id);
        }

        public void StartTask(User employee, Task.Task task)
        {
            _taskManagement.StartTask(employee.Id, task.Id);
        }

        public void CompleteTask(User employee, Task.Task task, double workloadHours)
        {
            _taskManagement.CompleteTask(employee.Id, task.Id, workloadHours);
        }

        public void CollectStatistics(User manager)
        {
            _taskManagement.CollectStatistics(manager.Id);
        }

        public void ProvideTechSupport(User admin)
        {
            _taskManagement.ProvideTechSupport(admin.Id);
        }

        public IReadOnlyCollection<Task.Task> ListTasks(User requester)
        {
            return _taskManagement.ListTasks(requester.Id);
        }
    }
}
