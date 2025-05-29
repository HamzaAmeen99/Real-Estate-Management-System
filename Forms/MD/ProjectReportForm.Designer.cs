namespace RECMS.Forms.MD
{
    partial class ProjectReportForm
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabReports = new System.Windows.Forms.TabControl();
            this.tabLabor = new System.Windows.Forms.TabPage();
            this.chartMaterialCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMaterial = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportMaterial = new System.Windows.Forms.Button();
            this.tabMaterials = new System.Windows.Forms.TabPage();
            this.chartLaborRoles = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLaborSupplier = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportLabor = new System.Windows.Forms.Button();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabLabor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterial)).BeginInit();
            this.tabMaterials.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborSupplier)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(927, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(45, 39);
            this.buttonClose.TabIndex = 33;
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
            this.label2.Location = new System.Drawing.Point(122, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 36);
            this.label2.TabIndex = 31;
            this.label2.Text = "BFS REAL ESTATE AND DEVELOPERS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBox1.Location = new System.Drawing.Point(18, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(972, 68);
            this.panel2.TabIndex = 35;
            // 
            // tabReports
            // 
            this.tabReports.Controls.Add(this.tabLabor);
            this.tabReports.Controls.Add(this.tabMaterials);
            this.tabReports.Location = new System.Drawing.Point(0, 98);
            this.tabReports.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabReports.Name = "tabReports";
            this.tabReports.SelectedIndex = 0;
            this.tabReports.Size = new System.Drawing.Size(972, 473);
            this.tabReports.TabIndex = 36;
            // 
            // tabLabor
            // 
            this.tabLabor.Controls.Add(this.chartMaterialCost);
            this.tabLabor.Controls.Add(this.chartMaterial);
            this.tabLabor.Controls.Add(this.btnExportMaterial);
            this.tabLabor.Location = new System.Drawing.Point(4, 25);
            this.tabLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLabor.Name = "tabLabor";
            this.tabLabor.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLabor.Size = new System.Drawing.Size(964, 444);
            this.tabLabor.TabIndex = 0;
            this.tabLabor.Text = "Project Materials";
            this.tabLabor.UseVisualStyleBackColor = true;
            this.tabLabor.Click += new System.EventHandler(this.tabLabor_Click);
            // 
            // chartMaterialCost
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMaterialCost.ChartAreas.Add(chartArea1);
            this.chartMaterialCost.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartMaterialCost.Legends.Add(legend1);
            this.chartMaterialCost.Location = new System.Drawing.Point(3, 2);
            this.chartMaterialCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartMaterialCost.Name = "chartMaterialCost";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartMaterialCost.Series.Add(series1);
            this.chartMaterialCost.Size = new System.Drawing.Size(958, 207);
            this.chartMaterialCost.TabIndex = 2;
            this.chartMaterialCost.Text = "chart1";
            // 
            // chartMaterial
            // 
            chartArea2.Name = "ChartArea1";
            this.chartMaterial.ChartAreas.Add(chartArea2);
            this.chartMaterial.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.chartMaterial.Legends.Add(legend2);
            this.chartMaterial.Location = new System.Drawing.Point(3, 204);
            this.chartMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartMaterial.Name = "chartMaterial";
            this.chartMaterial.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartMaterial.Series.Add(series2);
            this.chartMaterial.Size = new System.Drawing.Size(958, 211);
            this.chartMaterial.TabIndex = 1;
            this.chartMaterial.Text = "chart1";
            // 
            // btnExportMaterial
            // 
            this.btnExportMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportMaterial.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportMaterial.ForeColor = System.Drawing.Color.White;
            this.btnExportMaterial.Location = new System.Drawing.Point(3, 415);
            this.btnExportMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportMaterial.Name = "btnExportMaterial";
            this.btnExportMaterial.Size = new System.Drawing.Size(958, 27);
            this.btnExportMaterial.TabIndex = 3;
            this.btnExportMaterial.Text = "Export";
            this.btnExportMaterial.UseVisualStyleBackColor = false;
            // 
            // tabMaterials
            // 
            this.tabMaterials.Controls.Add(this.chartLaborRoles);
            this.tabMaterials.Controls.Add(this.chartLaborSupplier);
            this.tabMaterials.Controls.Add(this.btnExportLabor);
            this.tabMaterials.Location = new System.Drawing.Point(4, 25);
            this.tabMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMaterials.Name = "tabMaterials";
            this.tabMaterials.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMaterials.Size = new System.Drawing.Size(964, 444);
            this.tabMaterials.TabIndex = 1;
            this.tabMaterials.Text = "Project Labor";
            this.tabMaterials.UseVisualStyleBackColor = true;
            // 
            // chartLaborRoles
            // 
            chartArea3.Name = "ChartArea1";
            this.chartLaborRoles.ChartAreas.Add(chartArea3);
            this.chartLaborRoles.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.chartLaborRoles.Legends.Add(legend3);
            this.chartLaborRoles.Location = new System.Drawing.Point(3, 2);
            this.chartLaborRoles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLaborRoles.Name = "chartLaborRoles";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartLaborRoles.Series.Add(series3);
            this.chartLaborRoles.Size = new System.Drawing.Size(958, 203);
            this.chartLaborRoles.TabIndex = 3;
            this.chartLaborRoles.Text = "chart1";
            // 
            // chartLaborSupplier
            // 
            chartArea4.Name = "ChartArea1";
            this.chartLaborSupplier.ChartAreas.Add(chartArea4);
            this.chartLaborSupplier.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend4.Name = "Legend1";
            this.chartLaborSupplier.Legends.Add(legend4);
            this.chartLaborSupplier.Location = new System.Drawing.Point(3, 211);
            this.chartLaborSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLaborSupplier.Name = "chartLaborSupplier";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartLaborSupplier.Series.Add(series4);
            this.chartLaborSupplier.Size = new System.Drawing.Size(958, 205);
            this.chartLaborSupplier.TabIndex = 2;
            this.chartLaborSupplier.Text = "chart1";
            // 
            // btnExportLabor
            // 
            this.btnExportLabor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportLabor.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportLabor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportLabor.ForeColor = System.Drawing.Color.White;
            this.btnExportLabor.Location = new System.Drawing.Point(3, 416);
            this.btnExportLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportLabor.Name = "btnExportLabor";
            this.btnExportLabor.Size = new System.Drawing.Size(958, 26);
            this.btnExportLabor.TabIndex = 4;
            this.btnExportLabor.Text = "Export";
            this.btnExportLabor.UseVisualStyleBackColor = false;
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(340, 90);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(285, 24);
            this.cmbProjects.TabIndex = 1;
            // 
            // ProjectReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(972, 570);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.tabReports);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProjectReportForm";
            this.Text = "ProjectReportForm";
            this.Load += new System.EventHandler(this.ProjectReportForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabLabor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterial)).EndInit();
            this.tabMaterials.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborSupplier)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabReports;
        private System.Windows.Forms.TabPage tabLabor;
        private System.Windows.Forms.TabPage tabMaterials;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMaterial;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLaborSupplier;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLaborRoles;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMaterialCost;
        private System.Windows.Forms.Button btnExportMaterial;
        private System.Windows.Forms.Button btnExportLabor;
    }
}