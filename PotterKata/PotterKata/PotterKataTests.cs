
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
        [TestCase(1, 2, 23.2)]
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
        private readonly int _priceOfBook = 8;
        private int _bookCount = 0;
        private decimal _total;
        private readonly Dictionary<int, int> _purchases;

        public Basket()
        {
            _purchases = new Dictionary<int, int>();
        }

        public void Add(int numberToBeAdded, Book book)
        {
            var bookNumberInSeries = book.GetNumberInSeries();
            _purchases.Add(bookNumberInSeries, numberToBeAdded);
            _bookCount += numberToBeAdded;
        }

        private void ApplyTotalDiscount(int bookSum)
        {
            const decimal fivePercentDiscount = 5;

            if (_purchases.ContainsKey(1) && _purchases.ContainsKey(2))
            {
                var numberOfBooksDiscounted = 2;
                var sumOfNormalPriceBooks = GetSumOfNormalPriceBooks(numberOfBooksDiscounted);

                var discountSum = numberOfBooksDiscounted * _priceOfBook * ((100 - fivePercentDiscount) / 100);
                _total = sumOfNormalPriceBooks + discountSum;
            }
            else
            _total = bookSum;
        }

        private int GetSumOfNormalPriceBooks(int numberOfBooksDiscounted)
        {
            var normalPriceSum = 0;
            var normalPriceBooks = 0;
            if (_bookCount > numberOfBooksDiscounted)
            {
                normalPriceBooks += 1;
                normalPriceSum = normalPriceBooks * _priceOfBook;
            }
            return normalPriceSum;
        }

        public decimal GetTotal()
        {
            var totalBooks = 0;
            foreach (KeyValuePair<int, int> entry in _purchases)
            {
                totalBooks += entry.Value;
            }
            var bookSum = totalBooks * _priceOfBook;
            ApplyTotalDiscount(bookSum);
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
