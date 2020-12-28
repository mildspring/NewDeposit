using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators
{
    public class Order
    {
        public IList<IPosition> Positions { get; }
        public double LeftOverAmount { get; }

        public Order(IList<IPosition> positions, double leftOverAmount)
        {
            Positions = positions;
            LeftOverAmount = leftOverAmount;
        }
    }
}
