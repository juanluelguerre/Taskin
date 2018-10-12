// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using ElGuerre.Taskin.Api.Services;
using ElGuerre.Taskin.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Taskin.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private const string SERVICE_NAME = "Tasks";
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        // [SwaggerOperation("GetAll" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(IEnumerable<TaskModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TaskModel>>> Get()
        {
            var response = await _service.GetAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        // [SwaggerOperation("Get" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(TaskModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TaskModel>> Get([FromRoute] int id)
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
        
        // POST: api/Tasks
        [HttpPost]
        // [ValidateAntiForgeryToken]
        //[SwaggerOperation("Post" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<TaskModel>> Post([FromBody] TaskModel taskModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _service.AddAsync(taskModel);
            return Ok(new { id = model.Id });
        }

        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        // [ValidateAntiForgeryToken]
        // [SwaggerOperation("Put" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<ActionResult<TaskModel>> Put([FromRoute] int id, [FromBody] TaskModel taskModel)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != taskModel.Id)
            {
                return BadRequest();
            }

            var model = await _service.GetAsync(id);
            if (model == null)
                return NotFound();

            model = await _service.UpdateAsync(taskModel);
            return Ok(model);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public void Delete(int id)
        {
        }
    }
}
