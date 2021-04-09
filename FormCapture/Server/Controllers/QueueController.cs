using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormCapture.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class QueueController : ControllerBase
    {
        private readonly QueueOperations _queueOperations;

        public QueueController(AppDbContext dataContext)
        {
            _queueOperations = new QueueOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a new row to Queue database table.
        /// </summary>
        /// <param name="queue">Instance of a Queue class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Queue queue)
        {
            try
            {
                if (queue == null)
                {
                    return BadRequest();
                }
                var res = await _queueOperations.AddQueue(queue);
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
        /// Method for deleting a specific row from Queue database table.
        /// </summary>
        /// <param name="queue">Instance of a Queue class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Queue queue)
        {
            if (queue == null)
            {
                return BadRequest();
            }
            try
            {
                var res = await _queueOperations.DeleteQueue(queue);
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
        /// Method for obtaining list of Queue class instances with same value of AppID attribute.
        /// </summary>
        /// <param name="appID">ID of a capture application.</param>
        /// <returns>400 status code or 200 with requested data in JSON.</returns>
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

        /// <summary>
        /// Method for obtaining a single Queue class instance.
        /// </summary>
        /// <param name="id">ID of the queue.</param>
        /// <returns>400 status code or 200 with requested data in JSON.</returns>
        [HttpGet("queue")]
        public IActionResult GetQueue(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest();
            }
            var queue = _queueOperations.GetQueue(id);
            if (queue != null)
            {
                return Ok(queue);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for updating a row in Queue database table.
        /// </summary>
        /// <param name="queue">Instance of Queue class with new data, but same ID.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] Queue queue)
        {
            if (queue == null)
            {
                return BadRequest();
            }
            var res = await _queueOperations.EditQueue(queue);
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