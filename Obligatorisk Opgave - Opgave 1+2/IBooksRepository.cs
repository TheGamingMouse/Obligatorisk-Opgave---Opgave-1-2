using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave___Opgave_1_2
{
    public interface IBooksRepository
    {
        public IEnumerable<Book> Get(double? price = null, string? title = null, string ? orderBy = null);
        public Book GetById(int id);
        public Book Add(Book book);
        public Book Delete(int id);
        public Book Update(int id, Book values);
    }
}
