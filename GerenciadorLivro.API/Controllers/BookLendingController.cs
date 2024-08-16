using GerenciadorLivro.API.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLendingController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post()
        {
            return NoContent();  
        }

        [HttpPut("{id}")]
        public IActionResult ReturnBook(int id)
        {
            //var book = buscar lendingbook
            //book.ProcessBookReturn();
            return Ok();
        }

    }
}
