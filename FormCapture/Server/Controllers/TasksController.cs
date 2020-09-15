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

        [HttpPost("")]
        public IActionResult GetUsersTasks([FromBody] string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return StatusCode(400);
            }
            List<AppWorkflowTask> tasks = _tasksOperations.GetUserTasks(userID).OrderBy(i => i.Added).ToList();
            if (tasks != null)
            {
                return Ok(tasks);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AppWorkflowTask task)
        {
            if (task == null)
            {
                return StatusCode(400);
            }
            bool res = await _tasksOperations.AddTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteTask(AppWorkflowTask task)
        {
            try
            {
                if (task == null)
                {
                    return StatusCode(400);
                }
                bool res = await _tasksOperations.RemoveTask(task);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (System.Exception)
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> EditTask([FromBody] AppWorkflowTask task)
        {
            if (task == null)
            {
                return StatusCode(400);
            }
            bool res = await _tasksOperations.EditTask(task);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet("")]
        public IActionResult GetTask([FromQuery] string taskID)
        {
            if (string.IsNullOrEmpty(taskID))
            {
                return StatusCode(400);
            }
            AppWorkflowTask tempTask = _tasksOperations.GetSpecificTask(taskID);
            if (tempTask != null)
            {
                return Ok(tempTask);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}