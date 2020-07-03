using FlowTaskManager.Web.Server.Models;
using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository programmingTaskRepository;

        public TaskService(ITaskRepository programmingTaskRepository)
        {
            this.programmingTaskRepository = programmingTaskRepository;
        }
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await programmingTaskRepository.GetProgrammingTasks();
        }
    }
}
