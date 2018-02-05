using GameOfFifteen.Game;
using NUnit.Framework;

namespace GameOfFifteen.GameTests
{
  [TestFixture]
  public class GameControllerTests
  {
    [Test]
    public void GameController_ShouldInitiate2x2BoardCorrectly()
    {
      var gamecontroller = new GameController("", 2);
      var gameBoard = gamecontroller.Board.BoardPositions;

      var expectedBoardSetup = new[,]
        { {0, 1}, {2, 3} };

      Assert.That(gameBoard[0,0], Is.EqualTo(0));
      Assert.That(gameBoard[0,0], Is.EqualTo(expectedBoardSetup[0,0]));
      Assert.That(gameBoard[0,1], Is.EqualTo(1));
      Assert.That(gameBoard[0,1], Is.EqualTo(expectedBoardSetup[0,1]));
      Assert.That(gameBoard[1,0], Is.EqualTo(2));
      Assert.That(gameBoard[1,0], Is.EqualTo(expectedBoardSetup[1,0]));
      Assert.That(gameBoard[1,1], Is.EqualTo(3));
      Assert.That(gameBoard[1,1], Is.EqualTo(expectedBoardSetup[1,1]));
    }

    //[Test]
  }
}

