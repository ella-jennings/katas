using System.Collections.Generic;
using NUnit.Framework;

namespace CheckoutConnaisance
{

  // change int to money with no breaking tests
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
      var expectedPricesAsMoney = new Dictionary<string, Money>
      {
        {_itemA, new Money(_expectedItemACost)},
        {_itemB, new Money(_expectedItemBCost)}
      };

      _checkout = new Checkout(expectedPrices, expectedPricesAsMoney);
    }

    private Checkout _checkout;
    private string _itemA;
    private string _itemB;
    private int _expectedItemACost;
    private int _expectedItemBCost;

    [Test]
    public void OneItemACosts50()
    {
      _checkout.AddItemAsMoney(_itemA);

      _checkout.GetTotal();
      var result = _checkout.GetTotalFromMoney();

      Assert.That(result.Value, Is.EqualTo(_expectedItemACost));
    }

    [Test]
    public void OneItemBCosts30()
    {
      _checkout.AddItemAsMoney(_itemB);
      var result = _checkout.GetTotalFromMoney();

      Assert.That(result.Value, Is.EqualTo(_expectedItemBCost));
    }
  }

  internal class Money
  {
    public readonly int Value;

    public Money(int value)
    {
      Value = value;
    }

    public Money Add(Money money)
    {
      return new Money(Value + money.Value);
    }
  }

  internal class Checkout
  {
    private readonly Dictionary<string, int> _itemPrices;
    private readonly Dictionary<string, Money> _itemPricesAsMoney;
    private int _total;
    private Money _monetaryValue;

    public Checkout(Dictionary<string, int> itemPrices, Dictionary<string, Money> itemPricesAsMoney)
    {
      _monetaryValue = new Money(0);
      _itemPrices = itemPrices;
      _itemPricesAsMoney = itemPricesAsMoney;
    }

    public int GetTotal()
    {
      return _total;
    }

    public void AddItem(string item)
    {
      _total = _itemPrices[item];
    }

    public Money GetTotalFromMoney()
    {
      return _monetaryValue;
    }

    public void AddItemAsMoney(string item)
    {
      _monetaryValue = _monetaryValue.Add(_itemPricesAsMoney[item]);
    }
  }
}