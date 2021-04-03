using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FormCapture.Server.DataAccess;
using Microsoft.AspNetCore.Mvc;
using FormCapture.Shared.DbModels;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FormCapture.Server.Controllers
{
    [Authorize(Roles = "Admin, Workflow admin, User")]
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
        public async Task<IActionResult> DeleteFieldValues([FromBody] List<FieldValue> fieldValues)
        {
            if (fieldValues == null || fieldValues.Count == 0)
            {
                return BadRequest();
            }
            var res = await _fieldValuesOperations.RemoveRangeOfFieldValues(fieldValues);
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