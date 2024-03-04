using FluentValidation;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.DTOs.Task.Validators
{
    public class CreateTaskDTOValidator : AbstractValidator<CreateTaskDTO>
    {
        private readonly ITaskRepository _taskRepository;

        public CreateTaskDTOValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            Include(new ITaskDTOValidator(_taskRepository));
        }
    }
}
