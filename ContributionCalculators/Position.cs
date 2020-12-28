using System;
using System.Collections.Generic;
using System.Text;

namespace ContributionCalculators
{
    public class Position
        : IPosition
    {
        public string Name { get; }
        public double Quantity { get; }
        public double Price { get; }

        public Position(string name, double quantity, double price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;
        }
    }
}
