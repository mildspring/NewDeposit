using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace FinancialDataRetriever.Repositories
{
    public class PricesRepositoryCandles
        : IPricesRepositoryCandles
    {
        private ConcurrentDictionary<string, ConcurrentDictionary<DateTime, Candle>> _tickerToDateToCandle;

        public PricesRepositoryCandles()
        {
            _tickerToDateToCandle = new ConcurrentDictionary<string, ConcurrentDictionary<DateTime, Candle>>();
        }

        public Task Save(
            string ticker,
            DateTime date,
            Candle candle,
            bool update = false)
        {
            var dateToCandle = _tickerToDateToCandle.GetOrAdd(
                ticker,
                (theTicker) => new ConcurrentDictionary<DateTime, Candle>() { });

            var storedCandle = dateToCandle.AddOrUpdate(
                date,
                (theDate) => candle, // adding candle
                (theDate, theCandle) => update ? candle : theCandle); // updating candle

            return Task.CompletedTask;
        }

        public Task<Candle> Get(
            string ticker,
            DateTime date)
        {
            var dateToCandle = _tickerToDateToCandle.GetOrAdd(
                ticker,
                (theTicker) => new ConcurrentDictionary<DateTime, Candle>() { });

            dateToCandle.TryGetValue(
                date,
                out var theCandle);

            return Task.FromResult(theCandle);
        }


        public void ClearCache()
        {
            _tickerToDateToCandle.Clear();
        }
    }
}
