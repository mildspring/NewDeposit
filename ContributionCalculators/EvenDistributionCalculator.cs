using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities;

namespace ContributionCalculators
{
    public class EvenDistributionCalculator
    {
        public EvenDistributionCalculator()
        {
        }

        public async Task<Order> Rebalance(
            Portfolio portfolio,
            bool sellingAllowed,
            double keepInvestmentsAtOrBelow,
            Contribution amount)
        {
            if (sellingAllowed)
            {
                throw new NotImplementedException($"Parameter {sellingAllowed} has to be false.");
            }

            var t = Task.Run(() => Perform(portfolio, amount, keepInvestmentsAtOrBelow));
            return await t;
        }

        private Order Perform(
            Portfolio portfolio,
            Contribution amount,
            double keepInvestmentsAtOrBelow)
        {
            var workPositions = portfolio.Positions
                .Select(p => new PositionInProgress(p))
                .ToList();
            var workAmount = amount.Value;

            while (true)
            {
                var positionsSortedByInvestment = workPositions                    
                    .OrderBy(p => p.CalculatedInvestment())
                    .ToList();

                var updatedOne = false;
                for (int i = 0; !updatedOne && i < positionsSortedByInvestment.Count; i++)
                {
                    if (positionsSortedByInvestment[i].Price <= workAmount
                        && (keepInvestmentsAtOrBelow == 0 ? double.MaxValue : keepInvestmentsAtOrBelow) >= (positionsSortedByInvestment[i].CalculatedInvestment() + positionsSortedByInvestment[i].Price))
                    {
                        // found an item to update
                        positionsSortedByInvestment[i].AddOne();

                        workAmount -= positionsSortedByInvestment[i].Price;

                        updatedOne = true;
                    }
                }

                if (!updatedOne)
                {
                    return new Order(
                        positionsSortedByInvestment
                            .Select(p => p.GeneratePositionForResponse())
                            .ToList(),
                        workAmount);
                }

                workPositions = positionsSortedByInvestment;
            }
        }

        private class PositionInProgress
            : IPosition
        {
            public string Name { get; }

            public double Quantity { get; }

            public double Price { get; }

            private int _additionalQuantity;

            public void AddOne()
            {
                _additionalQuantity++;
            }

            public PositionInProgress(
                string name,
                double quantity,
                double price)
            {
                Name = name;
                Quantity = quantity;
                Price = price;
            }

            public PositionInProgress(
                IPosition position)
                : this (
                      name: position.Name,
                      quantity: position.Quantity,
                      price: position.Price)
            {
            }

            public IPosition GeneratePositionForResponse()
            {
                return new Position(
                    name: Name,
                    quantity: _additionalQuantity,
                    price: Price);
            }

            internal double CalculatedInvestment()
            {
                return Price * (Quantity + _additionalQuantity);
            }
        }
    }
}