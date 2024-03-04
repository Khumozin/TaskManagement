using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Task.Validators;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Task.Commands.Requests;

namespace TaskManagement.Application.Features.Task.Commands.Handlers
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.Get(request.ID);

            if (task is null)
                throw new NotFoundException(nameof(TaskEntity), request.ID);

            if (request.TaskDTO != null)
            {
                var validator = new UpdateTaskDTOValidator((ITaskRepository)_unitOfWork.TaskRepository);
                var validationResult = await validator.ValidateAsync(request.TaskDTO, cancellationToken);

                if (validationResult.IsValid == false)
                    throw new ValidationException(validationResult);

                _mapper.Map(request.TaskDTO, task);

                await _unitOfWork.TaskRepository.Update(task);
                await _unitOfWork.Save();
            }
            else if (request.ChangeTaskCompleteStatus != null)
            {
                await _unitOfWork.TaskRepository.ChangeCompleteStatus(task, request.ChangeTaskCompleteStatus.Complete);
                await _unitOfWork.Save();
            }

            return Unit.Value;
        }
    }
}
