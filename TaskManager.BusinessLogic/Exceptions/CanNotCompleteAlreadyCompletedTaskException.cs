using System;

namespace TaskManager.BusinessLogic.Exceptions
{
    [Serializable]
    public class CanNotCompleteAlreadyCompletedTaskException : Exception
    {
        public CanNotCompleteAlreadyCompletedTaskException(Task task):base($"Can not complete task id= {task.Id} with state = {task.State}")
        {
        }
    }
}