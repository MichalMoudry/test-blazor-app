using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin, User")]
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly QueueOperations _queueOperations;

        public QueueController(AppDbContext dataContext)
        {
            _queueOperations = new QueueOperations(dataContext);
        }

        [HttpGet("{appID}")]
        public IActionResult GetAppsQueue(string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            List<Queue> queues = _queueOperations.GetAppsQueues(appID).OrderBy(i => i.Added).ToList();
            if (queues != null)
            {
                return Ok(queues);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("queue")]
        public IActionResult GetQueue(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            Queue queue = _queueOperations.GetQueue(id);
            if (queue != null)
            {
                return Ok(queue);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Queue queue)
        {
            try
            {
                if (queue == null)
                {
                    return BadRequest();
                }
                string userID = queue.UserID;
                bool res = await _queueOperations.AddQueue(queue);
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

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Queue queue)
        {
            if (queue == null)
            {
                return BadRequest();
            }
            try
            {
                bool res = await _queueOperations.DeleteQueue(queue);
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
    }
}