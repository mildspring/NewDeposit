using System;
using System.Collections.Generic;
using YahooFinanceApi;
using System.Linq;
using System.Threading.Tasks;
using FinancialDataRetriever.Repositories.Interfaces;

namespace FinancialDataRetriever
{
    public class FinancialDataRetriever
    {
        private readonly IPricesRepositoryCandles _candleRepository;

        public FinancialDataRetriever(
            IPricesRepositoryCandles candleRepository)
        {
            _candleRepository = candleRepository;
        }

        public async Task<IReadOnlyDictionary<string, Security>> GetData(IList<string> symbols)
        {
            var data = await Yahoo.Symbols(symbols.ToArray()).Fields(
                Field.Ask,
                Field.AskSize,
                Field.AverageDailyVolume10Day,
                Field.AverageDailyVolume3Month,
                Field.Bid,
                Field.BidSize,
                Field.BookValue,
                Field.Currency,
                Field.DividendDate,
                Field.EarningsTimestamp,
                Field.EarningsTimestampEnd,
                Field.EarningsTimestampStart,
                Field.EpsForward,
                Field.EpsTrailingTwelveMonths,
                Field.Exchange,
                Field.ExchangeDataDelayedBy,
                Field.ExchangeTimezoneName,
                Field.ExchangeTimezoneShortName,
                Field.FiftyDayAverage,
                Field.FiftyDayAverageChange,
                Field.FiftyDayAverageChangePercent,
                Field.FiftyTwoWeekHigh,
                Field.FiftyTwoWeekHighChange,
                Field.FiftyTwoWeekHighChangePercent,
                Field.FiftyTwoWeekLow,
                Field.FiftyTwoWeekLowChange,
                Field.FiftyTwoWeekLowChangePercent,
                Field.FinancialCurrency,
                Field.ForwardPE,
                Field.FullExchangeName,
                Field.GmtOffSetMilliseconds,
                Field.Language,
                Field.LongName,
                Field.Market,
                Field.MarketCap,
                Field.MarketState,
                Field.MessageBoardId,
                Field.PriceHint,
                Field.PriceToBook,
                Field.QuoteSourceName,
                Field.QuoteType,
                Field.RegularMarketChange,
                Field.RegularMarketChangePercent,
                Field.RegularMarketDayHigh,
                Field.RegularMarketDayLow,
                Field.RegularMarketOpen,
                Field.RegularMarketPreviousClose,
                Field.RegularMarketPrice,
                Field.RegularMarketTime,
                Field.RegularMarketVolume,
                Field.PostMarketChange,
                Field.PostMarketChangePercent,
                Field.PostMarketPrice,
                Field.PostMarketTime,
                Field.SharesOutstanding,
                Field.ShortName,
                Field.SourceInterval,
                Field.Symbol,
                Field.Tradeable,
                Field.TrailingAnnualDividendRate,
                Field.TrailingAnnualDividendYield,
                Field.TrailingPE,
                Field.TwoHundredDayAverage,
                Field.TwoHundredDayAverageChange,
                Field.TwoHundredDayAverageChangePercent)
                .QueryAsync();

            return data;
        }

        public async Task<Dictionary<string, Candle>> GetHistoricalPrice(
            DateTime date,
            HashSet<string> tickers)
        {
            var dateToCandleMap = new Dictionary<string, Candle>();

            foreach (var ticker in tickers)
            {
                var startTime = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);

                var data = await _candleRepository.Get(ticker, startTime);
                if (data == null)
                {
                    var endTime = new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
                    var result = await Yahoo.GetHistoricalAsync(ticker, startTime, endTime, Period.Daily);
                    if (result.Count != 1)
                    {
                        //throw new Exception($"Unexpected number of results {result.Count}, expected one.");
                    }
                    data = result.First();
                    await _candleRepository.Save(ticker, startTime, data);
                }
                
                dateToCandleMap.Add(ticker, data);
            }
            return dateToCandleMap;
        }
    }
}
