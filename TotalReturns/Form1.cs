using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TotalReturns
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Run_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                var dataRetrieval = new FinancialDataRetriever.FinancialDataRetriever();

                var tickers = new HashSet<string>();

                foreach (DataGridViewRow row in dgvCurrentSecurities
                    .Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        txtResult.Text += $"Skipping lines with null values{Environment.NewLine}";
                        continue;
                    }
                    tickers.Add(row.Cells[0].Value.ToString());
                }

                var originalValues = await dataRetrieval.GetHistoricalPrice(DateTime.Parse(txtFromDate.Text), tickers);
                var finalValues = await dataRetrieval.GetHistoricalPrice(DateTime.Parse(txtToDate.Text), tickers);

                decimal totalDifference = 0;
                decimal originalTotal = 0;
                decimal finalTotal = 0;
                foreach(DataGridViewRow row in dgvCurrentSecurities
                    .Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        txtResult.Text += $"Skipping lines with null values{Environment.NewLine}";
                        continue;
                    }
                    var originalCandle = originalValues[row.Cells[0].Value.ToString()];
                    var finalCandle = finalValues[row.Cells[0].Value.ToString()];
                    var lotSizeNotNormalized = row.Cells[1].Value;
                    decimal lotSize;
                    if (lotSizeNotNormalized != null
                        && decimal.TryParse(lotSizeNotNormalized.ToString(), out lotSize))
                    {

                    }
                    else
                    {
                        lotSize = 0;
                    }
                    row.Cells[2].Value = originalCandle.Close;
                    row.Cells[3].Value = finalCandle.Close;
                    var singleInstrumentDifference = finalCandle.Close - originalCandle.Close;
                    row.Cells[4].Value = singleInstrumentDifference;
                    var lotDifference = lotSize * singleInstrumentDifference;
                    row.Cells[5].Value = lotDifference;
                    totalDifference += lotDifference;
                    originalTotal += originalCandle.Close * lotSize;
                    finalTotal += finalCandle.Close * lotSize;
                }

                txtTotalDifference.Text = totalDifference.ToString();
                txtOriginalTotal.Text = originalTotal.ToString();
                txtFinalTotal.Text = finalTotal.ToString();
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

        private void txtToDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtFromDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
