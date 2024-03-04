using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Common;

namespace TaskManagement.Application.DTOs.Task
{
    public class UpdateTaskDTO : BaseDTO, ITaskDTO
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
