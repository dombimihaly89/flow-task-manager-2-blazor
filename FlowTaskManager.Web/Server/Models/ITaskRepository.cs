using FlowTaskManager.Web.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowTaskManager.Web.Server.Models
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks(int page);
        Task<ProgrammingTask> GetProgrammingTask(int id);
        Task<ProgrammingTask> CreateProgrammingTask(ProgrammingTask task);
        Task<ProgrammingTask> UpdateProgrammingTask(ProgrammingTask task);
        Task<ProgrammingTask> DeleteProgrammingTask(int id);
        
    }
}
