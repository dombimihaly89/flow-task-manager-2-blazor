using FlowTaskManager.Web.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Models
{
    public class ProgrammingTaskRepository : IProgrammingTaskRepository
    {
        private readonly AppDbContext dbContext;

        public ProgrammingTaskRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await dbContext.ProgrammingTasks.ToListAsync();
        }
    }
}
