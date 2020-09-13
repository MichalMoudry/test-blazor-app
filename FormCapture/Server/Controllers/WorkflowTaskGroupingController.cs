﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.Controllers
{
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
        public async Task<IActionResult> Add([FromBody] Dictionary<string, List<AppWorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                if (taskGroupings == null || taskGroupings.Count <= 0)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowTaskGroupingOperations.AddGrouping(taskGroupings);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Method for obtaining list of group's task groupings.
        /// </summary>
        /// <param name="groupID">ID of the group.</param>
        /// <returns>List of group's task groupings (in JSON format) or 400 status code.</returns>
        [HttpPost("")]
        public IActionResult GetGroupTaskGroupings([FromBody] string groupID)
        {
            if (string.IsNullOrEmpty(groupID))
            {
                return StatusCode(400);
            }
            List<AppWorkflowTaskGrouping> taskGroupings = _workflowTaskGroupingOperations.GetGroupsTaskGroupings(groupID);
            if (taskGroupings != null)
            {
                return Ok(taskGroupings);
            }
            else
            {
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Method for deleting task grouping.
        /// </summary>
        /// <param name="taskGroupings">Dictionary of existing task groupings.</param>
        /// <returns>200 status code or 400 code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteGrouping([FromBody] Dictionary<string, List<AppWorkflowTaskGrouping>> taskGroupings)
        {
            try
            {
                if (taskGroupings == null || taskGroupings.Count <= 0)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowTaskGroupingOperations.RemoveGrouping(taskGroupings);
                if (res)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
        }
    }
}