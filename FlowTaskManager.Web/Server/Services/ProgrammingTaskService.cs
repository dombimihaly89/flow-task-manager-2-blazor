using FlowTaskManager.Web.Server.Models;
using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Services
{
    public class ProgrammingTaskService : IProgrammingTaskService
    {
        private readonly IProgrammingTaskRepository programmingTaskRepository;

        public ProgrammingTaskService(IProgrammingTaskRepository programmingTaskRepository)
        {
            this.programmingTaskRepository = programmingTaskRepository;
        }
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await programmingTaskRepository.GetProgrammingTasks();
        }
    }
}
