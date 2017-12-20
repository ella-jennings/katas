using System.Collections.Generic;
using GameOfFifteen.Game;
using NUnit.Framework;

namespace GameOfFifteen.GameTests
{
  [TestFixture]
  public class GameControllerTests
  {
    [Test]
    public void GameController_ShouldInitiate3by3Board()
    {
      var gamecontroller = new GameController();
      var gameBoard = gamecontroller.GetBoard();

      var expectedBoardSetup = new[,]
        {{8, 7, 6}, {5, 4, 3}, {2, 1, 0}};

      Assert.That(gameBoard.GetCurrentState(), Is.EqualTo(expectedBoardSetup));
    }

    //  [TestCase('w', new int[2, 2] { { 3, 2 }, { 0, 1 } })]
    //  public void Move_ShouldSwapEmptyTileWithOneAbove(char movementCommand, params int[,] expectedPositions)
    //  {
    //    var gameBoard = new GameBoard(2);
    //    gameBoard.Move(movementCommand);

    //    Assert.That(gameBoard.GetCurrentState(), Is.EqualTo(expectedPositions));
    //}
    //}
  }
}
