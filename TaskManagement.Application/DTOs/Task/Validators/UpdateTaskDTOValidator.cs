using FluentValidation;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.DTOs.Task.Validators
{
    public class UpdateTaskDTOValidator : AbstractValidator<UpdateTaskDTO>
    {
        private readonly ITaskRepository _taskRepository;
        public UpdateTaskDTOValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            Include(new ITaskDTOValidator(_taskRepository));

            RuleFor(p => p.ID).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
