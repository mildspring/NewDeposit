using FinancialDataRetriever.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace FinancialDataRetriever.Repositories
{
    public class PricesRepositoryCandles
        : IPricesRepositoryCandles
    {
        private ConcurrentDictionary<string, ConcurrentDictionary<DateTime, Candle>> _tickerToDateToCandle;
        private ConcurrentDictionary<DatesCandlesKey, IReadOnlyList<Candle>> _datesCandleKeyToCandles;
        private ConcurrentDictionary<string, IReadOnlyList<InternalCandle>> _tickerToCandles;
        private string _cacheFolder;

        public PricesRepositoryCandles(
            string cacheFolder)
        {
            _tickerToDateToCandle = new ConcurrentDictionary<string, ConcurrentDictionary<DateTime, Candle>>();

            _datesCandleKeyToCandles = new ConcurrentDictionary<DatesCandlesKey, IReadOnlyList<Candle>>();

            _tickerToCandles = new ConcurrentDictionary<string, IReadOnlyList<InternalCandle>>();

            _cacheFolder = cacheFolder;
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
            _datesCandleKeyToCandles.Clear();
            _tickerToCandles.Clear();
        }        

        public Task<IReadOnlyList<Candle>> Get(string ticker, DateTime? startDate, DateTime? endDate, Period period)
        {
            var key = new DatesCandlesKey(ticker, startDate, endDate, period);

            var dateToCandles = _datesCandleKeyToCandles.GetOrAdd(
                key,
                (theTicker) => new List<Candle>() { });

            return Task.FromResult(dateToCandles);
        }

        public Task Save(string ticker, DateTime? startDate, DateTime? endDate, Period period, IReadOnlyList<Candle> result)
        {
            var key = new DatesCandlesKey(ticker, startDate, endDate, period);

            var dateToCandles = _datesCandleKeyToCandles.GetOrAdd(
                key,
                (theTicker) => result);

            return Task.CompletedTask;
        }

        public IReadOnlyList<InternalCandle> GetAllCandles(string ticker)
        {
            _tickerToCandles.TryGetValue(
                ticker,
                out var dateToCandles);

            return dateToCandles;
        }

        public IReadOnlyList<InternalCandle> SaveAllCandles(string ticker, IReadOnlyList<Candle> candles)
        {
            return SaveAllCandles(ticker, candles.Select(c => new InternalCandle(c)).ToList());
        }

        public IReadOnlyList<InternalCandle> SaveAllCandles(string ticker, IReadOnlyList<InternalCandle> candles)
        {
            var dateToCandles = _tickerToCandles.AddOrUpdate(
                ticker,
                (theTicker) => candles,
                (theTicker, existing) =>
                {
                    var existingDictionary = existing.ToDictionary(x => x.DateTime);
                    foreach (var candle in candles)
                    {
                        existingDictionary[candle.DateTime] = candle;
                    }
                    return existingDictionary.Values.ToList();
                });
            return dateToCandles;
        }

        public async Task SerializeAllCandles()
        {
            foreach (var tickerToCandles in _tickerToCandles)
            {
                var ticker = tickerToCandles.Key;
                var value = tickerToCandles.Value;
                var serialized = JsonConvert.SerializeObject(value, Formatting.Indented);
                await File.WriteAllTextAsync(Path.Combine(_cacheFolder, "Candles", $"{ticker}.json"), serialized);
            }
        }

        public async Task DeserializeAllCandles()
        {
            var filePaths = Directory.EnumerateFiles(Path.Combine(_cacheFolder, "Candles"));
            foreach (var filePath in filePaths)
            {
                var fileName = Path.GetFileName(filePath);
                var ticker = fileName.Split(".")[0];
                var text = await File.ReadAllTextAsync(filePath);
                var candles = JsonConvert.DeserializeObject<List<InternalCandle>>(text);
                SaveAllCandles(ticker, candles);
            }
        }

        public Dictionary<string, IReadOnlyList<InternalCandle>> GetAllCandlesFromCache()
        {
            var dictionary = _tickerToCandles.ToDictionary(k => k.Key, v => v.Value);
            return dictionary;
        }
    }
}
