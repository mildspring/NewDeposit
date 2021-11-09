using FinancialDataRetriever.Repositories;
using FinancialDataRetriever.Repositories.Interfaces;
using OptimizationStrategies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace LookForIpoOptimization
{
    public partial class Form1 : Form
    {
        IPricesRepositoryCandles _repository;
        Dictionary<string, IReadOnlyList<InternalCandle>> _allCandles;

        public Form1()
        {
            InitializeComponent();

            var cacheFolder = ConfigurationManager.AppSettings["cacheFolder"];

            _repository = new PricesRepositoryCandles(
                    cacheFolder);

            var defaultFromDate = DateTime.Now;
            defaultFromDate = defaultFromDate.Subtract(new TimeSpan(365, 0, 0, 0, 0));
            defaultFromDate = new DateTime(defaultFromDate.Year, 1, 1);
            txtSinceDate.Text = defaultFromDate.ToString("yyyy-MM-dd");
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                if (_allCandles == null)
                {
                    await _repository.DeserializeAllCandles();
                    var allCandles = _repository.GetAllCandlesFromCache();
                    _allCandles = Limit(allCandles);
                }

                // apply filters
                var filteredCandles = Filter(_allCandles);

                if (rdbMaxPercentInTimePeriod.Checked)
                {
                    var strategy = new MaxPercentDownAndUp(filteredCandles);
                    var result = strategy.Calculate();
                    txtResult.AppendText($"Ticker,First.DateTime,First.High,Max.DateTime,Max.High,Min.DateTime,Min.Low");
                    txtResult.AppendText(Environment.NewLine);
                    foreach (var oneResult in result)
                    {
                        txtResult.AppendText($"{oneResult.Ticker},{oneResult.First.DateTime},{oneResult.First.High},{oneResult.Max.DateTime},{oneResult.Max.High},{oneResult.Min.DateTime},{oneResult.Min.Low}");
                        txtResult.AppendText(Environment.NewLine);
                    }
                }
                if (rdbIncreasedOverPercent.Checked)
                {
                    var strategy = new HowManyWentUpBy(filteredCandles);
                    var result = strategy.Calculate(decimal.Parse(txtIncreasedOverPercent.Text));
                    txtResult.AppendText(result.ToString());
                    txtResult.AppendText(Environment.NewLine);
                }
                if (rdbLowestPriceFollowedByHighestPrice.Checked)
                {
                    var strategy = new LowestPriceFollowedByHighestPrice(filteredCandles);
                    var result = strategy.Calculate(int.Parse(txtFirstFewDays.Text));
                    txtResult.AppendText($"Ticker,Min.DateTime,Min.Low,Max.DateTime,Max.High");
                    txtResult.AppendText(Environment.NewLine);
                    foreach (var oneResult in result)
                    {
                        txtResult.AppendText($"{oneResult.Ticker},{oneResult.Min.DateTime},{oneResult.Min.Low},{oneResult.Max.DateTime},{oneResult.Max.High}");
                        txtResult.AppendText(Environment.NewLine);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private Dictionary<string, IReadOnlyList<InternalCandle>> Filter(Dictionary<string, IReadOnlyList<InternalCandle>> allCandles)
        {
            // 1. limit by number of days
            var timeSpanSinceBeginning = new TimeSpan(24 * int.Parse(txtDays.Text), 0, 0);
            var filteredCandles = _allCandles
                .Select(candlesOnTicker =>
                {
                    var first = candlesOnTicker.Value.First();
                    var terminationDate = first.DateTime + timeSpanSinceBeginning;
                    var candlesToConsider = candlesOnTicker.Value.TakeWhile(c => c.DateTime <= terminationDate).ToList();

                    return new KeyValuePair<string, IReadOnlyList<InternalCandle>>(candlesOnTicker.Key, candlesToConsider);
                });

            // 2. limit to make sure at least this many candles exist
            var minimumNumberOfCandles = string.IsNullOrWhiteSpace(txtMinimumNumberOfCandles.Text)
                ? 0
                : int.Parse(txtMinimumNumberOfCandles.Text);
            filteredCandles = filteredCandles
                .Where(candlesOnTicker => candlesOnTicker.Value.Count >= minimumNumberOfCandles);

            return filteredCandles.ToDictionary(nvp => nvp.Key, nvp => nvp.Value);
        }

        private Dictionary<string, IReadOnlyList<InternalCandle>> Limit(Dictionary<string, IReadOnlyList<InternalCandle>> allCandles)
        {
            if (string.IsNullOrWhiteSpace(txtSinceDate.Text))
            {
                return allCandles;
            }

            var date = DateTime.Parse(txtSinceDate.Text);

            var data = allCandles
                .Where(nvp => nvp.Value.First().DateTime >= date)
                .ToDictionary(k => k.Key, v => v.Value);
            return data;
        }

        private async void btnReload_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                _repository.ClearCache();
                await _repository.DeserializeAllCandles();
                var allCandles = _repository.GetAllCandlesFromCache();
                _allCandles = Limit(allCandles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Enabled = true;
            }
        }
    }
}
