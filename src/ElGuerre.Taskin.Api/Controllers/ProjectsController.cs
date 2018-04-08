// ---------------------------------------------------------------------------------
// <copyright file="ProjectController.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using ElGuerre.OneRest.Taskin.Api.Services;
using ElGuerre.Taskin.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Taskin.Api.Controllers
{
    [Produces("application/json")]
    //[Route("api/Projects")]
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private const string SERVICE_NAME = "Project";
        private readonly IProjectService _service;

        public ProjectsController(IProjectService service)
        {
            _service = service;   
        }

        [HttpGet]
        [SwaggerOperation("GetAll" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ProjectModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAsync();
            return Ok(response);
        }

        // GET: api/Project/5
        [HttpGet("{id}")]
        [SwaggerOperation("Get" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ProjectModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromRoute] int id)
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

            return Ok(model);
        }


        [HttpGet("{id}/tasks")]
        [SwaggerOperation("GetTasksByProjectId", Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<TaskModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTasksByProjectId([FromRoute] int id)
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
        [SwaggerOperation("Put" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProjectModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProjectModel projectModel)
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
        [SwaggerOperation("Post" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] ProjectModel projectModel)
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
        [SwaggerOperation("Delete" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteProjectEntity([FromRoute] int id)
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