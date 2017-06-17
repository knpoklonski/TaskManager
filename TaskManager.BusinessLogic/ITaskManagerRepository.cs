using System.Collections.Generic;

namespace TaskManager.BusinessLogic
{
    public interface ITaskManagerRepository
    {
        IEnumerable<Task> Get(Filter filter);
        void Add(Task task);
        Task GetById(int id);
        void Delete(int id);
        void UpdateState(int id, TaskState state);
    }
}
