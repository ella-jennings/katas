using System.Collections.Generic;
using System.Linq;

namespace BowlingScoreCalculator
{
  internal class Game
  {
    private readonly List<Frame> _frames = new List<Frame>();
    private bool _lastFrameWasStrike;
    private bool _lastFrameWasSpare;

    public int GetScore()
    {
      var score = 0;

      foreach (var frame in _frames)
      {
        score += GetSpareBonus(frame);
        score += GetStrikeBonus(frame);
        score += frame.GetTotal();

        _lastFrameWasSpare = frame.IsSpare;
        _lastFrameWasStrike = frame.IsStrike;
      }
      return score;
    }

    private int GetStrikeBonus(Frame frame)
    {
      var bonus = 0;
      if (_lastFrameWasStrike)
      {
        bonus = frame.GetTotal();
      }
      return bonus;
    }

    private int GetSpareBonus(Frame frame)
    {
      var bonus = 0;
      if (_lastFrameWasSpare)
      {
        bonus = frame.GetFirstRoll();
      }
      return bonus;
    }

    public void Roll(int pins)
    {
      if (_frames.Count == 0 || _frames.Last().IsFinished)
      {
        _frames.Add(new Frame());
      }

      var currentFrame = _frames.Last();
      
      currentFrame.AddRoll(pins);
    }
  }

  internal class Frame
  {
    private readonly List<int> _rolls = new List<int>();
    public bool IsFinished => _rolls.Count == 2 || _rolls.First() == 10;
    public bool IsSpare => _rolls.Count == 2 && _rolls.Sum() == 10;
    public bool IsStrike => _rolls.First() == 10;


    public void AddRoll(int pins)
    {
      _rolls.Add(pins);
    }

    public int GetTotal()
    {
      return _rolls.Sum();
    }

    public int GetFirstRoll()
    {
      return _rolls.First();
    }
  }
}