using System;
using System.Threading.Tasks;
using YahooFinanceApi;

namespace FinancialDataRetriever.Repositories.Interfaces
{
    public interface IPricesRepositoryCandles
    {
        void ClearCache();
        Task<Candle> Get(string ticker, DateTime date);
        Task Save(string ticker, DateTime date, Candle candle, bool update = false);
    }
}