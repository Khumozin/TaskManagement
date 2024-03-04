using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.DTOs.Common;

namespace TaskManagement.Application.DTOs.Task
{
    public class ChangeTaskCompleteStatusDTO : BaseDTO
    {
        public bool? Complete { get; set; }
    }
}
