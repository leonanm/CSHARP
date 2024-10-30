using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoFinalAPI.Controllers;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Repositories;
using System.Collections.Generic;
using Xunit;

namespace ProjetoFinalAPI.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<IBookRepository> _mockRepository;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockRepository = new Mock<IBookRepository>();
            _controller = new BooksController(_mockRepository.Object);
        }

        [Fact]
        public void GetBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book { Id = 1, Title = "Book 1", AuthorId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Book 2", AuthorId = 1, PublisherId = 1 }
            };
            _mockRepository.Setup(repo => repo.GetAllBooks()).Returns(books);

            // Act
            var result = _controller.GetBooks();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Book>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnBooks = Assert.IsType<List<Book>>(okResult.Value);
            Assert.Equal(2, returnBooks.Count);
        }

        [Fact]
        public void AddBook_ShouldReturnCreatedAtAction()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "New Book", AuthorId = 1, PublisherId = 1 };
            _mockRepository.Setup(repo => repo.AddBook(book));

            // Act
            var result = _controller.AddBook(book);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            Assert.Equal("GetBook", createdAtActionResult.ActionName);
        }
    }
}
