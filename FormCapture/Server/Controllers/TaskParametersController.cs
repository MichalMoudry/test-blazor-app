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
    public class TaskParametersController : ControllerBase
    {
        private readonly WorkflowTaskParameterOperations _workflowTaskParameterOperations;

        public TaskParametersController(AppDbContext dbContext)
        {
            _workflowTaskParameterOperations = new WorkflowTaskParameterOperations(dbContext);
        }

        [HttpGet("{taskID}")]
        public IActionResult GetTaskParameters(string taskID)
        {
            if (string.IsNullOrEmpty(taskID))
            {
                return BadRequest();
            }

            var parameters = _workflowTaskParameterOperations.GetWorkflowTaskParameters(taskID);

            if (parameters != null)
            {
                return Ok(parameters);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddParameters([FromBody] List<WorkflowTaskParameter> parameters)
        {
            if (parameters == null || parameters.Count <= 0)
            {
                return BadRequest();
            }

            var res = await _workflowTaskParameterOperations.AddParameters(parameters);

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveParameters([FromBody] List<WorkflowTaskParameter> parameters)
        {
            if (parameters == null || parameters.Count <= 0)
            {
                return BadRequest();
            }

            var res = await _workflowTaskParameterOperations.RemoveParameters(parameters);

            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
