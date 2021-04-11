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
            if (fields == null)
            {
                return BadRequest();
            }
            else if (fields.Count <= 0)
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

        [HttpPost("deletewithtemplates")]
        public async Task<IActionResult> DeleteWithTemplates([FromBody] List<Template> templates)
        {
            if (templates == null)
            {
                return BadRequest();
            }
            else if (templates.Count <= 0)
            {
                return BadRequest();
            }
            var res = await _fieldOperations.RemoveFields(templates);
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
        /// Method for obtaining list of identifying fields for each template. Used during queue processing.
        /// </summary>
        /// <param name="templates">List of Template class instances.</param>
        /// <returns>400 status code or 200 with requested data.</returns>
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

        /// <summary>
        /// Method for obtaining list of non identifying fields for each processed file. Used during queue processing.
        /// </summary>
        /// <param name="processedFiles">List of ProcessedFile class instances.</param>
        /// <returns>400 status code or 200 with requested data.</returns>
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

        /// <summary>
        /// Method for obtaining list of fields for a specific document template.
        /// </summary>
        /// <param name="templateID">ID of the document template.</param>
        /// <returns>400 status code or 200 with requested data in JSON format.</returns>
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

        /// <summary>
        /// Method for updating multiple rows in Fields database table.
        /// </summary>
        /// <param name="fields">List of Field class instances.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateFields([FromBody] List<Field> fields)
        {
            if (fields == null)
            {
                return BadRequest();
            }
            if (fields.Count == 0)
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