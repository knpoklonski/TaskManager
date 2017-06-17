namespace TaskManager.BusinessLogic
{
    public class Filter
    {
        public TaskState State { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}