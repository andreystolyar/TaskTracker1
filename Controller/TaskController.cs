using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Model;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controller
{
    // TaskController recieves http-requests for Task table
    // and calls corresponding methods
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Get all rows from the Task table
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(IEnumerable<TaskViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var task = await _taskService.GetAsync();

            return Ok(task);
        }

        /// <summary>
        /// Get a particular row from the Task table
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(TaskViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var task = await _taskService.GetAsync(id);

            return Ok(task);
        }

        /// <summary>
        /// Add a new entry to the Task table
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] TaskViewModel task)
        {
            var id = await _taskService.CreateAsync(task);

            return Created(new Uri($"{Request.Path}/{id}", UriKind.Relative), null);
        }

        /// <summary>
        /// Change the contents of a row in the Task table
        /// </summary>
        /// <remarks>
        /// To change the row:
        /// <code>
        /// [
        ///    { "op": "replace", "path": "/name", "value": "new name" },
        ///    { "op": "replace", "path": "/description", "value": "new description" },
        ///    { "op": "replace", "path": "/status", "value": 1 },
        ///    { "op": "replace", "path": "/priority", "value": 100 }
        /// ]
        /// </code>
        /// </remarks>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchAsync(int id, [FromBody] JsonPatchDocument<TaskViewModel> patch)
        {
            await _taskService.UpdateAsync(id, patch);

            return NoContent();
        }

        /// <summary>
        /// Delete a row from the Task table
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _taskService.DeleteAsync(id);

            return NoContent();
        }
    }
}