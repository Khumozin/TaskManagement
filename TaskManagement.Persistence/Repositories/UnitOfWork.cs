﻿using TaskManagement.Application.Contracts.Persistence;

namespace TaskManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskManagementDbContext _context;
        private ITaskRepository _taskRepository;

        public UnitOfWork(TaskManagementDbContext context, ITaskRepository taskRepository)
        {
            _context = context;
            _taskRepository = taskRepository;
        }

        public ITaskRepository TaskRepository =>
            _taskRepository ??= new TaskRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
