using System.Collections.Generic;
using System.Linq;
using ProjetoFinalAPI.Models; 
using ProjetoFinalAPI.Data;   

namespace ProjetoFinalAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Author> GetAllAuthors() => _context.Authors.ToList();

        public Author GetAuthorById(int id) => _context.Authors.FirstOrDefault(a => a.Id == id);

        public void AddAuthor(Author author) => _context.Authors.Add(author);

        public void UpdateAuthor(Author author) => _context.Authors.Update(author);

        public void DeleteAuthor(int id) => _context.Authors.Remove(new Author { Id = id });
    }
}
