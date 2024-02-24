using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;
        public UsersController(IMediator mediator, IUserService userService) 
        {
            _mediator = mediator;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _userService.GetAll();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _userService.GetById(id);
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState
                    .SelectMany(ms => ms.Value.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(messages);
            }

            int id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new {id}, command);
        }

        [HttpPut("{id}/login")]
        public IActionResult Login(int id)
        {
            //return BadRequest();
            // return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            ////return BadRequest();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //return BadRequest();
            return NoContent();
        }
    }
}
