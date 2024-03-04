namespace TaskManagement.Application.DTOs.Task
{
    public class CreateTaskDTO : ITaskDTO
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
