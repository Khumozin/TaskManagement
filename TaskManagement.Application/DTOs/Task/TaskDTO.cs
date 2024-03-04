using TaskManagement.Application.DTOs.Common;

namespace TaskManagement.Application.DTOs.Task
{
    public class TaskDTO : BaseDTO, ITaskDTO
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
