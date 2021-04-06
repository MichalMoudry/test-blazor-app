using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaptureAppsController : ControllerBase
    {
        private readonly CaptureApplicationsOps _captureApplicationsOps;

        public CaptureAppsController(AppDbContext context)
        {
            _captureApplicationsOps = new CaptureApplicationsOps(context);
        }

        /// <summary>
        /// Method for adding a new capture application.
        /// </summary>
        /// <param name="captureApplication">Instance of the CaptureApplication class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CaptureApplication captureApplication)
        {
            if (captureApplication == null)
            {
                return BadRequest();
            }
            bool res = await _captureApplicationsOps.AddNewApplication(captureApplication);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for deleting a capture app.
        /// </summary>
        /// <param name="app">A capture app.</param>
        /// <returns>200 status code or 400 code.<returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteApp([FromBody] CaptureApplication app)
        {
            if (app == null)
            {
                return BadRequest();
            }
            bool res = await _captureApplicationsOps.DeleteApp(app);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for handling of app editing.
        /// </summary>
        /// <param name="app">Instance of the CaptureApplication class with new data.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Edit")]
        public async Task<IActionResult> EditApp([FromBody] CaptureApplication app)
        {
            if (app == null)
            {
                return BadRequest();
            }
            bool res = await _captureApplicationsOps.EditApplication(app);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method that is used to obtain data about a capture application.
        /// </summary>
        /// <param name="appID">ID of the specific app.</param>
        /// <returns>If ID is not supplied or app was not found then 400 status is returned. Else data is returned as JSON.</returns>
        [HttpPost("Get")]
        public IActionResult GetApp([FromBody] string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            CaptureApplication tempApp = _captureApplicationsOps.GetCaptureApplication(appID);
            if (tempApp == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(tempApp);
            }
        }

        /// <summary>
        /// Method for obtaining list of user's apps.
        /// </summary>
        /// <param name="userID">ID of a user.</param>
        /// <returns>List of user's apps (in JSON format) or 400 status code.</returns>
        [HttpPost("")]
        public IActionResult GetUsersApps([FromBody] string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return BadRequest();
            }
            List<CaptureApplication> captureApplications = _captureApplicationsOps.GetUsersCaptureApplications(userID)
                .OrderBy(i => i.Added)
                .ToList();
            if (captureApplications != null)
            {
                return Ok(captureApplications);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}