
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace PotterKata
{
    [TestFixture]
    public class PotterKataTests
    {
        [TestCase(0, 0)]
        [TestCase(1, 8)]
        [TestCase(2, 16)]
        public void NBooksCostExpectedPrice(int numberOfBookOne, int expectedPrice)
        {
            var bookOne = new Book(1);
            var basket = new Basket();
            basket.Add(numberOfBookOne, bookOne);
            var result = basket.GetTotal();

            Assert.That(result, Is.EqualTo(expectedPrice));
        }

        [TestCase(1, 1, 15.2)]
        public void BuyingTwoDifferentBooks_ShouldReturnFivePercentDiscount(int numberBookOne, int numberBookTwo, decimal expectedPrice)
        {
            var bookOne = new Book(1);
            var bookTwo = new Book(2);
            var basket = new Basket();
            basket.Add(numberBookOne, bookOne);
            basket.Add(numberBookTwo, bookTwo);
            var result = basket.GetTotal();

            Assert.That(result, Is.EqualTo(expectedPrice));
        }
    }

    public class Basket
    {
        public readonly int PriceOfBook = 8;
        private decimal _total;
        private readonly Dictionary<int, int> _purchases;

        public Basket()
        {
        _purchases = new Dictionary<int, int>();
        }

        public void Add(int numberToBeAdded, Book book)
        {
            var bookNumberInSeries = book.GetNumberInSeries();

            if (_purchases.ContainsKey(bookNumberInSeries))
            {
                _purchases[bookNumberInSeries] += numberToBeAdded;
            }
            else _purchases.Add(bookNumberInSeries, numberToBeAdded);
        }

        private void ApplyDiscount(int bookSum)
        {
            const decimal fivePercentDiscount = 5;

            if (_purchases.ContainsKey(1) && _purchases.ContainsKey(2))
            {
                _total = bookSum * ((100 - fivePercentDiscount) / 100);
            }
            else
            _total = bookSum;
        }
        
        public decimal GetTotal()
        {
            var totalBooks = 0;
            foreach (KeyValuePair<int, int> entry in _purchases)
            {
                totalBooks += entry.Value;
            }
            var bookSum = totalBooks * PriceOfBook;
            ApplyDiscount(bookSum);
            return _total;
        }
    }

    public class Book
    {
      private readonly int _numberInSeries;

        public Book(int numberInSeries)
        {
            _numberInSeries = numberInSeries;
        }

        public int GetNumberInSeries()
        {
            return _numberInSeries;
        }
    }
}
