using NUnit.Framework;

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
        [TestCase(1, 3, 31.2)]
        [TestCase(2, 2, 30.4)]
        [TestCase(3, 5, 61.6)]
        public void BuyingBooksOneAndTwo_ShouldReturnFivePercentDiscount(int numberBookOne, int numberBookTwo, decimal expectedPrice)
        {
            var bookOne = new Book(1);
            var bookTwo = new Book(2);
            var basket = new Basket();
            basket.Add(numberBookOne, bookOne);
            basket.Add(numberBookTwo, bookTwo);
            var result = basket.GetTotal();

            Assert.That(result, Is.EqualTo(expectedPrice));
        }

        //[TestCase(1, 1, 15.2)]
        //public void BuyingBooksOneAndThree_ShouldReturnFivePercentDiscount(int numberBookOne, int numberBookThree, decimal expectedPrice)
        //{
        //    var bookOne = new Book(1);
        //    var bookThree = new Book(3);
        //    var basket = new Basket();
        //    basket.Add(numberBookOne, bookOne);
        //    basket.Add(numberBookThree, bookThree);
        //    var result = basket.GetTotal();

        //    Assert.That(result, Is.EqualTo(expectedPrice));
        //}
    }
}
