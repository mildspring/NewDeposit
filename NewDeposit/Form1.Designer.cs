namespace NewDeposit
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.boxStrategy = new System.Windows.Forms.GroupBox();
            this.btnMostMoneyInvested = new System.Windows.Forms.RadioButton();
            this.btnEvenDistribution = new System.Windows.Forms.RadioButton();
            this.btnRun = new System.Windows.Forms.Button();
            this.chkSellingAllowed = new System.Windows.Forms.CheckBox();
            this.grpContribution = new System.Windows.Forms.GroupBox();
            this.txtContributionAmount = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SecurityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentShares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentInvestment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseShares = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalInvestment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShowCurrentInvestment = new System.Windows.Forms.Button();
            this.dgvCurrentSecurities = new System.Windows.Forms.DataGridView();
            this.grpMaxContribution = new System.Windows.Forms.GroupBox();
            this.txtMaxInvestment = new System.Windows.Forms.TextBox();
            this.boxStrategy.SuspendLayout();
            this.grpContribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSecurities)).BeginInit();
            this.grpMaxContribution.SuspendLayout();
            this.SuspendLayout();
            // 
            // boxStrategy
            // 
            this.boxStrategy.Controls.Add(this.btnMostMoneyInvested);
            this.boxStrategy.Controls.Add(this.btnEvenDistribution);
            this.boxStrategy.Location = new System.Drawing.Point(32, 329);
            this.boxStrategy.Name = "boxStrategy";
            this.boxStrategy.Size = new System.Drawing.Size(159, 129);
            this.boxStrategy.TabIndex = 1;
            this.boxStrategy.TabStop = false;
            this.boxStrategy.Text = "Strategy";
            // 
            // btnMostMoneyInvested
            // 
            this.btnMostMoneyInvested.AutoSize = true;
            this.btnMostMoneyInvested.Enabled = false;
            this.btnMostMoneyInvested.Location = new System.Drawing.Point(6, 47);
            this.btnMostMoneyInvested.Name = "btnMostMoneyInvested";
            this.btnMostMoneyInvested.Size = new System.Drawing.Size(126, 19);
            this.btnMostMoneyInvested.TabIndex = 0;
            this.btnMostMoneyInvested.Text = "Invest Most Money";
            this.btnMostMoneyInvested.UseVisualStyleBackColor = true;
            // 
            // btnEvenDistribution
            // 
            this.btnEvenDistribution.AutoSize = true;
            this.btnEvenDistribution.Checked = true;
            this.btnEvenDistribution.Location = new System.Drawing.Point(6, 22);
            this.btnEvenDistribution.Name = "btnEvenDistribution";
            this.btnEvenDistribution.Size = new System.Drawing.Size(115, 19);
            this.btnEvenDistribution.TabIndex = 0;
            this.btnEvenDistribution.TabStop = true;
            this.btnEvenDistribution.Text = "Even Distribution";
            this.btnEvenDistribution.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(208, 418);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(199, 40);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // chkSellingAllowed
            // 
            this.chkSellingAllowed.AutoSize = true;
            this.chkSellingAllowed.Enabled = false;
            this.chkSellingAllowed.Location = new System.Drawing.Point(38, 477);
            this.chkSellingAllowed.Name = "chkSellingAllowed";
            this.chkSellingAllowed.Size = new System.Drawing.Size(107, 19);
            this.chkSellingAllowed.TabIndex = 3;
            this.chkSellingAllowed.Text = "Selling Allowed";
            this.chkSellingAllowed.UseVisualStyleBackColor = true;
            // 
            // grpContribution
            // 
            this.grpContribution.Controls.Add(this.txtContributionAmount);
            this.grpContribution.Location = new System.Drawing.Point(208, 329);
            this.grpContribution.Name = "grpContribution";
            this.grpContribution.Size = new System.Drawing.Size(199, 73);
            this.grpContribution.TabIndex = 4;
            this.grpContribution.TabStop = false;
            this.grpContribution.Text = "Contribution";
            // 
            // txtContributionAmount
            // 
            this.txtContributionAmount.Location = new System.Drawing.Point(6, 32);
            this.txtContributionAmount.Name = "txtContributionAmount";
            this.txtContributionAmount.Size = new System.Drawing.Size(126, 23);
            this.txtContributionAmount.TabIndex = 0;
            this.txtContributionAmount.Text = "6000";
            this.txtContributionAmount.TextChanged += new System.EventHandler(this.txtContributionAmount_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 510);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(739, 146);
            this.txtResult.TabIndex = 5;
            // 
            // SecurityName
            // 
            this.SecurityName.HeaderText = "SecurityName";
            this.SecurityName.Name = "SecurityName";
            this.SecurityName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CurrentShares
            // 
            this.CurrentShares.HeaderText = "CurrentShares";
            this.CurrentShares.Name = "CurrentShares";
            this.CurrentShares.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // BuyPrice
            // 
            this.BuyPrice.HeaderText = "BuyPrice";
            this.BuyPrice.Name = "BuyPrice";
            this.BuyPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CurrentInvestment
            // 
            this.CurrentInvestment.HeaderText = "CurrentInvestment";
            this.CurrentInvestment.Name = "CurrentInvestment";
            this.CurrentInvestment.ReadOnly = true;
            this.CurrentInvestment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PurchaseShares
            // 
            this.PurchaseShares.HeaderText = "PurchaseShares";
            this.PurchaseShares.Name = "PurchaseShares";
            this.PurchaseShares.ReadOnly = true;
            this.PurchaseShares.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Expense
            // 
            this.Expense.HeaderText = "Expense";
            this.Expense.Name = "Expense";
            this.Expense.ReadOnly = true;
            this.Expense.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // FinalInvestment
            // 
            this.FinalInvestment.HeaderText = "FinalInvestment";
            this.FinalInvestment.Name = "FinalInvestment";
            this.FinalInvestment.ReadOnly = true;
            this.FinalInvestment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnShowCurrentInvestment
            // 
            this.btnShowCurrentInvestment.Location = new System.Drawing.Point(472, 340);
            this.btnShowCurrentInvestment.Name = "btnShowCurrentInvestment";
            this.btnShowCurrentInvestment.Size = new System.Drawing.Size(327, 23);
            this.btnShowCurrentInvestment.TabIndex = 6;
            this.btnShowCurrentInvestment.Text = "Show Current Investment";
            this.btnShowCurrentInvestment.UseVisualStyleBackColor = true;
            this.btnShowCurrentInvestment.Click += new System.EventHandler(this.btnShowCurrentInvestment_Click);
            // 
            // dgvCurrentSecurities
            // 
            this.dgvCurrentSecurities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentSecurities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SecurityName,
            this.CurrentShares,
            this.BuyPrice,
            this.CurrentInvestment,
            this.PurchaseShares,
            this.Expense,
            this.FinalInvestment});
            this.dgvCurrentSecurities.Location = new System.Drawing.Point(32, 28);
            this.dgvCurrentSecurities.Name = "dgvCurrentSecurities";
            this.dgvCurrentSecurities.Size = new System.Drawing.Size(767, 295);
            this.dgvCurrentSecurities.TabIndex = 0;
            this.dgvCurrentSecurities.Text = "dataGridView1";
            this.dgvCurrentSecurities.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCurrentSecurities_CellValidating);
            this.dgvCurrentSecurities.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvCurrentSecurities_DefaultValuesNeeded);
            // 
            // grpMaxContribution
            // 
            this.grpMaxContribution.Controls.Add(this.txtMaxInvestment);
            this.grpMaxContribution.Location = new System.Drawing.Point(472, 376);
            this.grpMaxContribution.Name = "grpMaxContribution";
            this.grpMaxContribution.Size = new System.Drawing.Size(249, 66);
            this.grpMaxContribution.TabIndex = 7;
            this.grpMaxContribution.TabStop = false;
            this.grpMaxContribution.Text = "Maximum Amount per Final Investment";
            // 
            // txtMaxInvestment
            // 
            this.txtMaxInvestment.Location = new System.Drawing.Point(13, 22);
            this.txtMaxInvestment.Name = "txtMaxInvestment";
            this.txtMaxInvestment.Size = new System.Drawing.Size(188, 23);
            this.txtMaxInvestment.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 668);
            this.Controls.Add(this.grpMaxContribution);
            this.Controls.Add(this.btnShowCurrentInvestment);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.grpContribution);
            this.Controls.Add(this.chkSellingAllowed);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.boxStrategy);
            this.Controls.Add(this.dgvCurrentSecurities);
            this.Name = "Form1";
            this.Text = "Form1";
            this.boxStrategy.ResumeLayout(false);
            this.boxStrategy.PerformLayout();
            this.grpContribution.ResumeLayout(false);
            this.grpContribution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSecurities)).EndInit();
            this.grpMaxContribution.ResumeLayout(false);
            this.grpMaxContribution.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox boxStrategy;
        private System.Windows.Forms.RadioButton btnMostMoneyInvested;
        private System.Windows.Forms.RadioButton btnEvenDistribution;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dgvCurrentSecurities;
        private System.Windows.Forms.CheckBox chkSellingAllowed;
        private System.Windows.Forms.GroupBox grpContribution;
        private System.Windows.Forms.TextBox txtContributionAmount;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecurityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentShares;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentInvestment;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseShares;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expense;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalInvestment;
        private System.Windows.Forms.Button btnShowCurrentInvestment;
        private System.Windows.Forms.GroupBox grpMaxContribution;
        private System.Windows.Forms.TextBox txtMaxInvestment;
    }
}

