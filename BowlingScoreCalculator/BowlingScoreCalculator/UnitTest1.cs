using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BowlingScoreCalculator
{
  [TestFixture]
  public class BowlingScoreCalculatorTests
  {
    [TestCase(0, 0)]
    [TestCase(1, 20)]
    public void WithNoSparesOrStrikes_ShouldCalculateTotalScore(int score, int expectedScore)
    {
      var game = new Game();

      for (int i = 0; i < 20; i++)
      {
        game.Roll(score);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(expectedScore));
    }

    [Test]
    public void WithSpareAndNoBonus_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(5);
      game.Roll(5);
      for (int i = 0; i < 18; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(10));
    }

    [Test]
    public void WithSpareAndBonusFirstFrame_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(5);
      game.Roll(5);
      game.Roll(1);
      for (int i = 0; i < 17; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(12));
    }

    [Test]
    public void WithSpareAndBonusSecondFrame_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(0);
      game.Roll(0);
      game.Roll(5);
      game.Roll(5);
      game.Roll(1);
      for (var i = 0; i < 15; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(12));
    }

    [Test]
    public void WithSpareAndBonusSecondFrameAndOrdinaryThirdFrame_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(0);
      game.Roll(0);
      game.Roll(5);
      game.Roll(5);
      game.Roll(1);
      game.Roll(1);
      game.Roll(1);
      game.Roll(1);
      for (var i = 0; i < 2; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(15));
    }

    [Test]
    public void WithStrikeFirstFrame_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(10);
      for (var i = 0; i < 18; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(10));
    }

    [Test]
    public void WithStrikeFirstFrameAndSecondFrameScore_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(10);
      game.Roll(1);
      game.Roll(1);
      for (var i = 0; i < 16; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(14));
    }

    [Test]
    public void WithStrikeFirstFrameAndSecondFrameBonusAndOrdinaryThirdFrame_ShouldCalculateTotalScore()
    {
      var game = new Game();

      game.Roll(10);
      game.Roll(1);
      game.Roll(1);
      game.Roll(1);
      game.Roll(1);
      for (var i = 0; i < 14; i++)
      {
        game.Roll(0);
      }

      var totalscore = game.GetScore();

      Assert.That(totalscore, Is.EqualTo(16));
    }
  }
}
