using BusinessLogic.Models;
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

        public void Add(BookAddModel model)
        {
            for (var i = 0; i < model.Copies; i++)
            {
                var entity = new Book
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Author = model.Author,
                    PublishDate = model.PublishDate,
                    IsEBook = model.IsEBook
                };

                _context.Books.Add(entity);
                _context.SaveChanges();
            }
        }

        public List<BookGetModel> GetAll()
        {
            var entities = _context.Books;

            var result = entities.Select(book => new BookGetModel
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                PublishDate = book.PublishDate,
                IsEBook = book.IsEBook
            }).ToList();

            return result;
        }

        public BookGetModel GetById(Guid id)
        {
            var entity = _context.Books.Where(b => b.Id == id).FirstOrDefault();
           
            if(entity == null)
            {
                return null;
            }

            var model = new BookGetModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Author = entity.Author,
                PublishDate = entity.PublishDate,
                IsEBook = entity.IsEBook
            };

            return model;
        }
    }
}
