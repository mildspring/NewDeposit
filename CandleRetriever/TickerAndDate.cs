using System;

namespace CandleRetriever
{
    public record TickerAndDate(string Ticker, DateTime date)
    {
        public static TickerAndDate MapFromCsvString(string csvString)
        {
            var parts = csvString.Split();
            var ticker = parts[0];
            var date = DateTime.Parse(csvString);
            return new TickerAndDate(ticker, date);
        }
    }
    //public class TickerAndDate
    //{
    //    public TickerAndDate(string ticker, DateTime date)
    //    {
    //        Ticker = ticker;
    //        Date = date;
    //    }

    //    public string Ticker { get; }
    //    public DateTime Date { get; }

    //    public static TickerAndDate MapFromCsvString(string csvString)
    //    {
    //        var parts = csvString.Split();
    //        var ticker = parts[0];
    //        var date = DateTime.Parse(csvString);
    //        return new TickerAndDate(ticker, date);
    //    }
    //}
}
