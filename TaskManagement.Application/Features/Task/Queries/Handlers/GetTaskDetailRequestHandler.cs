using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Task;
using TaskManagement.Application.Features.Task.Queries.Requests;

namespace TaskManagement.Application.Features.Task.Queries.Handlers
{
    public class GetTaskDetailRequestHandler : IRequestHandler<GetTaskDetailRequest, TaskDTO>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskDetailRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskDTO> Handle(GetTaskDetailRequest request, CancellationToken cancellationToken)
        {
            var task = await _taskRepository.Get(request.ID);
            return _mapper.Map<TaskDTO>(task);
        }
    }
}
