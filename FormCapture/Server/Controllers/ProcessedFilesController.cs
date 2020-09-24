using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;
using Newtonsoft.Json;

namespace FormCapture.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessedFilesController : ControllerBase
    {
        private readonly ProcessedFileOperations _processedFileOperations;

        public ProcessedFilesController(AppDbContext dataContext)
        {
            _processedFileOperations = new ProcessedFileOperations(dataContext);
        }

        /// <summary>
        /// Method for obtaining list of files in a specific batch.
        /// </summary>
        /// <param name="batchID">ID of the specific batch.</param>
        /// <returns>List of files in a specific batch (in JSON format) or 400 status code.</returns>
        [HttpPost("")]
        public IActionResult GetBatchFiles([FromBody] string batchID)
        {
            List<ProcessedFile> files = _processedFileOperations.GetBatchFiles(batchID).OrderBy(i => i.Added).ToList();
            if (files != null)
            {
                return Ok(files);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for adding a new processed file.
        /// </summary>
        /// <param name="files">List of processed files.</param>
        /// <returns>200 or 400 status code.</returns>    
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] List<ProcessedFile> files)
        {
            if (files == null)
            {
                return BadRequest();
            }
            bool res = await _processedFileOperations.AddNewFile(files);
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
        /// Method for removing a processed file.
        /// </summary>
        /// <param name="data">List of processed files.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] List<ProcessedFile> files)
        {
            if (files == null)
            {
                return BadRequest();
            }
            bool res = await _processedFileOperations.DeleteFile(files);
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