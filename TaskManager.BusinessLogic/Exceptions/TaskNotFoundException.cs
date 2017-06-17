using System;

namespace TaskManager.BusinessLogic.Exceptions
{
    [Serializable]
    public class TaskNotFoundException : Exception
    {
        public TaskNotFoundException(int id) : base($"Task was not found task id= {id}")
        {
        }
    }
}