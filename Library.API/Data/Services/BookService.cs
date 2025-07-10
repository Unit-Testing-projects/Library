using Library.API.Data.Models;

namespace Library.API.Data.Services
{
    public class BookService : IBookService
    {
        private readonly List<Book> _books;
        public BookService()
        {
            _books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title="Managing Oneself",
                    Description="We live in an age of unprecedented opportunity: with ambition, drive, and talent, you can rise to the top of your chosen profession, regardless of where you started out...",
                    Author= "Peter Ducker",
                },
                new Book()
                {
                    Id= 2,
                    Title="Evolutionary Psychology",
                    Description="Evolutionary Psychology: The New Science of the Mind, 5th edition provides students with the conceptual tools of evolutionary psychology, and applies them to empirical research on the human mind...",
                    Author= "David Buss",
                },
                new Book()
                {
                    Id= 3,
                    Title="How to Win Friends & Influence People",
                    Description="Millions of people around the world have improved their lives based on the teachings of Dale Carnegie. In How to Win Friends and Influence People, he offers practical advice and techniques for how to get out of a mental rut and make life more rewarding...",
                    Author= "Dale Carnegie"
                },
                new Book()
                {
                    Id =  4,
                    Title = "The Selfish Gene",
                    Description = "Professor Dawkins articulates a gene’s eye view of evolution. A view giving center stage to these persistent units of information, and in which organisms can be seen as vehicles for their replication. This imaginative, powerful, and stylistically brilliant work not only brought the insights of Neo-Darwinism to a wide audience. But galvanized the biology community, generating much debate and stimulating whole new areas of research...",
                    Author = "Richard Dawkins"
                },
                new Book()
                {
                    Id = 5,
                    Title = "The Lessons of History",
                    Description = "Will and Ariel Durant have succeeded in distilling for the reader the accumulated store of knowledge and experience from their five decades of work on the eleven monumental volumes of The Story of Civilization...",
                    Author = "Will & Ariel Durant"
                }
            };
        }
        public Book Add(Book newBook)
        {
            newBook.Id = _books.Max(x => x.Id) + 1;
            _books.Add(newBook);
            return newBook;
        }

        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.Where(x => x.Id == id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existingBook = _books.First(x => x.Id == id);
            _books.Remove(existingBook);
        }
    }
}
