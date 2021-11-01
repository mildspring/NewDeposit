using FinancialDataRetriever.Repositories;
using FinancialDataRetriever.Repositories.Interfaces;
using OptimizationStrategies;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using YahooFinanceApi;

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

                if (rdbMaxPercentInTimePeriod.Checked)
                {
                    var strategy = new MaxPercentDownAndUp(_allCandles);
                    var result = strategy.Calculate(new TimeSpan(24 * int.Parse(txtDays.Text), 0, 0));
                    txtResult.AppendText($"Ticker,First.DateTime,First.High,Max.DateTime,Max.High,Min.DateTime,Min.Low");
                    foreach (var oneResult in result)
                    {
                        txtResult.AppendText(Environment.NewLine);
                        //txtResult.AppendText(oneResult.ToString());
                        txtResult.AppendText($"{oneResult.Ticker},{oneResult.First.DateTime},{oneResult.First.High},{oneResult.Max.DateTime},{oneResult.Max.High},{oneResult.Min.DateTime},{oneResult.Min.Low}");
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
    }
}
