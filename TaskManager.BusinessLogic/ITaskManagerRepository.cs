using System.Collections.Generic;

namespace TaskManager.BusinessLogic
{
    public interface ITaskManagerRepository
    {
        IEnumerable<Task> Get(Filter filter);
    }
}
