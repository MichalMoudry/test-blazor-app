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
    public class FieldsController : ControllerBase
    {
        private readonly FieldOperations _fieldOperations;

        public FieldsController(AppDbContext appDbContext)
        {
            _fieldOperations = new FieldOperations(appDbContext);
        }

        /// <summary>
        /// Method for adding a list of new template fields.
        /// </summary>
        /// <param name="fields">A list of new template fields.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] List<Field> fields)
        {
            if (fields == null || fields.Count <= 0)
            {
                return BadRequest();
            }
            var res = await _fieldOperations.AddFields(fields);
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
        /// Method for removing a list of existing template fields.
        /// </summary>
        /// <param name="fields">A list of existing template fields.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] List<Field> fields)
        {
            if (fields == null || fields.Count <= 0)
            {
                return BadRequest();
            }
            var res = await _fieldOperations.RemoveFields(fields);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("identifying")]
        public IActionResult GetIdentifyingFields([FromBody] List<Template> templates)
        {
            if (templates == null)
            {
                return BadRequest();
            }
            var fields = _fieldOperations.GetIdentifyingFields(templates);
            if (fields != null || fields.Count > 0)
            {
                return Ok(fields);
            }
            else if (fields.Count == 0)
            {
                return BadRequest("There are no identifying fields.");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("nonidfields")]
        public IActionResult GetNonIdFields(List<ProcessedFile> processedFiles)
        {
            if (processedFiles == null)
            {
                return BadRequest();
            }
            var fields = _fieldOperations.GetNonIdentifyingFields(processedFiles);
            if (fields != null || fields.Count > 0)
            {
                return Ok(fields);
            }
            else if (fields.Count == 0)
            {
                return BadRequest("There are no fields.");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("template")]
        public IActionResult GetTemplateFields(string templateID)
        {
            if (string.IsNullOrEmpty(templateID))
            {
                return BadRequest();
            }
            var fields = _fieldOperations.GetTemplateFields(templateID);
            if (fields != null)
            {
                return Ok(fields);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFields([FromBody] List<Field> fields)
        {
            if (fields == null)
            {
                return BadRequest();
            }
            else if (fields.Count == 0)
            {
                return BadRequest("Input is empty.");
            }
            var res = await _fieldOperations.UpdateFields(fields);
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