using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators.NUnit
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void Can_Create_Order()
        {
            var positions = new List<IPosition>()
            {
                new Position("a", 1, 2),
                new Position("b", 3, 4)
            };
            var order = new Order(positions, 70.11);

            Assert.That(order.Positions.Count, Is.EqualTo(2));
            Assert.That(order.Positions[0].Name, Is.EqualTo("a"));
            Assert.That(order.LeftOverAmount, Is.EqualTo(70.11));
        }
    }
}
