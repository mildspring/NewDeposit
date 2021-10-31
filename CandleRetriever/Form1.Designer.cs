namespace CandleRetriever
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
            this.txtTickersAndDates = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.txtIssues = new System.Windows.Forms.TextBox();
            this.btnClearIssues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTickersAndDates
            // 
            this.txtTickersAndDates.Location = new System.Drawing.Point(15, 13);
            this.txtTickersAndDates.Multiline = true;
            this.txtTickersAndDates.Name = "txtTickersAndDates";
            this.txtTickersAndDates.Size = new System.Drawing.Size(319, 469);
            this.txtTickersAndDates.TabIndex = 0;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(641, 33);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(641, 74);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 23);
            this.btnSaveData.TabIndex = 2;
            this.btnSaveData.Text = "Save Data";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // txtIssues
            // 
            this.txtIssues.Location = new System.Drawing.Point(353, 149);
            this.txtIssues.Multiline = true;
            this.txtIssues.Name = "txtIssues";
            this.txtIssues.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtIssues.Size = new System.Drawing.Size(407, 310);
            this.txtIssues.TabIndex = 3;
            // 
            // btnClearIssues
            // 
            this.btnClearIssues.Location = new System.Drawing.Point(657, 467);
            this.btnClearIssues.Name = "btnClearIssues";
            this.btnClearIssues.Size = new System.Drawing.Size(75, 23);
            this.btnClearIssues.TabIndex = 4;
            this.btnClearIssues.Text = "Clear Log";
            this.btnClearIssues.UseVisualStyleBackColor = true;
            this.btnClearIssues.Click += new System.EventHandler(this.btnClearIssues_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(780, 494);
            this.Controls.Add(this.btnClearIssues);
            this.Controls.Add(this.txtIssues);
            this.Controls.Add(this.btnSaveData);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.txtTickersAndDates);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtTickersAndDates;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.TextBox txtIssues;
        private System.Windows.Forms.Button btnClearIssues;
    }
}

