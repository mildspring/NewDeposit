using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationStrategies
{
    public class LowestPriceFollowedByHighestPrice
    {
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandlesToConsider;

        public LowestPriceFollowedByHighestPrice(
            Dictionary<string, IReadOnlyList<InternalCandle>> allCandlesToConsider)
        {
            _allCandlesToConsider = allCandlesToConsider;
        }

        /// <summary>
        /// Assumes more than 1 candle in each of the <see cref="_allCandlesToConsider"/>
        /// </summary>
        public IReadOnlyList<TickerFirstPeriodMinSecondPeriodMax> Calculate(
            int firstNumberOfDays,
            bool skipFirstDay = true)
        {
            List<TickerFirstPeriodMinSecondPeriodMax> resultBuilder = new();
            var firstDaySkip = skipFirstDay ? 1 : 0;
            foreach (var candlesOnTicker in _allCandlesToConsider)
            {
                var first = candlesOnTicker.Value.First();
                var candlesToConsider = candlesOnTicker.Value;
                var maxVal = candlesToConsider.Skip(firstDaySkip).Skip(firstNumberOfDays).Max(c => c.High);
                var minVal = candlesToConsider.Skip(firstDaySkip).Take(firstNumberOfDays).Min(c => c.Low);
                var candleMax = candlesToConsider.Skip(firstDaySkip).Skip(firstNumberOfDays).First(c => c.High == maxVal);
                var candleMin = candlesToConsider.Skip(firstDaySkip).Take(firstNumberOfDays).First(c => c.Low == minVal);
                resultBuilder.Add(new TickerFirstPeriodMinSecondPeriodMax(candlesOnTicker.Key, candleMin, candleMax));
            }
            return resultBuilder;
        }
    }

    public record TickerFirstPeriodMinSecondPeriodMax(string Ticker, InternalCandle Min, InternalCandle Max);
}
