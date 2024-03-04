namespace TaskManagement.Application.DTOs.Task
{
    public interface ITaskDTO
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
