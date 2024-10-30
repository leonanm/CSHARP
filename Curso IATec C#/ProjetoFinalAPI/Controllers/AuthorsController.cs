using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Repositories;
using System.Collections.Generic; 


namespace ProjetoFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        // GET: api/authors
        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAuthors()
        {
            return Ok(_authorRepository.GetAllAuthors());
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public ActionResult<Author> GetAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        // POST: api/authors
        [HttpPost]
        public ActionResult<Author> AddAuthor(Author author)
        {
            _authorRepository.AddAuthor(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
                return BadRequest();

            _authorRepository.UpdateAuthor(author);
            return NoContent();
        }

        // DELETE: api/authors/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
