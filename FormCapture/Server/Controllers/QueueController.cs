using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;
using System.Linq;

namespace FormCapture.Server.Controllers
{
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
                return StatusCode(400);
            }
            List<Queue> queues = _queueOperations.GetAppsQueues(appID).OrderBy(i => i.Added).ToList();
            if (queues != null)
            {
                return Ok(queues);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Queue queue)
        {
            try
            {
                if (queue == null)
                {
                    return StatusCode(400);
                }
                string userID = queue.UserID;
                bool res = await _queueOperations.AddQueue(queue);
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

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Queue queue)
        {
            if (queue == null)
            {
                return StatusCode(400);
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