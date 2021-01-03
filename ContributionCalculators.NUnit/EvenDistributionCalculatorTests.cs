using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContributionCalculators.NUnit
{
    [TestFixture]
    public class EvenDistributionCalculatorTests
    {
        [Test]
        public async Task Can_Run_For_Single_Security_Portfolio()
        {
            var portfolio = new Portfolio(new List<IPosition>
            {
                new Position("position1", quantity: 1, price: 3)
            });
            var contribution = new Contribution(32);

            var calculator = new EvenDistributionCalculator();
            var result = await calculator.Rebalance(portfolio, false, 0, contribution);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Positions, Is.Not.Null);
            Assert.That(result.Positions.Count, Is.EqualTo(1));
            Assert.That(result.LeftOverAmount, Is.EqualTo(2));
            Assert.That(result.Positions[0].Price, Is.EqualTo(3));
            Assert.That(result.Positions[0].Quantity, Is.EqualTo(10));
        }

        [Test]
        public async Task Can_Run_With_Maximum_Investment_Amount_Portfolio()
        {
            var portfolio = new Portfolio(new List<IPosition>
            {
                new Position("position1", quantity: 1, price: 3)
            });
            var contribution = new Contribution(32);

            var calculator = new EvenDistributionCalculator();
            var result = await calculator.Rebalance(portfolio, false, 9, contribution);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Positions, Is.Not.Null);
            Assert.That(result.Positions.Count, Is.EqualTo(1));
            Assert.That(result.LeftOverAmount, Is.EqualTo(26));
            Assert.That(result.Positions[0].Price, Is.EqualTo(3));
            Assert.That(result.Positions[0].Quantity, Is.EqualTo(2));
        }

        [TestFixture]
        public class TestStraightForwardMultiplePositionPortfolio
        {
            IPosition _position1, _position2, _position3;

            [OneTimeSetUp]
            public async Task Setup()
            {
                var portfolio = new Portfolio(new List<IPosition>
                {
                    new Position("position1", quantity: 1, price: 3),
                    new Position("position2", quantity: 20, price: 3),
                    new Position("position3", quantity: 3, price: 3)
                });
                var contribution = new Contribution(13);

                var calculator = new EvenDistributionCalculator();
                var result = await calculator.Rebalance(portfolio, false, 0, contribution);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Positions, Is.Not.Null);
                Assert.That(result.Positions.Count, Is.EqualTo(3));
                Assert.That(result.LeftOverAmount, Is.EqualTo(1));

                _position1 = result.Positions.First(p => p.Name == "position1");
                _position2 = result.Positions.First(p => p.Name == "position2");
                _position3 = result.Positions.First(p => p.Name == "position3");
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_1()
            {
                Assert.That(_position1.Quantity, Is.EqualTo(3));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_2()
            {
                Assert.That(_position2.Quantity, Is.EqualTo(0));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_3()
            {
                Assert.That(_position3.Quantity, Is.EqualTo(1));
            }
        }

        [TestFixture]
        public class TestRealisticMultiplePositionPortfolio
        {
            private IPosition _dia, _voo, _spgi, _vig, _oneq;
            private double _leftOver;

            [OneTimeSetUp]
            public async Task Setup()
            {
                var portfolio = new Portfolio(new List<IPosition>
                {
                    new Position("DIA", quantity: 8, price: 302),
                    new Position("VOO", quantity: 12, price: 339),
                    new Position("SPGI", quantity: 13, price: 316),
                    new Position("VIG", quantity: 31, price: 139),
                    new Position("ONEQ", quantity: 9, price: 498),
                });
                var contribution = new Contribution(6200);

                var calculator = new EvenDistributionCalculator();
                var result = await calculator.Rebalance(portfolio, false, 0, contribution);

                Assert.That(result, Is.Not.Null);
                Assert.That(result.Positions, Is.Not.Null);
                Assert.That(result.Positions.Count, Is.EqualTo(5));

                _leftOver = result.LeftOverAmount;
                _dia = result.Positions.First(p => p.Name == "DIA");
                _voo = result.Positions.First(p => p.Name == "VOO");
                _spgi = result.Positions.First(p => p.Name == "SPGI");
                _vig = result.Positions.First(p => p.Name == "VIG");
                _oneq = result.Positions.First(p => p.Name == "ONEQ");
            }

            [Test]
            public void Validate_Correct_Left_Over_Amount()
            {
                Assert.That(_leftOver, Is.EqualTo(46.0));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_DIA()
            {
                Assert.That(_dia.Quantity, Is.EqualTo(9));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_VOO()
            {
                Assert.That(_voo.Quantity, Is.EqualTo(3));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_SPGI()
            {
                Assert.That(_spgi.Quantity, Is.EqualTo(3));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_VIG()
            {
                Assert.That(_vig.Quantity, Is.EqualTo(7));
            }

            [Test]
            public void Validate_Correct_Number_Was_Added_To_Position_ONEQ()
            {
                Assert.That(_oneq.Quantity, Is.EqualTo(1));
            }
        }
    }
}
