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
    public class BookTests
    {
        private readonly Book validBook = new() { Id = 1, Title = "Game of Thrones", Price = 150 };
        private readonly Book invalidIdBook = new() { Id = 0, Title = "Game of Thrones", Price = 150 };
        private readonly Book shortTitleBook = new() { Id = 1, Title = "Ga", Price = 150 };
        private readonly Book nullTitleBook = new() { Id = 1, Title = null, Price = 150 };
        private readonly Book lowPriceBook = new() { Id = 1, Title = "Game of Thrones", Price = -1 };
        private readonly Book highPriceBook = new() { Id = 1, Title = "Game of Thrones", Price = 1201 };

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("Id=1, Title=Game of Thrones, Price=150", validBook.ToString());
        }

        [TestMethod()]
        public void ValidateTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidIdBook.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => shortTitleBook.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => lowPriceBook.Validate());

            validBook.Validate();
        }

        [TestMethod()]
        public void ValidateIdTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => invalidIdBook.Validate());
            
            validBook.Validate();
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => nullTitleBook.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>( () => shortTitleBook.Validate());

            validBook.Validate();
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => lowPriceBook.Validate());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => highPriceBook.Validate());

            validBook.Validate();
        }
    }
}