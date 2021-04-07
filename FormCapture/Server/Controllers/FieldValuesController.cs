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