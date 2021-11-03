using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationStrategies
{
    public class MaxPercentDownAndUp
    {
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandlesToConsider;

        public MaxPercentDownAndUp(
            Dictionary<string, IReadOnlyList<InternalCandle>> allCandlesToConsider)
        {
            _allCandlesToConsider = allCandlesToConsider;
        }

        /// <summary>
        /// Assumes more than 1 candle in each of the <see cref="_allCandlesToConsider"/>
        /// </summary>
        public IReadOnlyList<TickerMaxAndMin> Calculate()
        {
            List<TickerMaxAndMin> resultBuilder = new();
            foreach (var candlesOnTicker in _allCandlesToConsider)
            {
                var first = candlesOnTicker.Value.First();
                var candlesToConsider = candlesOnTicker.Value;
                var maxVal = candlesToConsider.Skip(1).Max(c => c.High);
                var minVal = candlesToConsider.Skip(1).Min(c => c.Low);
                var candleMax = candlesToConsider.First(c => c.High == maxVal);
                var candleMin = candlesToConsider.First(c => c.Low == minVal);
                resultBuilder.Add(new TickerMaxAndMin(candlesOnTicker.Key, first, candleMax, candleMin));
            }
            return resultBuilder;
        }
    }

    public record TickerMaxAndMin(string Ticker, InternalCandle First, InternalCandle Max, InternalCandle Min);
}
