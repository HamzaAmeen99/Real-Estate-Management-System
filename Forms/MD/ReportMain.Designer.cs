namespace RECMS.Forms.MD
{
    partial class ReportMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea9 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend9 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.chartLaborCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMaterialCost = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportProject = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.chartUnitsOverTime = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnExportUnits = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborCost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUnitsOverTime)).BeginInit();
            this.SuspendLayout();
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
            this.label2.TabIndex = 20;
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
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(1140, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(45, 39);
            this.buttonClose.TabIndex = 28;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.buttonClose);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1185, 68);
            this.panel2.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 68);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1185, 621);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbProjects);
            this.tabPage1.Controls.Add(this.chartLaborCost);
            this.tabPage1.Controls.Add(this.chartMaterialCost);
            this.tabPage1.Controls.Add(this.btnExportProject);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1177, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Project Reports";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(504, 8);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(300, 24);
            this.cmbProjects.TabIndex = 2;
            // 
            // chartLaborCost
            // 
            chartArea7.Name = "ChartArea1";
            this.chartLaborCost.ChartAreas.Add(chartArea7);
            this.chartLaborCost.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend7.Name = "Legend1";
            this.chartLaborCost.Legends.Add(legend7);
            this.chartLaborCost.Location = new System.Drawing.Point(3, 285);
            this.chartLaborCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartLaborCost.Name = "chartLaborCost";
            this.chartLaborCost.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartLaborCost.Series.Add(series7);
            this.chartLaborCost.Size = new System.Drawing.Size(1171, 267);
            this.chartLaborCost.TabIndex = 1;
            this.chartLaborCost.Text = "chart2";
            // 
            // chartMaterialCost
            // 
            chartArea8.Name = "ChartArea1";
            this.chartMaterialCost.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartMaterialCost.Legends.Add(legend8);
            this.chartMaterialCost.Location = new System.Drawing.Point(0, 35);
            this.chartMaterialCost.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartMaterialCost.Name = "chartMaterialCost";
            this.chartMaterialCost.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartMaterialCost.Series.Add(series8);
            this.chartMaterialCost.Size = new System.Drawing.Size(1178, 269);
            this.chartMaterialCost.TabIndex = 0;
            this.chartMaterialCost.Text = "chart1";
            // 
            // btnExportProject
            // 
            this.btnExportProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportProject.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportProject.ForeColor = System.Drawing.Color.White;
            this.btnExportProject.Location = new System.Drawing.Point(3, 552);
            this.btnExportProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportProject.Name = "btnExportProject";
            this.btnExportProject.Size = new System.Drawing.Size(1171, 38);
            this.btnExportProject.TabIndex = 3;
            this.btnExportProject.Text = "Export";
            this.btnExportProject.UseVisualStyleBackColor = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.dtpDateFrom);
            this.tabPage2.Controls.Add(this.dtpDateTo);
            this.tabPage2.Controls.Add(this.chartUnitsOverTime);
            this.tabPage2.Controls.Add(this.btnExportUnits);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1177, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Units Reports";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Date To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(129, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date From:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(132, 5);
            this.dtpDateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(178, 22);
            this.dtpDateFrom.TabIndex = 3;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(412, 5);
            this.dtpDateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(178, 22);
            this.dtpDateTo.TabIndex = 2;
            // 
            // chartUnitsOverTime
            // 
            chartArea9.Name = "ChartArea1";
            this.chartUnitsOverTime.ChartAreas.Add(chartArea9);
            this.chartUnitsOverTime.Dock = System.Windows.Forms.DockStyle.Fill;
            legend9.Name = "Legend1";
            this.chartUnitsOverTime.Legends.Add(legend9);
            this.chartUnitsOverTime.Location = new System.Drawing.Point(3, 2);
            this.chartUnitsOverTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartUnitsOverTime.Name = "chartUnitsOverTime";
            this.chartUnitsOverTime.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series9.ChartArea = "ChartArea1";
            series9.Legend = "Legend1";
            series9.Name = "Series1";
            this.chartUnitsOverTime.Series.Add(series9);
            this.chartUnitsOverTime.Size = new System.Drawing.Size(1171, 555);
            this.chartUnitsOverTime.TabIndex = 1;
            this.chartUnitsOverTime.Text = "chartUnitsOverTime";
            // 
            // btnExportUnits
            // 
            this.btnExportUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnExportUnits.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExportUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportUnits.ForeColor = System.Drawing.Color.White;
            this.btnExportUnits.Location = new System.Drawing.Point(3, 557);
            this.btnExportUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportUnits.Name = "btnExportUnits";
            this.btnExportUnits.Size = new System.Drawing.Size(1171, 33);
            this.btnExportUnits.TabIndex = 7;
            this.btnExportUnits.Text = "Export";
            this.btnExportUnits.UseMnemonic = false;
            this.btnExportUnits.UseVisualStyleBackColor = false;
            // 
            // ReportMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 689);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReportMain";
            this.Text = "ReportMain";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartLaborCost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaterialCost)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartUnitsOverTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLaborCost;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMaterialCost;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUnitsOverTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExportProject;
        private System.Windows.Forms.Button btnExportUnits;
    }
}