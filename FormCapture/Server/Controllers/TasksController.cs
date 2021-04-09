using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksOperations _tasksOperations;

        public TasksController(AppDbContext context)
        {
            _tasksOperations = new TasksOperations(context);
        }

        /// <summary>
        /// Method for adding a new row to WorkflowTasks database table.
        /// </summary>
        /// <param name="task">Instance of Workflow task class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] WorkflowTask task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            var res = await _tasksOperations.AddTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for deleting a row in WorkflowTasks database table.
        /// </summary>
        /// <param name="task">Instance of Workflow task class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteTask(WorkflowTask task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest();
                }
                var res = await _tasksOperations.RemoveTask(task);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for updating a in to WorkflowTasks database table.
        /// </summary>
        /// <param name="task">Instance of Workflow task class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("update")]
        public async Task<IActionResult> EditTask([FromBody] WorkflowTask task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            var res = await _tasksOperations.EditTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for obtaining a single instance of WorkflowTask class.
        /// </summary>
        /// <param name="taskID">ID of the task.</param>
        /// <returns>400 status code or 200 with requested data as JSON.</returns>
        [HttpGet("get/{taskID}")]
        public IActionResult GetTask(string taskID)
        {
            if (string.IsNullOrEmpty(taskID))
            {
                return BadRequest();
            }
            var tempTask = _tasksOperations.GetSpecificTask(taskID);
            if (tempTask != null)
            {
                return Ok(tempTask);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for obtaining list of tasks that are refrenced in a list of WorkflowTaskGroupings instances.
        /// </summary>
        /// <param name="groupings">List of WorkflowTaskGroupings instances.</param>
        /// <returns>400 status code or 200 with requested data as JSON.</returns>
        [HttpPost("grouped")]
        public IActionResult GetTasksFromGrouping([FromBody] List<WorkflowTaskGrouping> groupings)
        {
            if (groupings == null)
            {
                return BadRequest();
            }
            var tasks = _tasksOperations.GetTasksFromGrouping(groupings);
            if (tasks.Count > 0)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest("There are no tasks.");
            }
        }

        /// <summary>
        /// Method for obtaining a list of user's tasks.
        /// </summary>
        /// <param name="userID">ID of the user.</param>
        /// <returns>400 status code or 200 with requested data as JSON.</returns>
        [HttpGet("{userID}")]
        public IActionResult GetUsersTasks(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return BadRequest();
            }
            var tasks = _tasksOperations.GetUserTasks(userID).OrderBy(i => i.Added).ToList();
            if (tasks != null)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}