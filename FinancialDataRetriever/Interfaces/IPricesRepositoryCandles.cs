using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace FinancialDataRetriever.Repositories.Interfaces
{
    public interface IPricesRepositoryCandles
    {
        void ClearCache();
        Task<Candle> Get(string ticker, DateTime date);
        Task Save(string ticker, DateTime date, Candle candle, bool update = false);
        Task<IReadOnlyList<Candle>> Get(string ticker, DateTime? startDate, DateTime? endDate, Period period);
        Task Save(string ticker, DateTime? startDate, DateTime? endDate, Period period, IReadOnlyList<Candle> result);

        IReadOnlyList<InternalCandle> GetAllCandles(string ticker);
        IReadOnlyList<InternalCandle> SaveAllCandles(string ticker, IReadOnlyList<Candle> candles);
        IReadOnlyList<InternalCandle> SaveAllCandles(string ticker, IReadOnlyList<InternalCandle> candles);
        Dictionary<string, IReadOnlyList<InternalCandle>> GetAllCandlesFromCache();

        Task SerializeAllCandles();
        Task DeserializeAllCandles();
    }

    public record DatesCandlesKey(string Ticker, DateTime? StartDate, DateTime? EndDate, Period Period);

    //public record InternalCandle(DateTime DateTime, decimal Open, decimal High, decimal Low, decimal Close, long Volume, decimal AdjustedClose)
    //{
    //    [JsonConstructor]
    //    public InternalCandle(Candle candle)
    //        : this (candle.DateTime, candle.Open, candle.High, candle.Low, candle.Close, candle.Volume, candle.AdjustedClose)
    //    {

    //    }
    //}

    public sealed class InternalCandle
    {
        public InternalCandle() { }

        public InternalCandle(Candle candle)
        {
            DateTime = candle.DateTime;
            Open = candle.Open;
            High = candle.High;
            Low = candle.Low;
            Close = candle.Close;
            Volume = candle.Volume;
            AdjustedClose = candle.AdjustedClose;
        }

        public DateTime DateTime { get; set;  }
        public decimal Open { get; set;  }
        public decimal High { get; set;  }
        public decimal Low { get; set;  }
        public decimal Close { get; set;  }
        public long Volume { get; set;  }
        public decimal AdjustedClose { get; set;  }
    }
}