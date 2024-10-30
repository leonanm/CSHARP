using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Data; 


namespace ProjetoFinalAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList(); // Retorna todos os livros do contexto
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id); // Encontra e retorna o livro pelo ID
        }

        public void AddBook(Book book) => _context.Books.Add(book);

        public void UpdateBook(Book book) => _context.Books.Update(book);

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id); // Encontra a entidade pelo ID
            if (book != null)
            {
                _context.Books.Remove(book); // Remove a entidade do contexto
            }
        }

    }
}
