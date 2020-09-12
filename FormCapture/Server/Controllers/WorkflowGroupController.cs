using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using System.Text.RegularExpressions;

namespace FormCapture.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowGroupController : ControllerBase
    {
        private readonly WorkflowGroupOperations _workflowGroupOperations;

        public WorkflowGroupController(AppDbContext dataContext)
        {
            _workflowGroupOperations = new WorkflowGroupOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a new app workflow group.
        /// </summary>
        /// <param name="groups">List of new app workflow groups.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] List<AppWorkflowGroup> groups)
        {
            try
            {
                if (groups == null || groups.Count <= 0)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowGroupOperations.AddGroup(groups);
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
        /// Method for obtaining list of groups in a specific workflow.
        /// </summary>
        /// <param name="workflowID">ID of the workflow.</param>
        /// <returns>List of groups in a specific workflow (in JSON format) or 400 status code.</returns>
        [HttpPost("")]
        public IActionResult GetWorkflowGroups([FromBody] string workflowID)
        {
            if (string.IsNullOrEmpty(workflowID))
            {
                return StatusCode(400);
            }
            List<AppWorkflowGroup> groups = _workflowGroupOperations.GetWorkflowGroups(workflowID)
                .OrderBy(i => i.Added)
                .ToList();
            if (groups == null)
            {
                return Ok(groups);
            }
            else
            {
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Method for removing an app workflow group.
        /// </summary>
        /// <param name="groups">List of app workflow groups.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteGroup([FromBody] List<AppWorkflowGroup> groups)
        {
            try
            {
                if (groups == null || groups.Count <= 0)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowGroupOperations.RemoveGroup(groups);
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
        /// Method for editing an app workflow group.
        /// </summary>
        /// <param name="groups">New data.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Edit")]
        public async Task<IActionResult> EditGroup([FromBody] List<AppWorkflowGroup> groups)
        {
            try
            {
                if (groups == null || groups.Count <= 0)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowGroupOperations.EditGroup(groups);
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