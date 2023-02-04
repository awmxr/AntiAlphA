namespace AntiAlphA
{
    partial class FileScaned
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
            this.components = new System.ComponentModel.Container();
            this.applicationDbContextBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.responseFBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.responseFBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Secure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanedRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScanedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.applicationDbContextBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseFBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseFBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // applicationDbContextBindingSource
            // 
            this.applicationDbContextBindingSource.DataSource = typeof(AntiAlphA.Data.ApplicationDbContext);
            // 
            // responseFBindingSource
            // 
            this.responseFBindingSource.DataSource = typeof(AntiAlphA.Model.ResponseF);
            // 
            // responseFBindingSource1
            // 
            this.responseFBindingSource1.DataSource = typeof(AntiAlphA.Model.ResponseF);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileDirectory,
            this.Secure,
            this.ScanedRequest,
            this.ScanedTime});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1083, 477);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // FileDirectory
            // 
            this.FileDirectory.HeaderText = "File Directory";
            this.FileDirectory.MinimumWidth = 6;
            this.FileDirectory.Name = "FileDirectory";
            this.FileDirectory.ReadOnly = true;
            this.FileDirectory.Width = 400;
            // 
            // Secure
            // 
            this.Secure.HeaderText = "Secure";
            this.Secure.MinimumWidth = 6;
            this.Secure.Name = "Secure";
            this.Secure.ReadOnly = true;
            this.Secure.Width = 125;
            // 
            // ScanedRequest
            // 
            this.ScanedRequest.HeaderText = "Scaned Request";
            this.ScanedRequest.MinimumWidth = 6;
            this.ScanedRequest.Name = "ScanedRequest";
            this.ScanedRequest.ReadOnly = true;
            this.ScanedRequest.Width = 200;
            // 
            // ScanedTime
            // 
            this.ScanedTime.HeaderText = "Scaned Time";
            this.ScanedTime.MinimumWidth = 6;
            this.ScanedTime.Name = "ScanedTime";
            this.ScanedTime.ReadOnly = true;
            this.ScanedTime.Width = 200;
            // 
            // FileScaned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 477);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FileScaned";
            this.Text = "FileScaned";
            this.Load += new System.EventHandler(this.FileScaned_Load);
            ((System.ComponentModel.ISupportInitialize)(this.applicationDbContextBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseFBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.responseFBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private BindingSource responseFBindingSource;
        private BindingSource applicationDbContextBindingSource;
        private BindingSource responseFBindingSource1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn FileDirectory;
        private DataGridViewTextBoxColumn Secure;
        private DataGridViewTextBoxColumn ScanedRequest;
        private DataGridViewTextBoxColumn ScanedTime;
    }
}