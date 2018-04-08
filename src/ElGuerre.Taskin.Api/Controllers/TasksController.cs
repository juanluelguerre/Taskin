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
    //[Route("api/Tasks")]
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        private const string SERVICE_NAME = "Tasks";
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation("GetAll" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<TaskModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var response = await _service.GetAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get" + SERVICE_NAME, Tags = new[] { SERVICE_NAME })]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(TaskModel), (int)HttpStatusCode.OK)]
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
        
        // POST: api/Tasks
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Tasks/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
