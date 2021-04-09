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
    public class FieldValuesController : ControllerBase
    {
        private readonly FieldValuesOperations _fieldValuesOperations;

        public FieldValuesController(AppDbContext dataContext)
        {
            _fieldValuesOperations = new FieldValuesOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a list of new field values.
        /// </summary>
        /// <param name="fieldValues">A list of new field values.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddFieldValues([FromBody] List<FieldValue> fieldValues)
        {
            if (fieldValues == null || fieldValues.Count == 0)
            {
                return BadRequest();
            }
            var res = await _fieldValuesOperations.AddNewFieldValues(fieldValues);
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
        /// Method for removing range of field values based on their queue association.
        /// </summary>
        /// <param name="queueID">ID of a specific queue.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteFieldValues([FromBody] string queueID)
        {
            if (string.IsNullOrEmpty(queueID))
            {
                return BadRequest();
            }
            var res = await _fieldValuesOperations.RemoveRangeOfFieldValues(queueID);
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
        /// Method for obtaining list of field values with same file ID.
        /// </summary>
        /// <param name="fileID">ID of a processed file.</param>
        /// <returns>400 status code or 200 with requested values in JSON data format.</returns>
        [HttpGet("{fileID}")]
        public IActionResult GetFilesValues(string fileID)
        {
            if (string.IsNullOrEmpty(fileID))
            {
                return BadRequest();
            }
            var values = _fieldValuesOperations.GetFilesFieldValues(fileID);
            if (values != null)
            {
                return Ok(values);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}