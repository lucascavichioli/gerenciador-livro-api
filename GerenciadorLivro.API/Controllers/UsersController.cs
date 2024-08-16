using GerenciadorLivro.API.Entities;
using GerenciadorLivro.API.Models;
using GerenciadorLivro.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorLivro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DefaultDbContext _context;
        public UsersController(DefaultDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputViewModel model)
        {
            var user = new User(model.Name, model.Email);

            _context.Add(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll() 
        { 
            var users = _context.Users.ToList();
            return Ok(users);
        }

    }
}
