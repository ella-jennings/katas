
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
            var bookOne = new Book();
            var bookTwo = new Book();
            var basket = new Basket(bookOne, bookTwo);
            basket.Purchase(numberOfBookOne, bookOne);
            var result = basket.GetTotal();

            Assert.That(result, Is.EqualTo(expectedPrice));
        }

        [TestCase(1, 1, 15.2)]
        public void BuyingTwoDifferentBooks_ShouldReturnFivePercentDiscount(int numberBookOne, int numberBookTwo, decimal expectedPrice)
        {
            var bookOne = new Book();
            var bookTwo = new Book();
            var basket = new Basket(bookOne, bookTwo);
            basket.Purchase(numberBookOne, bookOne);
            basket.Purchase(numberBookTwo, bookTwo);
            var result = basket.GetTotal();
            
            Assert.That(result, Is.EqualTo(expectedPrice));
        }
    }

    public class Basket
    {
        public readonly int PriceOfBook = 8;
        private readonly Book _bookOne;
        private readonly Book _bookTwo;
        public decimal Total { get; private set; }

        public Basket(Book bookOne, Book bookTwo)
        {
            _bookOne = bookOne;
            _bookTwo = bookTwo;
        }

        private void ApplyDiscount(int bookSum)
        {
            const decimal fivePercentDiscount = 5;

            if (_bookOne.HasBeenPurchased() && _bookTwo.HasBeenPurchased())
            {
                Total = bookSum * ((100 - fivePercentDiscount) / 100);
            }
            else
            Total = bookSum;
        }


        public decimal GetTotal()
        {
            var bookSum = (_bookOne.GetNumberPurchased() + _bookTwo.GetNumberPurchased()) * PriceOfBook;
            ApplyDiscount(bookSum);
            return Total;
        }

        public void Purchase(int numberToBePurchased, Book book)
        {
            book.AddNumberPurchased(numberToBePurchased);
        }
    }

    public class Book
    {
        private int _numberPurchased;
     
        public void AddNumberPurchased(int number)
        {
            _numberPurchased = number;
        }

        public bool HasBeenPurchased()
        {
            return _numberPurchased > 0;
        }

        public int GetNumberPurchased()
        {
            return _numberPurchased;
        }
    }
}
