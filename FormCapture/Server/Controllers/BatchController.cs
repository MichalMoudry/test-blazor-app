using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;

namespace FormCapture.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchController : ControllerBase
    {
        private readonly BatchOperations _batchOperations;

        public BatchController(AppDbContext dataContext)
        {
            _batchOperations = new BatchOperations(dataContext);
        }

        [HttpPost("User")]
        public IActionResult GetUsersBatches([FromBody] string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return StatusCode(400);
            }
            List<Batch> batches = _batchOperations.GetUsersBatches(userID);
            if (batches != null)
            {
                return Ok(batches);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("App")]
        public IActionResult GetAppsBatches([FromBody] string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return StatusCode(400);
            }
            List<Batch> batches = _batchOperations.GetAppsBatches(appID);
            if (batches != null)
            {
                return Ok(batches);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return StatusCode(400);
            }
            bool res = await _batchOperations.AddNewBatch(batch);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return StatusCode(400);
            }
            bool res = await _batchOperations.DeleteBatch(batch);
            if (res)
            {
                return Ok();
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpPost("")]
        public IActionResult GetBatch([FromBody] string batchID)
        {
            if (string.IsNullOrEmpty(batchID))
            {
                return StatusCode(400);
            }
            Batch batch = _batchOperations.GetBatch(batchID);
            if (batch != null)
            {
                return Ok(batch);
            }
            else
            {
                return StatusCode(400);
            }
        }
    }
}