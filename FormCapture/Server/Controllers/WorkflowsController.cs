using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        private readonly WorkflowOperations _workflowOperations;

        public WorkflowsController(AppDbContext dataContext)
        {
            _workflowOperations = new WorkflowOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a new app workflow.
        /// </summary>
        /// <param name="workflow">Instance of the AppWorkflow class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null || string.IsNullOrEmpty(workflow.Name))
                {
                    return StatusCode(400);
                }
                bool res = await _workflowOperations.AddWorkflow(workflow);
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
        /// Method for obtaining list of user's workflows.
        /// </summary>
        /// <param name="userID">ID of a user.</param>
        /// <returns>List of user's workflows (in JSON format) or 400 status code.</returns>
        [HttpPost("")]
        public IActionResult GetUsersWorkflows([FromBody] string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return StatusCode(400);
            }
            List<Workflow> workflows = _workflowOperations.GetUsersAppWorkflows(userID)
                .OrderBy(i => i.Added)
                .ToList();
            if (workflows != null)
            {
                return Ok(workflows);
            }
            else
            {
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Method for deleting an app workflow.
        /// </summary>
        /// <param name="app">An app workflow.</param>
        /// <returns>200 status code or 400 code.<returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteWorkflow([FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null)
                {
                    return StatusCode(400);
                }
                bool res = await _workflowOperations.DeleteWorkflow(workflow);
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
        /// Method that is used to obtain data about an app workflow.
        /// </summary>
        /// <param name="appID">ID of an app workflow.</param>
        /// <returns>If ID is not supplied or workflow was not found then 400 status is returned. Else data is returned as JSON.</returns>
        [HttpPost("Get")]
        public IActionResult GetAppWorkflow([FromBody] string workflowID)
        {
            if (string.IsNullOrEmpty(workflowID))
            {
                return StatusCode(400);
            }
            Workflow workflow = _workflowOperations.GetAppWorkflow(workflowID);
            if (workflow != null)
            {
                return Ok(workflow);
            }
            else
            {
                return StatusCode(400);
            }
        }

        /// <summary>
        /// Method for handling of app workflow editing.
        /// </summary>
        /// <param name="app">Instance of the AppWorkflow class with new data.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Edit")]
        public async Task<IActionResult> EditWorkflow([FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null || string.IsNullOrEmpty(workflow.Name))
                {
                    return StatusCode(400);
                }
                bool res = await _workflowOperations.EditWorkflow(workflow);
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