using FlowTaskManager.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Models
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext dbContext;

        public TaskRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task)
        {
            if (task.Id == 0)
            {
                var result = await dbContext.ProgrammingTasks.AddAsync(task);
                await dbContext.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await dbContext.ProgrammingTasks.Include(programmingTask => programmingTask.User)
                .OrderByDescending(programmingTask => programmingTask.CreatedAt).ToListAsync();
        }
    }
}
