using GerenciadorLivro.API.Entities;
using GerenciadorLivro.API.Models;
using GerenciadorLivro.API.Persistence;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookLendingController : ControllerBase
    {
        private readonly DefaultDbContext _context;
        public BookLendingController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(CreateBookLendingInputViewModel model)
        {
            var bookLending = new BookLending(model.IdUser, model.IdBook, model.DeadlineDate);
            
            _context.Add(bookLending);
            _context.SaveChanges();

            return NoContent();  
        }

        [HttpPut("{idBook}")]
        public IActionResult ReturnBook(int idBook)
        {
            var book = _context.BookLendings.SingleOrDefault(b => b.IdBook == idBook);
            
            if(book is null || book.ReturnDate is not null)
                return NotFound();

            var msg = book.ProcessBookReturn();

            _context.Update(book);
            _context.SaveChanges();

            return Ok(msg);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var bookLendings = _context.BookLendings.ToList();

            if (bookLendings is null)
                return NotFound();
            
            return Ok(bookLendings);
        }

    }
}
