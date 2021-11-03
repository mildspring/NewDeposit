using FinancialDataRetriever.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OptimizationStrategies
{
    public class HowManyWentUpBy
    {
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandlesToConsider;

        public HowManyWentUpBy(
            Dictionary<string, IReadOnlyList<InternalCandle>> allCandlesToConsider)
        {
            _allCandlesToConsider = allCandlesToConsider;
        }

        /// <summary>
        /// Assumes more than 1 candle in each of the <see cref="_allCandlesToConsider"/>
        /// </summary>
        public HowManyWentUpByResponse Calculate(
            decimal percentUp)
        {
            MaxPercentDownAndUp upOrDown = new(_allCandlesToConsider);
            var values = upOrDown.Calculate();

            HowManyWentUpByResponse response = new(0, 0, 0, 0);
            values
                .ToList()
                .ForEach((System.Action<TickerMaxAndMin>)(value =>
            {
                // calculation as per https://www.investopedia.com/ask/answers/how-do-you-calculate-percentage-gain-or-loss-investment/#:~:text=Take%20the%20selling%20price%20and,percentage%20change%20in%20the%20investment.
                var percentIncrease = (value.Max.High - value.First.High) / value.First.High * 100;
                var up = (percentIncrease >= percentUp);
                var total = response.Total + 1;
                var totalOverOrAt = response.TotalOverOrAt + (up ? 1 : 0);
                response = new(
                    Total: total,
                    TotalOverOrAt: totalOverOrAt,
                    TotalUnder: response.TotalUnder + (up ? 0 : 1),
                    PercentOverOrAt: (double) totalOverOrAt / total * 100);
            }));

            return response;
        }
    }

    public record HowManyWentUpByResponse(int Total, int TotalOverOrAt, int TotalUnder, double PercentOverOrAt);
}
