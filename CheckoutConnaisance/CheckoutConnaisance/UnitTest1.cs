using System.Collections.Generic;
using NUnit.Framework;

namespace CheckoutConnaisance
{
  [TestFixture]
  public class UnitTest1
  {
    [SetUp]
    public void Setup()
    {
      _expectedItemACost = 50;
      _expectedItemBCost = 30;
      _itemA = "a";
      _itemB = "b";
      var expectedPrices = new Dictionary<string, int>
      {
        {_itemA, _expectedItemACost},
        {_itemB, _expectedItemBCost}
      };

      _checkout = new Checkout(expectedPrices);
    }

    private Checkout _checkout;
    private string _itemA;
    private string _itemB;
    private int _expectedItemACost;
    private int _expectedItemBCost;

    [Test]
    public void OneItemACosts50()
    {
      _checkout.AddItem(_itemA);

      var result = _checkout.GetTotal();

      Assert.That(result, Is.EqualTo(_expectedItemACost));
    }

    [Test]
    public void OneItemBCosts30()
    {
      _checkout.AddItem(_itemB);

      var result = _checkout.GetTotal();

      Assert.That(result, Is.EqualTo(_expectedItemBCost));
    }
  }

  internal class Checkout
  {
    private readonly Dictionary<string, int> _itemPrices;
    private int _total;

    public Checkout(Dictionary<string, int> itemPrices)
    {
      _itemPrices = itemPrices;
    }

    public int GetTotal()
    {
      return _total;
    }

    public void AddItem(string item)
    {
      _total = _itemPrices[item];
    }
  }
}