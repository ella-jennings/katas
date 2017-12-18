using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace GameOfFifteen.Game
{
  public class GameBoard
  {
    private const int BoardSize = 2;
    private readonly int _positions = (BoardSize * BoardSize) - 1;
    private readonly int[,] _boardPositions = new int[BoardSize,BoardSize];

    public GameBoard()
    {
      for (var x = 0; x < BoardSize; x++)
      {
        for (var y = 0; y < BoardSize; y++)
        {
          _boardPositions[x, y] = _positions;
          _positions = _positions - 1;
        }
      }
    }
    public int[,] GetPosition()
    {
      return _boardPositions;
    }
  }
}
