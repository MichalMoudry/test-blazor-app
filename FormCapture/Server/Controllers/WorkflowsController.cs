using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
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
                    return BadRequest();
                }
                var res = await _workflowOperations.AddWorkflow(workflow);
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
                    return BadRequest();
                }
                var res = await _workflowOperations.DeleteWorkflow(workflow);
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
        /// Method for handling of app workflow editing.
        /// </summary>
        /// <param name="app">Instance of the AppWorkflow class with new data.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPut("update")]
        public async Task<IActionResult> EditWorkflow([FromBody] Workflow workflow)
        {
            try
            {
                if (workflow == null || string.IsNullOrEmpty(workflow.Name))
                {
                    return BadRequest();
                }
                var res = await _workflowOperations.EditWorkflow(workflow);
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
        /// Method that is used to obtain data about an app workflow.
        /// </summary>
        /// <param name="appID">ID of an app workflow.</param>
        /// <returns>If ID is not supplied or workflow was not found then 400 status is returned. Else data is returned as JSON.</returns>
        [HttpGet("get/{workflowID}")]
        public IActionResult GetAppWorkflow(string workflowID)
        {
            if (string.IsNullOrEmpty(workflowID))
            {
                return BadRequest();
            }
            var workflow = _workflowOperations.GetAppWorkflow(workflowID);
            if (workflow != null)
            {
                return Ok(workflow);
            }
            else
            {
                return BadRequest();
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
                return BadRequest();
            }
            var workflows = _workflowOperations.GetUsersAppWorkflows(userID)
                .OrderBy(i => i.Added)
                .ToList();
            if (workflows != null)
            {
                return Ok(workflows);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}