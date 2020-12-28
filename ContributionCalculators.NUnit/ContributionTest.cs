using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators.NUnit
{
    [TestFixture]
    public class ContributionTest
    {
        [Test]
        public void Can_Create_Contribution()
        {
            var amount = new Contribution(100.200);

            Assert.That(amount.Value, Is.EqualTo(100.2));
        }
    }
}
