using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PotterKata
{
    [TestFixture]
    public class PotterKataTests
    {
       [Test]
        public void OneBookCostsEightEuros()
        {
            var book = new Book();

            Assert.AreEqual(8, book.Price);
        }

        [TestCase(0, 0)]
        [TestCase(1, 8)]
        [TestCase(2, 16)]
        public void NBooksCostExpectedPrice(int numberOfBooks, int expectedPrice)
        {
            var basket = new Basket();
            basket.GetTotal(numberOfBooks);

            Assert.AreEqual(expectedPrice, basket.Total);
        }
    }

    public class Basket
    {
        public int Total;

        public void GetTotal(int numberOfBooks)
        {
            var book = new Book();
            Total = numberOfBooks * book.Price;
        }
    }

    public class Book
    {
        public readonly int Price = 8;
    }
}
