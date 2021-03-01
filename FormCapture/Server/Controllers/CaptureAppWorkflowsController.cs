using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("{appID}")]
        public IActionResult GetWorkflowIds(string appID)
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