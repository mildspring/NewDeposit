using ContributionCalculators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewDeposit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvCurrentSecurities_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1
                || e.ColumnIndex == 2)
            {
                if (!double.TryParse(Convert.ToString(e.FormattedValue), out var value))
                {
                    e.Cancel = true;
                    MessageBox.Show("please enter numeric value");
                }
                else
                {
                    // the input is numeric
                }
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            var depositCalculator = new EvenDistributionCalculator();
            try
            {
                txtResult.Clear();

                // validate all securities have a unique name
                if (dgvCurrentSecurities.Rows
                    .Cast<DataGridViewRow>()
                    .Where(row => row.Cells[0].Value != null)
                    .GroupBy(row => row.Cells[0].Value.ToString())
                    .Where(g => g.Count() > 1)
                    .Any())
                {
                    throw new Exception("Duplicate names are not allowed");
                }

                var positions = new List<Position>();
                foreach (DataGridViewRow row in dgvCurrentSecurities
                    .Rows)
                {
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                    {
                        txtResult.Text += $"Skipping lines with null values{Environment.NewLine}";
                        continue;
                    }
                    if (double.Parse(row.Cells[2].Value.ToString()) == 0)
                    {
                        txtResult.Text += $"Skipping lines with value of 0{Environment.NewLine}";
                        continue;
                    }
                    positions.Add(new Position(
                        name: row.Cells[0].Value.ToString(),
                        quantity: double.Parse(row.Cells[1].Value.ToString()),
                        price: double.Parse(row.Cells[2].Value.ToString())));
                }
                var portfolio = new Portfolio(positions.ToList());
                double maxInvestment;
                double.TryParse(txtMaxInvestment.Text, out maxInvestment);
                var result = await depositCalculator.Rebalance(
                    portfolio,
                    chkSellingAllowed.Checked,
                    maxInvestment == 0 ? double.MaxValue : maxInvestment,
                    new Contribution(double.Parse(txtContributionAmount.Text)));

                var resultString = new StringBuilder();
                resultString.Append("Purchase the following:");
                foreach (var position in result.Positions)
                {
                    resultString.Append(Environment.NewLine);
                    resultString.Append($"{position.Name}, {position.Quantity}, ${position.Price * position.Quantity}");
                }
                resultString.Append(Environment.NewLine);
                resultString.Append($"Remaining amount: {result.LeftOverAmount}");
                txtResult.Text += resultString.ToString();

                var dictionaryByName = result.Positions.ToDictionary(p => p.Name, p => p);

                foreach (DataGridViewRow row in dgvCurrentSecurities
                    .Rows)
                {
                    if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                    {
                        continue;
                    }

                    var currentShares = double.Parse(row.Cells["CurrentShares"].Value.ToString());
                    var buyPrice = double.Parse(row.Cells["BuyPrice"].Value.ToString());
                    row.Cells["CurrentInvestment"].Value = currentShares * buyPrice;

                    if (dictionaryByName.TryGetValue(row.Cells["SecurityName"].Value.ToString(), out var resultForRow))
                    {
                        row.Cells["PurchaseShares"].Value = resultForRow.Quantity;
                        row.Cells["Expense"].Value = resultForRow.Quantity * buyPrice;
                        row.Cells["FinalInvestment"].Value = (currentShares + resultForRow.Quantity) * buyPrice;
                    }
                    else
                    {
                        row.Cells["PurchaseShares"].Value = null;
                        row.Cells["Expense"].Value = null;
                        row.Cells["FinalInvestment"].Value = null;
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

        private void dgvCurrentSecurities_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[0].Value = e.Row.Index;
            e.Row.Cells[1].Value = 0;
            e.Row.Cells[2].Value = 0;
        }

        private void txtContributionAmount_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtContributionAmount.Text, out var value))
            {
                MessageBox.Show($"Value has to be numeric.");
            }
        }

        private void btnShowCurrentInvestment_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCurrentSecurities
                    .Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    continue;
                }

                var currentShares = double.Parse(row.Cells["CurrentShares"].Value.ToString());
                var buyPrice = double.Parse(row.Cells["BuyPrice"].Value.ToString());
                row.Cells["CurrentInvestment"].Value = currentShares * buyPrice;
            }
        }
    }
}
