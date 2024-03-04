using AutoMapper;
using MediatR;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.DTOs.Task;
using TaskManagement.Application.Features.Task.Queries.Requests;

namespace TaskManagement.Application.Features.Task.Queries.Handlers
{
    public class GetTaskListRequestHandler : IRequestHandler<GetTaskListRequest, List<TaskDTO>>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public GetTaskListRequestHandler(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<TaskDTO>> Handle(GetTaskListRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _taskRepository.GetAll();

            return _mapper.Map<List<TaskDTO>>(tasks);
        }
    }
}
