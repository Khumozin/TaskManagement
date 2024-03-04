using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Application.DTOs.Task.Validators
{
    public class ITaskDTOValidator : AbstractValidator<ITaskDTO>
    {
        private readonly ITaskRepository _taskRepository;

        public ITaskDTOValidator(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters");

            RuleFor(p => p.Completed)
                .NotNull();
        }
    }
}
