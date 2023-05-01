using BusinessLogic.Models;
using BusinessLogic.Services;
using DataAccess;
using DataAccess.Entitis;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    [TestClass]
    public class BookServiceTests
    {
        private IBookService _bookService;

        private DataBaseContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            var dbContextOptions = new DbContextOptionsBuilder<DataBaseContext>()
              .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _context = new DataBaseContext(dbContextOptions);
        }

        [TestMethod]
        public void WhenGetAllIsCalled_WithDatabaseEntries_ThenReturnsAListOfBooks()
        {
            // Arrange
            _context.Books.Add(new Book
            {
                Id = Guid.NewGuid(),
                Name = "Book 1",
                Author = "Name 1",
                IsEBook = true
            });
            _context.SaveChanges();

            _bookService = new BookService(_context);

            // Act
            var result = _bookService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void WhenGetAllIsCalled_WithNoDabaseEntries_ThenReturnsAnEmptyListOfBooks()
        {
            // Arrange
            _bookService = new BookService(_context);

            // Act
            var result = _bookService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void WhenAddIsCalled_WithCopiesZero_ThenNoBookIsAdded()
        {
            // Arrange
            var book = new BookAddModel
            {
                Name = "Book 1",
                Author = "Name 1",
                IsEBook = true,
                Copies = 0
            };

            _bookService = new BookService(_context);

            // Act
             _bookService.Add(book);

            // Assert
            Assert.AreEqual(0 ,_context.Books.Count());
        }

        [TestMethod]
        public void WhenAddIsCalled_WithCopiesThree_ThenThreeBooksAreAdded()
        {
            // Arrange
            var book = new BookAddModel
            {
                Name = "Book 1",
                Author = "Name 1",
                IsEBook = true,
                Copies = 3
            };

            _bookService = new BookService(_context);

            // Act
            _bookService.Add(book);

            // Assert
            Assert.AreEqual(3, _context.Books.Count());
        }
    }
}