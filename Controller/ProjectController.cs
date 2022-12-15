using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TaskTracker.Model;
using TaskTracker.Services.Interfaces;

namespace TaskTracker.Controller
{
    // ProjectController recieves http-requests for Project table
    // and calls corresponding methods
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Get all rows from the Project table
        /// </summary>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(IEnumerable<ProjectViewModel>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync()
        {
            var projects = await _projectService.GetAsync();

            return Ok(projects);
        }

        /// <summary>
        /// Get a particular row from the Project table
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK,
            Type = typeof(ProjectViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var project = await _projectService.GetAsync(id);

            return Ok(project);
        }


        /// <summary>
        /// Add a new entry to the Project table
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostAsync([FromBody] ProjectViewModel task)
        {
            var id = await _projectService.CreateAsync(task);

            return Created(new Uri($"{Request.Path}/{id}", UriKind.Relative), null);
        }

        /// <summary>
        /// Change the contents of a row in the Project table
        /// </summary>
        /// <remarks>
        /// To add a task to the project:
        /// <code>
        /// [
        ///    { "op": "add", "path": "/Tasks/-", "value": { id: 4, name: "new task name" }}
        /// ]
        /// </code>
        /// To remove a task from the project ("1" - task index in the task collection):
        /// <code>
        /// [
        ///    { "op": "remove", "path": "/Tasks/1" }
        /// ]
        /// </code>
        /// </remarks>
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchAsync(int id,
            [FromBody] JsonPatchDocument<ProjectViewModel> patch)
        {
            await _projectService.UpdateAsync(id, patch);

            return NoContent();
        }

        /// <summary>
        /// Delete a row from the Project table
        /// </summary>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _projectService.DeleteAsync(id);

            return NoContent();
        }
    }
}
