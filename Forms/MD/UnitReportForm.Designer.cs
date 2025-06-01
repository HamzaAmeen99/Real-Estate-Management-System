namespace RECMS.Forms.MD
{
    partial class UnitReportForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitReportForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFilter = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSortOrder = new System.Windows.Forms.ComboBox();
            this.chartSectorComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvSectorDetails = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartProjectInterest = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtp2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.Label();
            this.chartPayments = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorComparison)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectorDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartProjectInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(1191, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(45, 39);
            this.buttonClose.TabIndex = 37;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(123, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 36);
            this.label2.TabIndex = 35;
            this.label2.Text = "BFS REAL ESTATE AND DEVELOPERS";
            // 
            // cmbFilter
            // 
            this.cmbFilter.FormattingEnabled = true;
            this.cmbFilter.Location = new System.Drawing.Point(294, 377);
            this.cmbFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilter.Name = "cmbFilter";
            this.cmbFilter.Size = new System.Drawing.Size(236, 24);
            this.cmbFilter.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBox1.Location = new System.Drawing.Point(18, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1333, 68);
            this.panel1.TabIndex = 41;
            // 
            // cmbSortOrder
            // 
            this.cmbSortOrder.FormattingEnabled = true;
            this.cmbSortOrder.Location = new System.Drawing.Point(53, 377);
            this.cmbSortOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSortOrder.Name = "cmbSortOrder";
            this.cmbSortOrder.Size = new System.Drawing.Size(235, 24);
            this.cmbSortOrder.TabIndex = 44;
            // 
            // chartSectorComparison
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSectorComparison.ChartAreas.Add(chartArea1);
            this.chartSectorComparison.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartSectorComparison.Legends.Add(legend1);
            this.chartSectorComparison.Location = new System.Drawing.Point(0, 0);
            this.chartSectorComparison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSectorComparison.Name = "chartSectorComparison";
            this.chartSectorComparison.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSectorComparison.Series.Add(series1);
            this.chartSectorComparison.Size = new System.Drawing.Size(731, 186);
            this.chartSectorComparison.TabIndex = 43;
            this.chartSectorComparison.Text = "chart1";
            // 
            // dgvSectorDetails
            // 
            this.dgvSectorDetails.AllowUserToAddRows = false;
            this.dgvSectorDetails.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvSectorDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSectorDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSectorDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvSectorDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSectorDetails.Name = "dgvSectorDetails";
            this.dgvSectorDetails.ReadOnly = true;
            this.dgvSectorDetails.RowHeadersWidth = 62;
            this.dgvSectorDetails.RowTemplate.Height = 28;
            this.dgvSectorDetails.Size = new System.Drawing.Size(513, 186);
            this.dgvSectorDetails.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 457);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvSectorDetails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chartSectorComparison);
            this.splitContainer1.Size = new System.Drawing.Size(1248, 186);
            this.splitContainer1.SplitterDistance = 513;
            this.splitContainer1.TabIndex = 49;
            // 
            // chartProjectInterest
            // 
            chartArea2.Name = "ChartArea1";
            this.chartProjectInterest.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartProjectInterest.Legends.Add(legend2);
            this.chartProjectInterest.Location = new System.Drawing.Point(12, 70);
            this.chartProjectInterest.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartProjectInterest.Name = "chartProjectInterest";
            this.chartProjectInterest.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedBar;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartProjectInterest.Series.Add(series2);
            this.chartProjectInterest.Size = new System.Drawing.Size(635, 260);
            this.chartProjectInterest.TabIndex = 46;
            this.chartProjectInterest.Text = "chart1";
            this.chartProjectInterest.Click += new System.EventHandler(this.chartProjectInterest_Click);
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "MM/yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(1070, 153);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(128, 22);
            this.dtpFrom.TabIndex = 47;
            this.dtpFrom.Value = new System.DateTime(2025, 5, 16, 0, 46, 48, 0);
            // 
            // dtp2
            // 
            this.dtp2.CustomFormat = "MM/yyyy";
            this.dtp2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp2.Location = new System.Drawing.Point(1070, 215);
            this.dtp2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp2.Name = "dtp2";
            this.dtp2.Size = new System.Drawing.Size(128, 22);
            this.dtp2.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1065, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 49;
            this.label1.Text = "Date From";
            // 
            // dtpTo
            // 
            this.dtpTo.AutoSize = true;
            this.dtpTo.BackColor = System.Drawing.Color.White;
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(1065, 191);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(66, 17);
            this.dtpTo.TabIndex = 50;
            this.dtpTo.Text = "To Date";
            this.dtpTo.Click += new System.EventHandler(this.label3_Click);
            // 
            // chartPayments
            // 
            chartArea3.Name = "ChartArea1";
            this.chartPayments.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartPayments.Legends.Add(legend3);
            this.chartPayments.Location = new System.Drawing.Point(662, 70);
            this.chartPayments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartPayments.Name = "chartPayments";
            this.chartPayments.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartPayments.Series.Add(series3);
            this.chartPayments.Size = new System.Drawing.Size(549, 259);
            this.chartPayments.TabIndex = 51;
            this.chartPayments.Text = "chart1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1070, 250);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(128, 31);
            this.btnRefresh.TabIndex = 52;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportAll.ForeColor = System.Drawing.Color.White;
            this.btnExportAll.Location = new System.Drawing.Point(0, 643);
            this.btnExportAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(1248, 45);
            this.btnExportAll.TabIndex = 44;
            this.btnExportAll.Text = "Export";
            this.btnExportAll.UseVisualStyleBackColor = false;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // UnitReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1248, 688);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtp2);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.chartProjectInterest);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.cmbSortOrder);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(this.chartPayments);
            this.Controls.Add(this.btnExportAll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UnitReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UnitReportForm";
            this.Load += new System.EventHandler(this.UnitReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorComparison)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSectorDetails)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartProjectInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPayments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmbSortOrder;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSectorComparison;
        private System.Windows.Forms.DataGridView dgvSectorDetails;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProjectInterest;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dtpTo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPayments;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExportAll;
    }
}