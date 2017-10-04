namespace PotterKata
{
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