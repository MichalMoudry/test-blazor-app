using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksOperations _tasksOperations;

        public TasksController(AppDbContext context)
        {
            _tasksOperations = new TasksOperations(context);
        }

        [HttpGet("{userID}")]
        public IActionResult GetUsersTasks(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return BadRequest();
            }
            List<WorkflowTask> tasks = _tasksOperations.GetUserTasks(userID).OrderBy(i => i.Added).ToList();
            if (tasks != null)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] WorkflowTask task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            bool res = await _tasksOperations.AddTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteTask(WorkflowTask task)
        {
            try
            {
                if (task == null)
                {
                    return BadRequest();
                }
                bool res = await _tasksOperations.RemoveTask(task);
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

        [HttpPost("Edit")]
        public async Task<IActionResult> EditTask([FromBody] WorkflowTask task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            bool res = await _tasksOperations.EditTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("task")]
        public IActionResult GetTask([FromQuery] string taskID)
        {
            if (string.IsNullOrEmpty(taskID))
            {
                return BadRequest();
            }
            WorkflowTask tempTask = _tasksOperations.GetSpecificTask(taskID);
            if (tempTask != null)
            {
                return Ok(tempTask);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("grouped")]
        public IActionResult GetTasksFromGrouping([FromBody] List<WorkflowTaskGrouping> groupings)
        {
            if (groupings == null)
            {
                return BadRequest();
            }
            List<WorkflowTask> tasks = _tasksOperations.GetTasksFromGrouping(groupings);
            if (tasks.Count > 0)
            {
                return Ok(tasks);
            }
            else
            {
                return BadRequest("There are no tasks.");
            }
        }
    }
}