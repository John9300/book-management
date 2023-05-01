using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface IBookService
    {
        List<BookGetModel> GetAll();
        BookGetModel GetById(Guid id);
        void Add(BookAddModel model);
    }
}
