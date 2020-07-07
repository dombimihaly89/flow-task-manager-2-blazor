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

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ProgrammingTask>>> GetProgrammingTasks(string page)
        {
            try
            {
                bool successfulParse = int.TryParse(page, out int pageNumber);
                if (!successfulParse)
                {
                    BadRequest("The value that passed to page is not a number");
                }
                return Ok(await taskService.GetProgrammingTasks(pageNumber, 3));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProgrammingTask>> GetProgrammingTask(int id)
        {
            try
            {
                var task = await taskService.GetProgrammingTask(id);
                if (task == null)
                {
                    return NotFound($"User with ID {id} is not present in the Database");
                }
                return task;
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

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProgrammingTask>> UpdateProgrammingTask(int id, ProgrammingTask task)
        {
            try
            {
                if (id != task.Id)
                {
                    BadRequest("Task ID mismatch.");
                }
                var updatedUser = await taskService.UpdateProgrammingTask(id, task);
                if (updatedUser == null)
                {
                    NotFound($"Task with ID {id} is not in the database");
                }
                return updatedUser;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProgrammingTask(int id)
        {
            try
            {
                var deletedTask = await taskService.DeleteProgrammingTask(id);
                if (deletedTask == null)
                {
                    return NotFound($"User with id {id} is not found in the database.");
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Task from the database.");
            }

        }
    }
}
