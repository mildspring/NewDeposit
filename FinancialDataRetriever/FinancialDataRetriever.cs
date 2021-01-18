using System;
using System.Collections.Generic;
using YahooFinanceApi;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialDataRetriever
{
    public class FinancialDataRetriever
    {
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
    }
}
