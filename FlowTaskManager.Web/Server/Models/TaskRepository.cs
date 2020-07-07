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

        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks(int page, int tasksOnPage)
        {
            int allTasks = await CountAllTasks();
            return await dbContext.ProgrammingTasks.Include(programmingTask => programmingTask.User)
                .OrderByDescending(programmingTask => programmingTask.CreatedAt)
                .Skip((page - 1) * tasksOnPage)
                .Take(tasksOnPage)
                .ToListAsync();
        }

        public async Task<ProgrammingTask> GetProgrammingTask(int id)
        {
            return await dbContext.ProgrammingTasks.FirstOrDefaultAsync(task => task.Id == id);
        }

        public async Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task)
        {
            var result = await dbContext.ProgrammingTasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProgrammingTask> UpdateProgrammingTask(ProgrammingTask task)
        {
            await dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<ProgrammingTask> DeleteProgrammingTask(int id)
        {
            var taskToDelete = await GetProgrammingTask(id);
            if (taskToDelete != null)
            {
                dbContext.ProgrammingTasks.Remove(taskToDelete);
                await dbContext.SaveChangesAsync();
            }
            return taskToDelete;
        }

        public async Task<int> CountAllTasks()
        {
            return await dbContext.ProgrammingTasks.CountAsync();
        }
    }
}
