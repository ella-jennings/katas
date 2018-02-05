namespace GameOfFifteen.Game
{
  public class GameBoard
  {
    public int[,] BoardPositions { get; private set; }
    private static int _boardsize;
    //private static readonly int MaxBoardPosition = _boardsize - 1;

    public GameBoard(int boardsize)
    {
      _boardsize = boardsize;
      SetUpBoard();
    }

    private void SetUpBoard()
    {
      var positionNumber = 0;
      BoardPositions = new int[_boardsize, _boardsize];

      for (var x = 0; x < _boardsize; x++)
      {
        for (var y = 0; y < _boardsize; y++)
        {
          BoardPositions[x, y] = positionNumber;
          positionNumber += 1;
        }
      }
    }
  }
}

