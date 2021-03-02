using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Server.DataAccess;
using FormCapture.Shared.DbModels;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin")]
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
    }
}