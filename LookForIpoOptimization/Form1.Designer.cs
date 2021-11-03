
namespace LookForIpoOptimization
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIncreasedOverPercent = new System.Windows.Forms.TextBox();
            this.rdbIncreasedOverPercent = new System.Windows.Forms.RadioButton();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbMaxPercentInTimePeriod = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSinceDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMinimumNumberOfCandles = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 112);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(776, 289);
            this.txtResult.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(699, 416);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(724, 23);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(64, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtIncreasedOverPercent);
            this.groupBox1.Controls.Add(this.rdbIncreasedOverPercent);
            this.groupBox1.Controls.Add(this.rdbMaxPercentInTimePeriod);
            this.groupBox1.Location = new System.Drawing.Point(12, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 91);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Strategy";
            // 
            // txtIncreasedOverPercent
            // 
            this.txtIncreasedOverPercent.Location = new System.Drawing.Point(296, 48);
            this.txtIncreasedOverPercent.Name = "txtIncreasedOverPercent";
            this.txtIncreasedOverPercent.Size = new System.Drawing.Size(100, 23);
            this.txtIncreasedOverPercent.TabIndex = 4;
            this.txtIncreasedOverPercent.Text = "5";
            // 
            // rdbIncreasedOverPercent
            // 
            this.rdbIncreasedOverPercent.AutoSize = true;
            this.rdbIncreasedOverPercent.Location = new System.Drawing.Point(7, 47);
            this.rdbIncreasedOverPercent.Name = "rdbIncreasedOverPercent";
            this.rdbIncreasedOverPercent.Size = new System.Drawing.Size(283, 19);
            this.rdbIncreasedOverPercent.TabIndex = 3;
            this.rdbIncreasedOverPercent.TabStop = true;
            this.rdbIncreasedOverPercent.Text = "Break Down of how many increased over percent";
            this.rdbIncreasedOverPercent.UseVisualStyleBackColor = true;
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(613, 83);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(100, 23);
            this.txtDays.TabIndex = 2;
            this.txtDays.Text = "30";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(573, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Days";
            // 
            // rdbMaxPercentInTimePeriod
            // 
            this.rdbMaxPercentInTimePeriod.AutoSize = true;
            this.rdbMaxPercentInTimePeriod.Location = new System.Drawing.Point(7, 23);
            this.rdbMaxPercentInTimePeriod.Name = "rdbMaxPercentInTimePeriod";
            this.rdbMaxPercentInTimePeriod.Size = new System.Drawing.Size(158, 19);
            this.rdbMaxPercentInTimePeriod.TabIndex = 0;
            this.rdbMaxPercentInTimePeriod.TabStop = true;
            this.rdbMaxPercentInTimePeriod.Text = "MaxPercentInTimePeriod";
            this.rdbMaxPercentInTimePeriod.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(512, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Only Since Date:";
            // 
            // txtSinceDate
            // 
            this.txtSinceDate.Location = new System.Drawing.Point(613, 26);
            this.txtSinceDate.Name = "txtSinceDate";
            this.txtSinceDate.Size = new System.Drawing.Size(100, 23);
            this.txtSinceDate.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Must have at least candles:";
            // 
            // txtMinimumNumberOfCandles
            // 
            this.txtMinimumNumberOfCandles.Location = new System.Drawing.Point(667, 54);
            this.txtMinimumNumberOfCandles.Name = "txtMinimumNumberOfCandles";
            this.txtMinimumNumberOfCandles.Size = new System.Drawing.Size(46, 23);
            this.txtMinimumNumberOfCandles.TabIndex = 7;
            this.txtMinimumNumberOfCandles.Text = "15";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(724, 53);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(64, 23);
            this.btnReload.TabIndex = 8;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.txtMinimumNumberOfCandles);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSinceDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbMaxPercentInTimePeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSinceDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMinimumNumberOfCandles;
        private System.Windows.Forms.RadioButton rdbIncreasedOverPercent;
        private System.Windows.Forms.TextBox txtIncreasedOverPercent;
        private System.Windows.Forms.Button btnReload;
    }
}

