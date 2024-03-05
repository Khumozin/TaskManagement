using AutoMapper;
using MediatR;
using Taskmanagement.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Task.Validators;
using TaskManagement.Application.Features.Task.Commands.Requests;
using TaskManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Task.Commands.Handlers
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTaskDTOValidator(_unitOfWork.TaskRepository);
            var validationResult = await validator.ValidateAsync(request.taskDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Failed to create a task";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var task = _mapper.Map<TaskEntity>(request.taskDTO);
                task = await _unitOfWork.TaskRepository.Add(task);
                await _unitOfWork.Save(cancellationToken);

                response.Success = true;
                response.Message = "Task created successfully";
                response.ID = task.ID;
            }

            return response;
        }
    }
}
