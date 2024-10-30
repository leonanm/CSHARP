using Microsoft.EntityFrameworkCore;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Repositories;
using ProjetoFinalAPI.Data;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ProjetoFinalAPI.Tests
{
    public class BookRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _options;

        public BookRepositoryTests()
        {
            var databaseName = Guid.NewGuid().ToString(); // Gera um nome único para o banco de dados
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }

        [Fact]
        public void AddBook_ShouldAddBook()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Test Book", AuthorId = 1, PublisherId = 1 };

                // Act
                repository.AddBook(book);
                context.SaveChanges();

                // Assert
                var result = context.Books.FirstOrDefault(b => b.Title == "Test Book");
                Assert.NotNull(result);
                Assert.Equal("Test Book", result.Title);
            }
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new BookRepository(context);
                var book1 = new Book { Title = "Book 1", AuthorId = 1, PublisherId = 1 };
                var book2 = new Book { Title = "Book 2", AuthorId = 1, PublisherId = 1 };

                context.Books.Add(book1);
                context.Books.Add(book2);
                context.SaveChanges(); // Salvar as alterações no contexto

                // Act
                var books = repository.GetAllBooks();

                // Assert
                Assert.Equal(2, books.Count());
            }
        }


        [Fact]
        public void GetBookById_ShouldReturnCorrectBook()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Book 1", AuthorId = 1, PublisherId = 1 };

                // Adiciona o livro ao contexto e salva
                context.Books.Add(book);
                context.SaveChanges(); // Importante: salvar para persistir o livro no banco de dados

                // Act
                var result = repository.GetBookById(book.Id); // Chama o método para obter o livro pelo ID

                // Assert
                Assert.NotNull(result); // Verifica se o resultado não é nulo
                Assert.Equal(book.Title, result.Title); // Verifica se o título do livro retornado é o esperado
            }
        }

        [Fact]
        public void UpdateBook_ShouldUpdateBook()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Old Title", AuthorId = 1, PublisherId = 1 };
                context.Books.Add(book);
                context.SaveChanges();

                // Act
                book.Title = "Updated Title";
                repository.UpdateBook(book);
                context.SaveChanges();

                // Assert
                var updatedBook = context.Books.Find(book.Id);
                Assert.Equal("Updated Title", updatedBook.Title);
            }
        }

        [Fact]
        public void DeleteBook_ShouldRemoveBook()
        {
            // Arrange
            using (var context = new AppDbContext(_options))
            {
                var repository = new BookRepository(context);
                var book = new Book { Title = "Book to Delete", AuthorId = 1, PublisherId = 1 };
                context.Books.Add(book);
                context.SaveChanges();

                // Act
                repository.DeleteBook(book.Id); // Passa o ID da entidade a ser removida
                context.SaveChanges();

                // Assert
                var result = context.Books.Find(book.Id);
                Assert.Null(result); // Verifica se o livro foi removido
            }
        }
    }
}
