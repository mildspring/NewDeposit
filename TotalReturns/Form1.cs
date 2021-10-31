using FinancialDataRetriever.Repositories;
using FinancialDataRetriever.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TotalReturns
{
    public partial class Form1 : Form
    {
        private IPricesRepositoryCandles _candleRepository;
        public Form1()
        {
            InitializeComponent();
            _candleRepository = new PricesRepositoryCandles(null);
        }

        private async void Run_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;

                var dataRetrieval = new FinancialDataRetriever.FinancialDataRetriever(_candleRepository);

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
                foreach (DataGridViewRow row in dgvCurrentSecurities
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
                    row.Cells[6].Value = (finalCandle.Close - originalCandle.Close) / originalCandle.Close * 100;
                    totalDifference += lotDifference;
                    originalTotal += originalCandle.Close * lotSize;
                    finalTotal += finalCandle.Close * lotSize;
                }

                txtTotalDifference.Text = totalDifference.ToString();
                txtOriginalTotal.Text = originalTotal.ToString();
                txtFinalTotal.Text = finalTotal.ToString();
                txtPercent.Text = ((finalTotal - originalTotal) / originalTotal * 100).ToString();
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

        private void btnSerialize_Click(object sender, EventArgs e)
        {
            try
            {
                // Displays a SaveFileDialog so the user can save the Image
                // assigned to Button2.
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Json File|*.json";
                saveFileDialog1.Title = "Save a Json File";
                saveFileDialog1.ShowDialog();
                saveFileDialog1.RestoreDirectory = true;

                var lots = new List<SerializedData.Lot>();
                foreach (DataGridViewRow row in dgvCurrentSecurities
                        .Rows)
                {
                    if (row.Cells[0].Value == null)
                    {
                        txtResult.Text += $"Skipping lines with null values{Environment.NewLine}";
                        continue;
                    }
                    lots.Add(new SerializedData.Lot()
                    {
                        Quantity = decimal.Parse(row.Cells[1].Value.ToString()),
                        Ticker = row.Cells[0].Value.ToString()
                    });
                }
                var saveData = new SerializedData()
                {
                    FromDate = txtFromDate.Text,
                    ToDate = txtToDate.Text,
                    Lots = lots,
                };

                var serializedString = JsonConvert.SerializeObject(saveData, Formatting.Indented);

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    // Saves the Image via a FileStream created by the OpenFile method.
                    using (var stream = saveFileDialog1.OpenFile())
                    {
                        var sw = new StreamWriter(stream);
                        sw.WriteLine(serializedString);
                        sw.Close();
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

        private void btnDeserialize_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\";
                openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog1.FilterIndex = 2;
                openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    var filePath = openFileDialog1.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog1.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var fileContent = reader.ReadToEnd();

                        var data = JsonConvert.DeserializeObject<SerializedData>(fileContent);
                        txtToDate.Text = data.ToDate;
                        txtFromDate.Text = data.FromDate;

                        dgvCurrentSecurities.Rows.Clear();

                        foreach (var lot in data.Lots)
                        {
                            DataGridViewRow row = (DataGridViewRow)dgvCurrentSecurities.Rows[0].Clone();
                            row.Cells[0].Value = lot.Ticker;
                            row.Cells[1].Value = lot.Quantity;
                            dgvCurrentSecurities.Rows.Add(row);
                        }

                        dgvCurrentSecurities.Refresh();
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
    }
}
