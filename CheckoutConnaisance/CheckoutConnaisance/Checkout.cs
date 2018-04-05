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
      var expectedItemACost = 50;
      var expectedItemBCost = 30;
      _expectedItemACostAsMoney = new Money(expectedItemACost);
      _expectedItemBCostAsMoney = new Money(expectedItemBCost);
      _itemA = "a";
      _itemB = "b";

      var expectedPricesAsMoney = new Dictionary<string, Money>
      {
        {_itemA, _expectedItemACostAsMoney},
        {_itemB, _expectedItemBCostAsMoney}
      };

      _checkout = new Checkout(expectedPricesAsMoney);
    }

    private Checkout _checkout;
    private string _itemA;
    private string _itemB;
    private Money _expectedItemACostAsMoney;
    private Money _expectedItemBCostAsMoney;

    [Test]
    public void OneItemACosts50()
    {
      _checkout.AddItemAsMoney(_itemA);

      var result = _checkout.GetTotalFromMoney();

      Assert.That(result.Value, Is.EqualTo(_expectedItemACostAsMoney.Value));
    }

    [Test]
    public void OneItemBCosts30()
    {
      _checkout.AddItemAsMoney(_itemB);
      var result = _checkout.GetTotalFromMoney();

      Assert.That(result.Value, Is.EqualTo(_expectedItemBCostAsMoney.Value));
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
    private readonly Dictionary<string, Money> _itemPricesAsMoney;
    private Money _monetaryValue;

    public Checkout(Dictionary<string, Money> itemPricesAsMoney)
    {
      _monetaryValue = new Money(0);
      _itemPricesAsMoney = itemPricesAsMoney;
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