using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProjectsController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllProjectsQuery();

            var projects = await _mediator.Send(query);

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectQuery(id);

            var project = await _mediator.Send(query);

            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            int id = await _mediator.Send(command);
            //return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPost("{id}/comments")]
        public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
        {
            command.IdProject = id;

            await _mediator.Send(command);
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
        {
            command.Id = id;

            await _mediator.Send(command);
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public async Task<IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);

            await _mediator.Send(command);
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);

            await _mediator.Send(command);
            //return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);

            await _mediator.Send(command);
            //return BadRequest();
            return NoContent();
        }
    }
}
