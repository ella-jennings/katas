using NUnit.Framework;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
  [TestFixture]
  public class TurnTicketDispenserTests
  {
    [Test]
    public void MultipleTicketDispensers_ShouldNotDispenseTheSameNumberTickets()
    {
      var ticketDispenser1 = new TicketDispenser();
      var ticketDispenser2 = new TicketDispenser();
      var turnticket1 = ticketDispenser1.GetTurnTicket();

      for (var i = 1; i < 100; i++)
      {
        var turnticket = ticketDispenser2.GetTurnTicket();
        Assert.That(turnticket1.TurnNumber, !Is.EqualTo(turnticket.TurnNumber));
      }
      
    }
  }
}
