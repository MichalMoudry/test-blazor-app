using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CaptureAppWorkflowsController : ControllerBase
    {
        private readonly CaptureAppWorkflowsOperations _captureApplicationsOps;

        public CaptureAppWorkflowsController(AppDbContext appDbContext)
        {
            _captureApplicationsOps = new CaptureAppWorkflowsOperations(appDbContext);
        }

        [HttpPost("")]
        public IActionResult GetWorkflowIds([FromBody] string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            List<CaptureAppWorkflows> appWorkflows = _captureApplicationsOps.GetCaptureAppWorkflows(appID);
            if (appWorkflows != null)
            {
                return Ok(appWorkflows);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] List<CaptureAppWorkflows> captureAppWorkflows)
        {
            if (captureAppWorkflows == null)
            {
                return BadRequest();
            }
            if (captureAppWorkflows.Count <= 0)
            {
                return BadRequest("Entered list of entites is empty.");
            }
            bool res = await _captureApplicationsOps.AddCaptureAppWorkflow(captureAppWorkflows);
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
        public async Task<IActionResult> Remove([FromBody] List<CaptureAppWorkflows> captureAppWorkflows)
        {
            if (captureAppWorkflows == null)
            {
                return BadRequest();
            }
            if (captureAppWorkflows.Count <= 0)
            {
                return BadRequest("Entered list of entites is empty.");
            }
            bool res = await _captureApplicationsOps.RemoveCaptureAppWorkflow(captureAppWorkflows);
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