using System.Collections.Generic;
using TaskManager.BusinessLogic.Exceptions;

namespace TaskManager.BusinessLogic
{
    public class TaskManagerService : ITaskManagerService
    {
        private readonly ITaskManagerRepository _taskManagerRepository;

        public TaskManagerService(ITaskManagerRepository taskManagerRepository)
        {
            _taskManagerRepository = taskManagerRepository;
        }

        public IEnumerable<Task> Get(Filter filter)
        {
            return _taskManagerRepository.Get(filter);
        }

        public void Add(Task task)
        {
            _taskManagerRepository.Add(task);
        }

        public void Remove(int id)
        {
            var task = _taskManagerRepository.GetById(id);
            if (task == null)
                throw new TaskNotFoundException(id);

            _taskManagerRepository.Delete(id);
        }

        public void Complete(int id)
        {
            var task = _taskManagerRepository.GetById(id);
            if (task == null)
                throw new TaskNotFoundException(id);

            if (task.State == TaskState.Complete)
                throw new CanNotCompleteAlreadyCompletedTaskException(task);

            _taskManagerRepository.UpdateState(id, TaskState.Complete);
        }
    }
}