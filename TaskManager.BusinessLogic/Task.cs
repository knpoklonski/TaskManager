using System;

namespace TaskManager.BusinessLogic
{
    public class Task
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; }
        public DateTime TimeToComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskState State { get; set; }
    }
}