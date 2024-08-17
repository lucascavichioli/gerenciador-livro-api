using GerenciadorLivro.API.Entities;
using GerenciadorLivro.API.Models;
using GerenciadorLivro.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DefaultDbContext _context;
        public BooksController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(CreateBookInputViewModel model) 
        {
            var books = new Book(model.Title, model.Autor, model.ISBN, model.YearPublication);
            _context.Add(books);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            var books = _context.Books.ToList();

            if (books is null)
                return NotFound();

            return Ok(books);  
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            
            if(book is null)
                return NotFound();
            
            return Ok(book);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);

            if (book is null)
                return NotFound();

            _context.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
