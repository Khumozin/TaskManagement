using MediatR;
using TaskManagement.Application.DTOs.Task;

namespace TaskManagement.Application.Features.Task.Queries.Requests
{
    public class GetTaskListRequest : IRequest<List<TaskDTO>>
    {
    }
}
