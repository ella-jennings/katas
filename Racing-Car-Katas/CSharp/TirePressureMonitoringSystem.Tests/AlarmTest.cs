
using NUnit.Framework;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    [TestFixture]
    public class AlarmTest
    {
        [Test]
        public void AlarmIsOffByDefault()
        {
            Alarm alarm = new Alarm(new Sensor());
            Assert.AreEqual(false, alarm.AlarmOn);
        }

      [Test]
      public void AlarmIsOn_WhenPressureTooHigh()
      {
        var alarm = new Alarm(new TestSensor(22));
        alarm.Check();
        Assert.That(alarm.AlarmOn, Is.True);
      }

    [Test]
    public void AlarmIsOn_WhenPressureTooLow()
    {
      var alarm = new Alarm(new TestSensor(16.9));
      alarm.Check();
      Assert.That(alarm.AlarmOn, Is.True);
    }

    [Test]
    public void AlarmIsOff_whenPressureWithinNormalRange()
    {
      var alarm = new Alarm(new TestSensor(20));
      alarm.Check();
      Assert.That(alarm.AlarmOn, Is.False);
    }
  }

  internal class TestSensor : Sensor
  {
    private readonly double _i;

    public TestSensor(double i)
    {
      _i = i;
    }
    public override double PopNextPressurePsiValue()
    {
      return _i;
    }
  }
}