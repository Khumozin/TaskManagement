using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Taskmanagement.Domain;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Task.Commands.Requests;

namespace TaskManagement.Application.Features.Task.Commands.Handlers
{
    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTaskCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.TaskRepository.Get(request.ID);

            if (task == null)
                throw new NotFoundException(nameof(TaskEntity), request.ID);

            await _unitOfWork.TaskRepository.Delete(task);
            await _unitOfWork.Save();

            return;
        }
    }
}
