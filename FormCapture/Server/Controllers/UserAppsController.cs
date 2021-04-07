using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAppsController : ControllerBase
    {
        private readonly UserAppsOperations _userAppsOperations;

        public UserAppsController(AppDbContext dbContext)
        {
            _userAppsOperations = new UserAppsOperations(dbContext);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] List<UserApps> apps)
        {
            if (apps == null)
            {
                return BadRequest();
            }
            var res = await _userAppsOperations.AddUserApps(apps);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{appID}")]
        public IActionResult GetAppUsers(string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            var appIds = _userAppsOperations.GetAppUserIDs(appID);
            if (appIds != null)
            {
                return Ok(appIds);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("user/{userID}")]
        public IActionResult GetUserApps(string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return BadRequest();
            }
            var appIds = _userAppsOperations.GetUserAppIDs(userID);
            if (appIds != null)
            {
                return Ok(appIds);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Remove([FromBody] List<UserApps> apps)
        {
            if (apps == null)
            {
                return BadRequest();
            }
            var res = await _userAppsOperations.RemoveUserApps(apps);
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