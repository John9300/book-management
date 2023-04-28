using DataAccess;
using DataAccess.Entitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly DataBaseContext _context;

        public BookService(DataBaseContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetAll()
        {
            var result = _context.Books.ToList();

            return result;
        }
    }
}
