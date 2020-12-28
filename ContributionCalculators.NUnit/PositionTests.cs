using NUnit.Framework;
using System;

namespace ContributionCalculators.NUnit
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void Can_Create_Position()
        {
            var position = new Position("IBM", 10.1, 20.2);

            Assert.That(position.Name, Is.EqualTo("IBM"));
            Assert.That(position.Quantity, Is.EqualTo(10.1));
            Assert.That(position.Price, Is.EqualTo(20.2));
        }
    }
}
