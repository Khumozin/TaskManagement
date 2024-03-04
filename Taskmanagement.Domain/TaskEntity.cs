using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain.Common;

namespace Taskmanagement.Domain
{
    public class TaskEntity : BaseDomainEntity
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}
