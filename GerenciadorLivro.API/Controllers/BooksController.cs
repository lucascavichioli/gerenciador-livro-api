using GerenciadorLivro.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(CreateBookInputViewModel model) 
        {
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll() { return Ok();  }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
           return Ok();
        }

    }
}
