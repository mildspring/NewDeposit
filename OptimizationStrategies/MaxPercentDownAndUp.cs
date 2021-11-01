using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationStrategies
{
    public class MaxPercentDownAndUp
    {
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandles;

        public MaxPercentDownAndUp(
            Dictionary<string, IReadOnlyList<InternalCandle>> allCandles)
        {
            _allCandles = allCandles;
        }

        public IReadOnlyList<TickerMaxAndMin> Calculate(
            TimeSpan timeSpanSinceBeginning)
        {
            List<TickerMaxAndMin> resultBuilder = new();
            foreach (var candlesOnTicker in _allCandles)
            {
                var first = candlesOnTicker.Value.First();
                var terminationDate = first.DateTime + timeSpanSinceBeginning;
                var candlesToConsider = candlesOnTicker.Value.TakeWhile(c => c.DateTime <= terminationDate);
                var maxVal = candlesToConsider.Max(c => c.High);
                var minVal = candlesToConsider.Min(c => c.Low);
                var candleMax = candlesToConsider.First(c => c.High == maxVal);
                var candleMin = candlesToConsider.First(c => c.Low == minVal);
                resultBuilder.Add(new TickerMaxAndMin(candlesOnTicker.Key, first, candleMax, candleMin));
            }
            return resultBuilder;
        }
    }

    public record TickerMaxAndMin(string Ticker, InternalCandle First, InternalCandle Max, InternalCandle Min);
}
