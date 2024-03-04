using Microsoft.EntityFrameworkCore;
using Taskmanagement.Domain;
using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Repositories
{
    public class TaskRepository : GenericRepository<TaskEntity>, ITaskRepository
    {
        private readonly TaskManagementDbContext _context;

        public TaskRepository(TaskManagementDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task ChangeCompleteStatus(TaskEntity entity, bool? CompleteStatus)
        {
            entity.Completed = (bool)CompleteStatus;
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
