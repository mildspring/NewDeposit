using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Utilities.NUnit
{
    [TestFixture]
    public class CollectionExtensionsTest
    {
        [Test]
        public void ToListFromItem_Works_For_Tuple()
        {
            var original = new Tuple<string>("test string");

            var result = original.ToListFromItem();

            Assert.That(result, Is.TypeOf<List<Tuple<string>>>());
            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Item1, Is.EqualTo(original.Item1));
        }
    }
}
