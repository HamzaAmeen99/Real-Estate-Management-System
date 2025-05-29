namespace RECMS.CEO
{
    partial class ReportsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelReportsMain = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnExportLabor = new System.Windows.Forms.Button();
            this.btnExportMaterial = new System.Windows.Forms.Button();
            this.chartLaborCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMaterialCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExportSector = new System.Windows.Forms.Button();
            this.btnExportSales = new System.Windows.Forms.Button();
            this.btnApplySalesFilter = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSectorSortOrder = new System.Windows.Forms.ComboBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.dtpSalesFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpSalesTo = new System.Windows.Forms.DateTimePicker();
            this.chartSalesOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartSectorComparison = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelReportsTitle = new System.Windows.Forms.Label();
            this.panelReportsMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesOverTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorComparison)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelReportsMain
            // 
            this.panelReportsMain.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelReportsMain.Controls.Add(this.tabControl1);
            this.panelReportsMain.Controls.Add(this.panel1);
            this.panelReportsMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportsMain.Location = new System.Drawing.Point(0, 0);
            this.panelReportsMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelReportsMain.Name = "panelReportsMain";
            this.panelReportsMain.Size = new System.Drawing.Size(1200, 800);
            this.panelReportsMain.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 70);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 800);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.tabPage1.Controls.Add(this.btnExportLabor);
            this.tabPage1.Controls.Add(this.btnExportMaterial);
            this.tabPage1.Controls.Add(this.chartLaborCost);
            this.tabPage1.Controls.Add(this.chartMaterialCost);
            this.tabPage1.Controls.Add(this.cmbProjects);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1192, 771);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project Reports";
            // 
            // btnExportLabor
            // 
            this.btnExportLabor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportLabor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportLabor.ForeColor = System.Drawing.Color.White;
            this.btnExportLabor.Location = new System.Drawing.Point(1012, 659);
            this.btnExportLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportLabor.Name = "btnExportLabor";
            this.btnExportLabor.Size = new System.Drawing.Size(137, 34);
            this.btnExportLabor.TabIndex = 4;
            this.btnExportLabor.Text = "Download";
            this.btnExportLabor.UseVisualStyleBackColor = false;
            // 
            // btnExportMaterial
            // 
            this.btnExportMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportMaterial.ForeColor = System.Drawing.Color.White;
            this.btnExportMaterial.Location = new System.Drawing.Point(1012, 331);
            this.btnExportMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportMaterial.Name = "btnExportMaterial";
            this.btnExportMaterial.Size = new System.Drawing.Size(137, 34);
            this.btnExportMaterial.TabIndex = 3;
            this.btnExportMaterial.Text = "Download";
            this.btnExportMaterial.UseVisualStyleBackColor = false;
            // 
            // chartLaborCost
            // 
            chartArea1.Name = "ChartArea1";
            this.chartLaborCost.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartLaborCost.Legends.Add(legend1);
            this.chartLaborCost.Location = new System.Drawing.Point(-37, 369);
            this.chartLaborCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLaborCost.Name = "chartLaborCost";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartLaborCost.Series.Add(series1);
            this.chartLaborCost.Size = new System.Drawing.Size(1186, 286);
            this.chartLaborCost.TabIndex = 2;
            this.chartLaborCost.Text = "chart2";
            // 
            // chartMaterialCost
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMaterialCost.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartMaterialCost.Legends.Add(legend2);
            this.chartMaterialCost.Location = new System.Drawing.Point(13, 41);
            this.chartMaterialCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartMaterialCost.Name = "chartMaterialCost";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMaterialCost.Series.Add(series2);
            this.chartMaterialCost.Size = new System.Drawing.Size(1136, 286);
            this.chartMaterialCost.TabIndex = 1;
            this.chartMaterialCost.Text = "chart1";
            this.chartMaterialCost.Click += new System.EventHandler(this.chartMaterialCost_Click);
            // 
            // cmbProjects
            // 
            this.cmbProjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(3, 2);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(1186, 24);
            this.cmbProjects.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.tabPage2.Controls.Add(this.btnExportSector);
            this.tabPage2.Controls.Add(this.btnExportSales);
            this.tabPage2.Controls.Add(this.btnApplySalesFilter);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cmbSectorSortOrder);
            this.tabPage2.Controls.Add(this.cmbStatusFilter);
            this.tabPage2.Controls.Add(this.dtpSalesFrom);
            this.tabPage2.Controls.Add(this.dtpSalesTo);
            this.tabPage2.Controls.Add(this.chartSalesOverTime);
            this.tabPage2.Controls.Add(this.chartSectorComparison);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1192, 771);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Unit Reports";
            // 
            // btnExportSector
            // 
            this.btnExportSector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportSector.CausesValidation = false;
            this.btnExportSector.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnExportSector.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSector.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportSector.ForeColor = System.Drawing.Color.White;
            this.btnExportSector.Location = new System.Drawing.Point(1038, 567);
            this.btnExportSector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportSector.Name = "btnExportSector";
            this.btnExportSector.Size = new System.Drawing.Size(137, 40);
            this.btnExportSector.TabIndex = 13;
            this.btnExportSector.Text = "Download";
            this.btnExportSector.UseVisualStyleBackColor = false;
            // 
            // btnExportSales
            // 
            this.btnExportSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportSales.CausesValidation = false;
            this.btnExportSales.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnExportSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnExportSales.ForeColor = System.Drawing.Color.White;
            this.btnExportSales.Location = new System.Drawing.Point(1038, 219);
            this.btnExportSales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportSales.Name = "btnExportSales";
            this.btnExportSales.Size = new System.Drawing.Size(137, 40);
            this.btnExportSales.TabIndex = 12;
            this.btnExportSales.Text = "Download";
            this.btnExportSales.UseVisualStyleBackColor = false;
            // 
            // btnApplySalesFilter
            // 
            this.btnApplySalesFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnApplySalesFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplySalesFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnApplySalesFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplySalesFilter.Location = new System.Drawing.Point(337, 279);
            this.btnApplySalesFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplySalesFilter.Name = "btnApplySalesFilter";
            this.btnApplySalesFilter.Size = new System.Drawing.Size(508, 39);
            this.btnApplySalesFilter.TabIndex = 11;
            this.btnApplySalesFilter.Text = "Apply";
            this.btnApplySalesFilter.UseVisualStyleBackColor = false;
            this.btnApplySalesFilter.Click += new System.EventHandler(this.btnApplySalesFilter_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(333, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "From Date:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(595, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 23);
            this.label4.TabIndex = 9;
            this.label4.Text = "Date To:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(373, 612);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(622, 612);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sector";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(531, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter By";
            // 
            // cmbSectorSortOrder
            // 
            this.cmbSectorSortOrder.FormattingEnabled = true;
            this.cmbSectorSortOrder.Location = new System.Drawing.Point(626, 634);
            this.cmbSectorSortOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSectorSortOrder.Name = "cmbSectorSortOrder";
            this.cmbSectorSortOrder.Size = new System.Drawing.Size(232, 24);
            this.cmbSectorSortOrder.TabIndex = 5;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(377, 634);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(232, 24);
            this.cmbStatusFilter.TabIndex = 4;
            // 
            // dtpSalesFrom
            // 
            this.dtpSalesFrom.Location = new System.Drawing.Point(337, 252);
            this.dtpSalesFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpSalesFrom.Name = "dtpSalesFrom";
            this.dtpSalesFrom.Size = new System.Drawing.Size(246, 22);
            this.dtpSalesFrom.TabIndex = 3;
            // 
            // dtpSalesTo
            // 
            this.dtpSalesTo.Location = new System.Drawing.Point(599, 251);
            this.dtpSalesTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpSalesTo.Name = "dtpSalesTo";
            this.dtpSalesTo.Size = new System.Drawing.Size(246, 22);
            this.dtpSalesTo.TabIndex = 2;
            // 
            // chartSalesOverTime
            // 
            chartArea3.Name = "ChartArea1";
            this.chartSalesOverTime.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartSalesOverTime.Legends.Add(legend3);
            this.chartSalesOverTime.Location = new System.Drawing.Point(13, 4);
            this.chartSalesOverTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSalesOverTime.Name = "chartSalesOverTime";
            this.chartSalesOverTime.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartSalesOverTime.Series.Add(series3);
            this.chartSalesOverTime.Size = new System.Drawing.Size(1162, 205);
            this.chartSalesOverTime.TabIndex = 1;
            this.chartSalesOverTime.Text = "chart2";
            // 
            // chartSectorComparison
            // 
            chartArea4.Name = "ChartArea1";
            this.chartSectorComparison.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartSectorComparison.Legends.Add(legend4);
            this.chartSectorComparison.Location = new System.Drawing.Point(13, 349);
            this.chartSectorComparison.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSectorComparison.Name = "chartSectorComparison";
            this.chartSectorComparison.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartSectorComparison.Series.Add(series4);
            this.chartSectorComparison.Size = new System.Drawing.Size(1162, 205);
            this.chartSectorComparison.TabIndex = 0;
            this.chartSectorComparison.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.labelReportsTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 70);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::RECMS.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(1168, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // labelReportsTitle
            // 
            this.labelReportsTitle.AutoSize = true;
            this.labelReportsTitle.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportsTitle.ForeColor = System.Drawing.Color.White;
            this.labelReportsTitle.Location = new System.Drawing.Point(11, 10);
            this.labelReportsTitle.Name = "labelReportsTitle";
            this.labelReportsTitle.Size = new System.Drawing.Size(253, 33);
            this.labelReportsTitle.TabIndex = 0;
            this.labelReportsTitle.Text = "Reports Overview";
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.panelReportsMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReportsForm";
            this.Text = "ReportsForms";
            this.Load += new System.EventHandler(this.ReportsForm_Load);
            this.panelReportsMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesOverTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSectorComparison)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReportsMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelReportsTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLaborCost;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMaterialCost;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSectorComparison;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesOverTime;
        private System.Windows.Forms.DateTimePicker dtpSalesFrom;
        private System.Windows.Forms.DateTimePicker dtpSalesTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSectorSortOrder;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Button btnApplySalesFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportMaterial;
        private System.Windows.Forms.Button btnExportLabor;
        private System.Windows.Forms.Button btnExportSector;
        private System.Windows.Forms.Button btnExportSales;
    }
}