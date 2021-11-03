using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizationStrategies
{
    /// <summary>
    /// Not used yet, needs to be thought out.
    /// </summary>
    public class CandleProcessor
    {
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandlesToConsider;

        public CandleProcessor(
            Dictionary<string, IReadOnlyList<InternalCandle>> allCandlesToConsider)
        {
            _allCandlesToConsider = allCandlesToConsider;
        }

        /// <summary>
        /// Assumes more than 1 candle in each of the <see cref="_allCandlesToConsider"/>
        /// </summary>
        public void Process(
            IAggregator aggregator)
        {
            foreach (var candlesOnTicker in _allCandlesToConsider)
            {
                aggregator.Consider(candlesOnTicker.Key, candlesOnTicker.Value);
            }
        }
    }


    public interface IAggregator
    {
        void Consider(string ticker, IReadOnlyList<InternalCandle> candles);
    }

    public interface IPerCandleAggregator
    {
        void Consider(InternalCandle candle);
    }

    public class PerCandleMaxAndMin
        : IPerCandleAggregator
    {
        public PerCandleMaxAndMin()
        {
        }

        public void Consider(InternalCandle candle)
        {
            throw new NotImplementedException();
        }
    }
}
