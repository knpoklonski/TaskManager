using System.Collections.Generic;

namespace TaskManager.BusinessLogic
{
    public interface ITaskManagerService
    {
        IEnumerable<Task> Get(Filter filter);
        void Add(Task task);
        void Remove(int id);
        void Complete(int id);
    }
}