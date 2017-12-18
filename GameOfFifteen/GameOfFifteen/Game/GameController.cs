using NUnit.Framework;
using NUnit.Framework.Internal;

namespace GameOfFifteen.Game
{
  class GameController
  {
    private readonly GameBoard _board = new GameBoard();



    public GameBoard GetBoard()
    {
      return _board;
    }
  }
}
