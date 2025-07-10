using Library.API.Data.Models;

namespace Library.API.Data.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        Book Add(Book newBook);
        Book GetById(int id);
        void Remove(int id);
    }
}
