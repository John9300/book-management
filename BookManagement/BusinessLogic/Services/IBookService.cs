using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public interface IBookService
    {
        List<BookGetModel> GetAll();
        void Add(BookAddModel model);
    }
}
