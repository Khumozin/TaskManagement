using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Task.Commands.Requests
{
    public class DeleteTaskCommand : IRequest
    {
        public Guid ID { get; set; }
    }
}
