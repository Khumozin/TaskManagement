using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taskmanagement.Domain;

namespace TaskManagement.Application.Contracts.Persistence
{
    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
    }
}
