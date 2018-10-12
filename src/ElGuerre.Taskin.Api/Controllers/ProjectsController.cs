// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api.Services;
using ElGuerre.Taskin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Taskin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private const string SERVICE_NAME = "Project";
        private readonly IProjectService _service;
        private readonly ILogger _logger;

        public ProjectsController(IProjectService service, ILogger<ProjectsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        // [SwaggerOperation("GetAll" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<IEnumerable<ProjectModel>>> GetAll()
        {
            var response = await _service.GetAsync();
            return Ok(response);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        // [SwaggerOperation("Get" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProjectModel>> Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _service.GetAsync(id);
            return model == null
                ? (ActionResult<ProjectModel>)NotFound()
                : (ActionResult<ProjectModel>)Ok(model);
        }


        [HttpGet("{id}/tasks")]
        // [SwaggerOperation("GetTasksByProjectId", Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProjectModel>> GetTasksByProjectId([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _service.GetAsync(id);            
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project.Tasks);
        }

        // PUT: api/Project/5
        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        // [SwaggerOperation("Put" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<ProjectModel>> Put([FromRoute] int id, [FromBody] ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectModel.Id)
            {
                return BadRequest();
            }

            var model = await _service.GetAsync(id);
            if (model == null)
                return NotFound();

            model = await _service.UpdateAsync(projectModel);
            return Ok(model);
        }

        // POST: api/Project
        [HttpPost]
        // [ValidateAntiForgeryToken]
        // [SwaggerOperation("Post" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<ProjectModel>> Post([FromBody] ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _service.AddAsync(projectModel);
            return Ok(new { id = model.Id });
        }

        // DELETE: api/Project/5
        [HttpDelete("{id}")]
        // [ValidateAntiForgeryToken]
        // [SwaggerOperation("Delete" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteProjectEntity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _service.GetAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(model);
            return Ok();
        }
    }
}