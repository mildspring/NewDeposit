using FinancialDataRetriever;
using FinancialDataRetriever.Repositories;
using FinancialDataRetriever.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CandleRetriever
{
    public partial class Form1 : Form
    {
        FinancialDataRetriever.FinancialDataRetriever _financialDataRetriever;
        IPricesRepositoryCandles _repository;

        public Form1()
        {
            InitializeComponent();
            var cacheFolder = ConfigurationManager.AppSettings["cacheFolder"];
            Directory.CreateDirectory(cacheFolder);

            _repository = new PricesRepositoryCandles(
                    cacheFolder);

            _financialDataRetriever = new FinancialDataRetriever.FinancialDataRetriever(
                _repository);
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                //var data = GetAllTickersOnDates();
                var data = txtTickersAndDates.Text
                    .Split(Environment.NewLine)
                    .Where(line => !string.IsNullOrWhiteSpace(line))
                    .ToList();

                var issues = new List<TickerAndException>();
                var values = await _financialDataRetriever.GetHistoricalPrice(data, issues);

                if (issues.Any())
                {
                    foreach (var issue in issues)
                    {
                        txtIssues.AppendText(Environment.NewLine);
                        txtIssues.AppendText(issue.Ticker);
                        txtIssues.AppendText(issue.Exception.Message);
                    }
                }
                else
                {
                    MessageBox.Show("done, all fine");
                }

                // organize data based on dates, as that's how the api works
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

        public IReadOnlyList<TickerAndDate> GetAllTickersOnDates()
        {
            var listOfTickersOnDates = new List<TickerAndDate>();
            foreach (var line in txtTickersAndDates.Text.Split(Environment.NewLine)
                .Where(line => !string.IsNullOrEmpty(line)))
            {
                var tickerAndDate = TickerAndDate.MapFromCsvString(line);
                listOfTickersOnDates.Add(tickerAndDate);
            }
            return listOfTickersOnDates;
        }

        private async void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                await _repository.SerializeAllCandles();
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

        private void btnClearIssues_Click(object sender, EventArgs e)
        {
            txtIssues.Text = string.Empty;
        }
    }
}
