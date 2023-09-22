using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave___Opgave_1_2
{
    public class BooksRepository : IBooksRepository
    {
        private List<Book> _books = new List<Book>();
        private int _nextId = 1;
        public BooksRepository() { }

        public IEnumerable<Book> Get(double? price = null, string? title = null, string? orderBy = null)
        {
            IEnumerable<Book> result = new List<Book>(_books);

            //Filter
            if (price != null)
            {
                result = result.Where(b => b.Price == price);
            }
            if (title != null)
            {
                result = result.Where(b => b.Title.Contains(title));
            }

            //Sortering
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "price":
                    case "price_asc":
                        result = result.OrderBy(b => b.Price);
                        break;
                    case "price_desc":
                        result = result.OrderByDescending(b => b.Price);
                        break;
                    case "title":
                    case "title_asc":
                        result = result.OrderBy(b => b.Title); 
                        break;
                    case "title_desc":
                        result = result.OrderByDescending(b => b.Title);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public Book? GetById(int id)
        {
            return _books.Find(b => b.Id == id);
        }

        public Book Add(Book book)
        {
            book.Id = _nextId++;
            book.Validate();
            _books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? book = GetById(id);
            if(book == null)
            {
                return null;
            }
            _books.Remove(book);
            return book;
        }

        public Book? Update(int id, Book values)
        {
            values.ValidateTitle();
            values.ValidatePrice();
            Book? book = GetById(id);
            if (book == null)
            {
                return null;
            }
            book.Title = values.Title;
            book.Price = values.Price;
            return book;
        }
    }
}
