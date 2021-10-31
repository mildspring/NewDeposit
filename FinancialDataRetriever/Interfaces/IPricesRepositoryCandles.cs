using System;
using System.Collections.Generic;
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

        IReadOnlyList<Candle> GetAllCandles(string ticker);
        void SaveAllCandles(string ticker, IReadOnlyList<Candle> candles);

        Task SerializeAllCandles();
        Task DeserializeAllCandles();
    }
}