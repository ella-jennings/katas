using System;

namespace GameOfFifteen.Game
{
  public class GameBoard
  {
    private int[,] _board;
    private const int Boardsize = 3;

    public GameBoard()
    {
      SetUpBoard();
    }

    private void SetUpBoard()
    {
      var positions = (Boardsize * Boardsize) - 1;
      _board = new int[Boardsize, Boardsize];

      for (var x = 0; x < Boardsize; x++)
      {
        for (var y = 0; y < Boardsize; y++)
        {
          _board[x, y] = positions;
          positions = positions - 1;
        }
      }
    }

    public int[,] GetCurrentState()
    {
      return _board;
    }

    //public void Move(char movementCommand)
    //{
    //  for (var x = 0; x < _boardsize; x++)
    //  {
    //    for (var y = 0; y < _boardsize; y++)
    //    {
    //      if (_board[x,y] == 0)
    //      {
    //        if (movementCommand == 'w')
    //        {
    //          _board[x, y] = _board[x, y - 1];
    //          _board[x, y - 1] = 0;
    //        }     
    //      }
    //    }
    //  }
    }
  }

