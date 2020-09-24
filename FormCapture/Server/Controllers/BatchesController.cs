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
    public class BatchesController : ControllerBase
    {
        private readonly BatchOperations _batchOperations;

        public BatchesController(AppDbContext dataContext)
        {
            _batchOperations = new BatchOperations(dataContext);
        }

        [HttpPost("User")]
        public IActionResult GetUsersBatches([FromBody] string userID)
        {
            if (string.IsNullOrEmpty(userID))
            {
                return BadRequest();
            }
            List<Batch> batches = _batchOperations.GetUsersBatches(userID);
            if (batches != null)
            {
                return Ok(batches);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("App")]
        public IActionResult GetAppsBatches([FromBody] string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            List<Batch> batches = _batchOperations.GetAppsBatches(appID);
            if (batches != null)
            {
                return Ok(batches);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return BadRequest();
            }
            bool res = await _batchOperations.AddNewBatch(batch);
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
        public async Task<IActionResult> Delete([FromBody] Batch batch)
        {
            if (batch == null)
            {
                return BadRequest();
            }
            bool res = await _batchOperations.DeleteBatch(batch);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("")]
        public IActionResult GetBatch([FromBody] string batchID)
        {
            if (string.IsNullOrEmpty(batchID))
            {
                return BadRequest();
            }
            Batch batch = _batchOperations.GetBatch(batchID);
            if (batch != null)
            {
                return Ok(batch);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}