using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators.NUnit
{
    [TestFixture]
    public class PortfolioTests
    {
        [Test]
        public void Can_Create_Portfolio()
        {
            var positions = new List<IPosition>()
            {
                new Position("a", 1, 2),
                new Position("b", 3, 4)
            };
            var portfolio = new Portfolio(positions);

            Assert.That(portfolio.Positions.Count, Is.EqualTo(2));
            Assert.That(portfolio.Positions[0].Name, Is.EqualTo("a"));
        }
    }
}
