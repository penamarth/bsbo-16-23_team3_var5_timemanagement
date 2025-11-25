using System;
using Interfaces;
using Roles;
using TaskStates;

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
        private readonly ITaskStorage _storage;
        public int Id { get; private set; }
        public string Title { get; private set; }
        public TaskStatus Status { get; private set; }
        public string Description { get; private set; }
        public double Workload { get; private set; }
        public User? AssignedTo { get; private set; }
        public User? CreatedBy { get; private set; }
        public ITaskState CurrentState { get; private set; }

        public Task(int id, string title, string description, ITaskStorage storage)
        {
            _storage = storage;
            Id = id;
            Title = title;
            Description = description;
            CurrentState = new NewTaskState();
            Status = CurrentState.Status;
            Workload = 0;
        }

        public void attachCreator(User creator)
        {
            CreatedBy = creator;
            _storage.Upsert(this);
        }

        public void assignTo(User user)
        {
            AssignedTo = user;
            Console.WriteLine($"Задача '{Title}' назначена пользователю {user.Name}.");
            _storage.Upsert(this);
        }

        public void updateWorkload(double hours)
        {
            Workload = hours;
            _storage.Upsert(this);
        }

        public void advanceState(User actor)
        {
            CurrentState.FinishCurrentState(this, actor);
            _storage.Upsert(this);
        }

        internal void SetState(ITaskState nextState)
        {
            CurrentState = nextState;
            Status = nextState.Status;
        }

        public string getTaskDetails()
        {
            var assignedInfo = AssignedTo != null ? AssignedTo.Name : "не назначена";
            return $"id: {Id}\nstate: {CurrentState.Name}\nassigned: {assignedInfo}\ndescription: {Description}\nworkload: {Workload}\n";
        }

        public string trackStatus()
        {
            return $"{CurrentState.Name} ({Status})";
        }
    }
}
