using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Task;

namespace TaskManagement.Application.Features.Task.Commands.Requests
{
    public class UpdateTaskCommand : IRequest<Unit>
    {
        public Guid ID { get; set; }
        public UpdateTaskDTO TaskDTO { get; set; }
        public ChangeTaskCompleteStatusDTO ChangeTaskCompleteStatus { get; set; }
    }
}
