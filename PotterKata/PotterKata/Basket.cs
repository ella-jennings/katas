using System.Collections.Generic;

namespace PotterKata
{
    public class Basket
    {
        private const int PriceOfBook = 8;
        private readonly Dictionary<int, int> _purchases;

        public Basket()
        {
            _purchases = new Dictionary<int, int>();
        }

        public void Add(int numberToBeAdded, Book book)
        {
            var bookNumberInSeries = book.GetNumberInSeries();
            _purchases.Add(bookNumberInSeries, numberToBeAdded);
        }

        private int GetNumberOfDiscountedBooks()
        {
            var numberOfFirstBook = _purchases[1];
            var numberOfSecondBook = _purchases[2];
            var numberOfDiscountedBooks = 0;

            while (BooksRemain(numberOfFirstBook) && BooksRemain(numberOfSecondBook))
            {
                numberOfDiscountedBooks += 2;
                numberOfFirstBook -= 1;
                numberOfSecondBook -= 1;
            }
            return numberOfDiscountedBooks;
        }

        private static bool BooksRemain(int numberOfBooks)
        {
            return numberOfBooks > 0;
        }

        private decimal GetTotalWithDiscount(int totalBooks)
        {
            const decimal fivePercentDiscount = 5;
            var numberOfBooksDiscounted = GetNumberOfDiscountedBooks();
            var sumOfNormalPriceBooks = GetSumOfNormalPriceBooks(numberOfBooksDiscounted, totalBooks);

            var discountSum = numberOfBooksDiscounted * PriceOfBook * ((100 - fivePercentDiscount) / 100);
            var totalPrice = sumOfNormalPriceBooks + discountSum;
            return totalPrice;
        }

        private int GetSumOfNormalPriceBooks(int numberOfBooksDiscounted, int totalBooks)
        {
            var normalPriceBooks = totalBooks - numberOfBooksDiscounted;
            var normalPriceSum = normalPriceBooks * PriceOfBook;
            return normalPriceSum;
        }

        public decimal GetTotal()
        {
            var totalBooks = 0;
            foreach (KeyValuePair<int, int> entry in _purchases)
            {
                totalBooks += entry.Value;
            }
            var bookSum = totalBooks * PriceOfBook;

            decimal totalPrice;
            if (_purchases.ContainsKey(1) && _purchases.ContainsKey(2))
            {
                totalPrice = GetTotalWithDiscount(totalBooks);
            }
            else totalPrice = bookSum;
            return totalPrice;
        }
    }
}