using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators
{
    public interface IPosition
    {
        public string Name { get; }
        public double Quantity { get; }
        public double Price { get; }
    }
}
