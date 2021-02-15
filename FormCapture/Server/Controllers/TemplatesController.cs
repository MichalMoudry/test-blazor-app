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
    public class TemplatesController : ControllerBase
    {
        private readonly TemplateOperations _templateOperations;

        public TemplatesController(AppDbContext dataContext)
        {
            _templateOperations = new TemplateOperations(dataContext);
        }

        [HttpPost("")]
        public IActionResult GetApps([FromBody] string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            List<Template> templates = _templateOperations.GetAppsTemplates(appID);
            if (templates != null)
            {
                return Ok(templates);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Template template)
        {
            if (template == null)
            {
                return BadRequest();
            }
            bool res = await _templateOperations.AddTemplate(template);
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
        public async Task<IActionResult> Delete([FromBody] Template template)
        {
            if (template == null)
            {
                return BadRequest();
            }
            bool res = await _templateOperations.DeleteTemplate(template);
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