using DevFreela.Application.InputModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            //return BadRequest();
            //return CreatedAtAction(nameof(GetById), new {id = inputModel.Id}, inputModel);
            return Ok();
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
