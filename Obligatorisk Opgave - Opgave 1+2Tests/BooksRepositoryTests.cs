using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_Opgave___Opgave_1_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opgave___Opgave_1_2.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {
        private IBooksRepository _repo;
        private readonly Book invalidBook = new() { Title = "Game of Thrones", Price = 1500 };

        [TestInitialize()]
        public void Init()
        {
            _repo = new BooksRepository();

            _repo.Add(new Book() { Title = "Hunger Games", Price = 550 });
            _repo.Add(new Book() { Title = "Game of Thrones", Price = 150 });
            _repo.Add(new Book() { Title = "To Kill a Mockingbird", Price = 200 });
            _repo.Add(new Book() { Title = "The Great Gatsby", Price = 50 });
            _repo.Add(new Book() { Title = "The Fellowship of the Ring", Price = 250 });
        }
        
        [TestMethod()]
        public void GetTest()
        {
            IEnumerable<Book> books = _repo.Get();
            Assert.AreEqual(5, books.Count());
            Assert.AreEqual("Hunger Games", books.First().Title);

            IEnumerable<Book> titleSortedBooks = _repo.Get(orderBy: "title");
            Assert.AreEqual("Game of Thrones", titleSortedBooks.First().Title);

            IEnumerable<Book> titleSortedBooksDesc = _repo.Get(orderBy: "title_desc");
            Assert.AreEqual("To Kill a Mockingbird", titleSortedBooksDesc.First().Title);

            IEnumerable<Book> priceSortedBooks = _repo.Get(orderBy: "price");
            Assert.AreEqual("The Great Gatsby", priceSortedBooks.First().Title);

            IEnumerable<Book> priceSortedBooksDesc = _repo.Get(orderBy: "price_desc");
            Assert.AreEqual("Hunger Games", priceSortedBooksDesc.First().Title);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.IsNotNull(_repo.GetById(1));
            Assert.IsNull(_repo.GetById(100));
        }

        [TestMethod()]
        public void AddTest()
        {
            Book book = new() { Title = "Game of Thrones", Price = 150 };
            Assert.AreEqual(6, _repo.Add(book).Id);
            Assert.AreEqual(6, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Add(invalidBook));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.IsNull(_repo.Delete(100));
            Assert.AreEqual(1, _repo.Delete(1)?.Id);
            Assert.AreEqual(4, _repo.Get().Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());
            Book book = new() { Title = "Test", Price = 100 };
            Assert.IsNull(_repo.Update(100, book));
            Assert.AreEqual(1, _repo.Update(1, book).Id);
            Assert.AreEqual(5, _repo.Get().Count());

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _repo.Update(1, invalidBook));
        }
    }
}