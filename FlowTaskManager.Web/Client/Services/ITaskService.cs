using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Client.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks();
        Task<ProgrammingTask> GetProgrammingTask(int id);
        Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task);
        Task<ProgrammingTask> UpdateProgrammingTask(int id, ProgrammingTask task);
        Task DeleteProgrammingTask(int id);
    }
}
