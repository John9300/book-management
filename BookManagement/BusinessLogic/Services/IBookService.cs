using DataAccess.Entitis;

namespace BusinessLogic.Services
{
    public interface IBookService
    {
        List<Book> GetAll();
        void Add(Book book);
    }
}
