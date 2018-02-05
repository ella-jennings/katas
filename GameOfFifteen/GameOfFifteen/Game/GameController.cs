using NUnit.Framework.Constraints;

namespace GameOfFifteen.Game
{
  class GameController
  {
    public GameBoard Board { get; }

    public GameController(string input, int boardSize)
    {
      Board = new GameBoard(boardSize);
    }
  }
}
