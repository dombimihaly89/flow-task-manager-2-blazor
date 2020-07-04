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
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task)
        {
            return await taskRepository.CreateProgrammingTask(task);
        }

        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await taskRepository.GetProgrammingTasks();
        }
    }
}
