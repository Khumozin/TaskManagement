using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Task;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Task.Commands.Requests
{
    public class CreateTaskCommand : IRequest<BaseCommandResponse>
    {
        public CreateTaskDTO taskDTO {  get; set; }
    }
}
