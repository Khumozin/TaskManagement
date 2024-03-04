using MediatR;
using TaskManagement.Application.DTOs.Task;

namespace TaskManagement.Application.Features.Task.Queries.Requests
{
    public class GetTaskDetailRequest : IRequest<TaskDTO>
    {
        public Guid ID { get; set; }
    }
}
