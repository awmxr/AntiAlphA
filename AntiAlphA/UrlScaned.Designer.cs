namespace AntiAlphA
{
    partial class UrlScaned
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Security = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannedRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScannedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Url,
            this.Security,
            this.ScannedRequest,
            this.ScannedTime});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(968, 450);
            this.dataGridView1.TabIndex = 0;
            // 
            // Url
            // 
            this.Url.HeaderText = "Url";
            this.Url.MinimumWidth = 6;
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 250;
            // 
            // Security
            // 
            this.Security.HeaderText = "Security";
            this.Security.MinimumWidth = 6;
            this.Security.Name = "Security";
            this.Security.ReadOnly = true;
            this.Security.Width = 125;
            // 
            // ScannedRequest
            // 
            this.ScannedRequest.HeaderText = "Scanned Request";
            this.ScannedRequest.MinimumWidth = 6;
            this.ScannedRequest.Name = "ScannedRequest";
            this.ScannedRequest.ReadOnly = true;
            this.ScannedRequest.Width = 200;
            // 
            // ScannedTime
            // 
            this.ScannedTime.HeaderText = "Scanned Time";
            this.ScannedTime.MinimumWidth = 6;
            this.ScannedTime.Name = "ScannedTime";
            this.ScannedTime.ReadOnly = true;
            this.ScannedTime.Width = 200;
            // 
            // UrlScaned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "UrlScaned";
            this.Text = "UrlScaned";
            this.Load += new System.EventHandler(this.UrlScaned_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Url;
        private DataGridViewTextBoxColumn Security;
        private DataGridViewTextBoxColumn ScannedRequest;
        private DataGridViewTextBoxColumn ScannedTime;
    }
}