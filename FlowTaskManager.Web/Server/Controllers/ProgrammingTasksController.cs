using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowTaskManager.Web.Server.Services;
using FlowTaskManager.Web.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowTaskManager.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTasksController : ControllerBase
    {
        private readonly IProgrammingTaskService programmingTaskService;

        public ProgrammingTasksController(IProgrammingTaskService programmingTaskService)
        {
            this.programmingTaskService = programmingTaskService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProgrammingTask>> GetProgrammingTasks()
        {
            return await programmingTaskService.GetProgrammingTasks();
        }
    }
}
