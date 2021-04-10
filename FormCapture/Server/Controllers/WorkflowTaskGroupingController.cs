using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowTaskGroupingController : ControllerBase
    {
        private readonly WorkflowTaskGroupingOperations _workflowTaskGroupingOperations;

        public WorkflowTaskGroupingController(AppDbContext dataContext)
        {
            _workflowTaskGroupingOperations = new WorkflowTaskGroupingOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a new task grouping.
        /// </summary>
        /// <param name="taskGroupings">Dictionary of new task groupings.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Dictionary<string, List<WorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                if (taskGroupings == null || taskGroupings.Count <= 0)
                {
                    return BadRequest();
                }
                bool res = await _workflowTaskGroupingOperations.AddGrouping(taskGroupings);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for deleting task grouping.
        /// </summary>
        /// <param name="taskID">ID of a task.</param>
        /// <returns>200 status code or 400 code.</returns>
        [HttpDelete("{taskID}")]
        public async Task<IActionResult> DeleteGrouping(string taskID)
        {
            try
            {
                if (string.IsNullOrEmpty(taskID))
                {
                    return BadRequest();
                }
                bool res = await _workflowTaskGroupingOperations.RemoveGrouping(taskID);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for obtaining list of workflow's task groupings.
        /// </summary>
        /// <param name="workflowID">ID of the workflow.</param>
        /// <returns>List of group's task groupings (in JSON format) or 400 status code.</returns>
        [HttpGet("{workflowID}")]
        public IActionResult GetGroupTaskGroupings(string workflowID)
        {
            if (string.IsNullOrEmpty(workflowID))
            {
                return BadRequest();
            }
            var taskGroupings = _workflowTaskGroupingOperations.GetWorkflowTaskGroupings(workflowID);
            if (taskGroupings != null)
            {
                return Ok(taskGroupings);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}