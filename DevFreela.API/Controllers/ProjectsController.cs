using DevFreela.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
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
        public IActionResult Post([FromBody] Project project)
        {
            //return BadRequest();
            return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] Project project)
        {
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put (int id, [FromBody] Project project)
        {
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            //return BadRequest();
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            //return BadRequest();
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
