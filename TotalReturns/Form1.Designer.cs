namespace TotalReturns
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFromDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtToDate = new System.Windows.Forms.TextBox();
            this.Run = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtTotalDifference = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOriginalTotal = new System.Windows.Forms.TextBox();
            this.LotDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LotSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCurrentSecurities = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFinalTotal = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSecurities)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(746, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "From date:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtFromDate
            // 
            this.txtFromDate.Location = new System.Drawing.Point(746, 36);
            this.txtFromDate.Name = "txtFromDate";
            this.txtFromDate.Size = new System.Drawing.Size(100, 23);
            this.txtFromDate.TabIndex = 2;
            this.txtFromDate.TextChanged += new System.EventHandler(this.txtFromDate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(746, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "To date:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(746, 94);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Size = new System.Drawing.Size(100, 23);
            this.txtToDate.TabIndex = 2;
            this.txtToDate.TextChanged += new System.EventHandler(this.txtToDate_TextChanged);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(746, 149);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(84, 66);
            this.Run.TabIndex = 3;
            this.Run.Text = "RUN";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(13, 368);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(647, 147);
            this.txtResult.TabIndex = 5;
            // 
            // txtTotalDifference
            // 
            this.txtTotalDifference.Location = new System.Drawing.Point(746, 270);
            this.txtTotalDifference.Name = "txtTotalDifference";
            this.txtTotalDifference.Size = new System.Drawing.Size(100, 23);
            this.txtTotalDifference.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(746, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Total Difference:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(746, 311);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Original Total";
            // 
            // txtOriginalTotal
            // 
            this.txtOriginalTotal.Location = new System.Drawing.Point(746, 338);
            this.txtOriginalTotal.Name = "txtOriginalTotal";
            this.txtOriginalTotal.Size = new System.Drawing.Size(100, 23);
            this.txtOriginalTotal.TabIndex = 9;
            // 
            // LotDifference
            // 
            this.LotDifference.HeaderText = "Lot Difference";
            this.LotDifference.Name = "LotDifference";
            this.LotDifference.ReadOnly = true;
            // 
            // Difference
            // 
            this.Difference.HeaderText = "Difference";
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            // 
            // FinalPrice
            // 
            this.FinalPrice.HeaderText = "Final Price";
            this.FinalPrice.Name = "FinalPrice";
            this.FinalPrice.ReadOnly = true;
            // 
            // OriginalPrice
            // 
            this.OriginalPrice.HeaderText = "Original Price";
            this.OriginalPrice.Name = "OriginalPrice";
            this.OriginalPrice.ReadOnly = true;
            // 
            // LotSize
            // 
            this.LotSize.HeaderText = "Lot Size";
            this.LotSize.Name = "LotSize";
            // 
            // Ticker
            // 
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.Name = "Ticker";
            // 
            // dgvCurrentSecurities
            // 
            this.dgvCurrentSecurities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentSecurities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ticker,
            this.LotSize,
            this.OriginalPrice,
            this.FinalPrice,
            this.Difference,
            this.LotDifference});
            this.dgvCurrentSecurities.Location = new System.Drawing.Point(13, 56);
            this.dgvCurrentSecurities.Name = "dgvCurrentSecurities";
            this.dgvCurrentSecurities.Size = new System.Drawing.Size(647, 348);
            this.dgvCurrentSecurities.TabIndex = 4;
            this.dgvCurrentSecurities.Text = "dataGridView2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(746, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Final Total";
            // 
            // txtFinalTotal
            // 
            this.txtFinalTotal.Location = new System.Drawing.Point(746, 422);
            this.txtFinalTotal.Name = "txtFinalTotal";
            this.txtFinalTotal.Size = new System.Drawing.Size(100, 23);
            this.txtFinalTotal.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 520);
            this.Controls.Add(this.txtFinalTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOriginalTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalDifference);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.dgvCurrentSecurities);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.txtToDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFromDate);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Original Total";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentSecurities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToDate;
        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtTotalDifference;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOriginalTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn LotSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridView dgvCurrentSecurities;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFinalTotal;
    }
}

