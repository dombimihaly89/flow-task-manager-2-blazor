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
    public class TasksController : ControllerBase
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgrammingTask>>> GetProgrammingTasks()
        {
            try
            {
                return Ok(await taskService.GetProgrammingTasks());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProgrammingTask>> CreateProgrammingTask(ProgrammingTask task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest("Task cannot be null");
                }
                var createdTask = await taskService.CreateProgrammingTask(task);
                if (createdTask != null)
                {
                    return CreatedAtAction(nameof(CreateProgrammingTask), new { taskId = createdTask.Id }, createdTask);
                }
                return BadRequest("Couldn't save the employee becuse it already had an ID.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }
    }
}
