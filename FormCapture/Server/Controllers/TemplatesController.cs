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
    public class TemplatesController : ControllerBase
    {
        private readonly TemplateOperations _templateOperations;

        public TemplatesController(AppDbContext dataContext)
        {
            _templateOperations = new TemplateOperations(dataContext);
        }

        /// <summary>
        /// Method for adding a new document template.
        /// </summary>
        /// <param name="template">Instance of the Template class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Template template)
        {
            if (template == null)
            {
                return BadRequest();
            }
            var res = await _templateOperations.AddTemplate(template);
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
        /// Method for deleting an existing document template.
        /// </summary>
        /// <param name="template">Instance of the Template class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] Template template)
        {
            if (template == null)
            {
                return BadRequest();
            }
            var res = await _templateOperations.DeleteTemplate(template);
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
        /// Method for deleting existing document templates.
        /// </summary>
        /// <param name="template">List of Template class instances.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPost("deletemultiple")]
        public async Task<IActionResult> DeleteMultiple([FromBody] List<Template> templates)
        {
            if (templates == null)
            {
                return BadRequest();
            }
            var res = await _templateOperations.DeleteTemplates(templates);
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
        /// Method for obtaining a list of document templates inside a capture application.
        /// </summary>
        /// <param name="appID">ID of the application.</param>
        /// <returns>200 status code with requested data in JSON format or 400 status code.</returns>
        [HttpGet("{appID}")]
        public IActionResult GetAppTemplates(string appID)
        {
            if (string.IsNullOrEmpty(appID))
            {
                return BadRequest();
            }
            var templates = _templateOperations.GetAppsTemplates(appID);
            if (templates != null)
            {
                return Ok(templates);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for obtaining a document template.
        /// </summary>
        /// <param name="templateID">ID of the template.</param>
        /// <returns>200 status code with requested data in JSON format or 400 status code.</returns>
        [HttpGet("template")]
        public IActionResult GetTemplate(string templateID)
        {
            if (string.IsNullOrEmpty(templateID))
            {
                return BadRequest();
            }
            var template = _templateOperations.GetTemplate(templateID);
            if (template != null)
            {
                return Ok(template);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Method for updating a row in Templates database table.
        /// </summary>
        /// <param name="template">Instnace of the Template class.</param>
        /// <returns>200 or 400 status code.</returns>
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] Template template)
        {
            if (template == null)
            {
                return BadRequest();
            }
            var res = await _templateOperations.UpdateTemplate(template);
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