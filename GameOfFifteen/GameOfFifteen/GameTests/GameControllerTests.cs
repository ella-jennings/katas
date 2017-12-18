using System.Collections.Generic;
using GameOfFifteen.Game;
using NUnit.Framework;

namespace GameOfFifteen.GameTests
{
  [TestFixture]
  public class GameControllerTests
  {
    [Test]
    public void GameController_ShouldInitiate2by2Board()
    {
      var gamecontroller = new GameController();
      var gameBoard = gamecontroller.GetBoard();

      var expectedBoardSetup = new int[2, 2]
        {{ 3, 2 }, { 1, 0 }};

      Assert.That(gameBoard.GetPosition(), Is.EqualTo(expectedBoardSetup));
    }
  }
}
