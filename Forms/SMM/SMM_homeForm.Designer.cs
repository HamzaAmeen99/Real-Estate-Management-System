namespace RECMS.Forms.SMM
{
    partial class SMM_homeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMM_homeForm));
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabUnitSales = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSectorFilter = new System.Windows.Forms.ComboBox();
            this.btnFilterSold = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSoldTo = new System.Windows.Forms.DateTimePicker();
            this.dtpSoldFrom = new System.Windows.Forms.DateTimePicker();
            this.lblAvailableUnitsCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chartSalesBySector = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvAvailableUnits = new System.Windows.Forms.DataGridView();
            this.dgvSoldUnits = new System.Windows.Forms.DataGridView();
            this.tabMilestones = new System.Windows.Forms.TabPage();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.lblImageDescription = new System.Windows.Forms.Label();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.picProjectImage = new System.Windows.Forms.PictureBox();
            this.lblBudget = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tcmain = new System.Windows.Forms.TabControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabUnitSales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesBySector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldUnits)).BeginInit();
            this.tabMilestones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectImage)).BeginInit();
            this.tcmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(1155, -2);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(45, 39);
            this.buttonClose.TabIndex = 34;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.label2.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.label2.Location = new System.Drawing.Point(153, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 40);
            this.label2.TabIndex = 30;
            this.label2.Text = "Social Media Manager";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(-5, -2);
            this.textBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(1620, 76);
            this.textBox6.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(286, 734);
            this.panel1.TabIndex = 35;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::RECMS.Properties.Resources._3432671_removebg_preview1;
            this.pictureBox3.Location = new System.Drawing.Point(-49, 182);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(364, 340);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.btnLogout.Location = new System.Drawing.Point(0, 673);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(286, 61);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.pictureBox1.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBox1.Location = new System.Drawing.Point(23, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(78, 62);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // tabUnitSales
            // 
            this.tabUnitSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.tabUnitSales.Controls.Add(this.label8);
            this.tabUnitSales.Controls.Add(this.cmbStatusFilter);
            this.tabUnitSales.Controls.Add(this.label7);
            this.tabUnitSales.Controls.Add(this.cmbSectorFilter);
            this.tabUnitSales.Controls.Add(this.btnFilterSold);
            this.tabUnitSales.Controls.Add(this.label4);
            this.tabUnitSales.Controls.Add(this.label3);
            this.tabUnitSales.Controls.Add(this.dtpSoldTo);
            this.tabUnitSales.Controls.Add(this.dtpSoldFrom);
            this.tabUnitSales.Controls.Add(this.lblAvailableUnitsCount);
            this.tabUnitSales.Controls.Add(this.label1);
            this.tabUnitSales.Controls.Add(this.chartSalesBySector);
            this.tabUnitSales.Controls.Add(this.dgvAvailableUnits);
            this.tabUnitSales.Controls.Add(this.dgvSoldUnits);
            this.tabUnitSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabUnitSales.Location = new System.Drawing.Point(4, 25);
            this.tabUnitSales.Margin = new System.Windows.Forms.Padding(4);
            this.tabUnitSales.Name = "tabUnitSales";
            this.tabUnitSales.Padding = new System.Windows.Forms.Padding(4);
            this.tabUnitSales.Size = new System.Drawing.Size(1304, 797);
            this.tabUnitSales.TabIndex = 1;
            this.tabUnitSales.Text = "Unit Sales";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(215, 393);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sort";
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(347, 415);
            this.cmbStatusFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(108, 28);
            this.cmbStatusFilter.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(343, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Status";
            // 
            // cmbSectorFilter
            // 
            this.cmbSectorFilter.FormattingEnabled = true;
            this.cmbSectorFilter.Location = new System.Drawing.Point(219, 415);
            this.cmbSectorFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbSectorFilter.Name = "cmbSectorFilter";
            this.cmbSectorFilter.Size = new System.Drawing.Size(108, 28);
            this.cmbSectorFilter.TabIndex = 10;
            // 
            // btnFilterSold
            // 
            this.btnFilterSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnFilterSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterSold.ForeColor = System.Drawing.Color.White;
            this.btnFilterSold.Location = new System.Drawing.Point(429, 19);
            this.btnFilterSold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilterSold.Name = "btnFilterSold";
            this.btnFilterSold.Size = new System.Drawing.Size(212, 33);
            this.btnFilterSold.TabIndex = 9;
            this.btnFilterSold.Text = "Apply Filter";
            this.btnFilterSold.UseVisualStyleBackColor = false;
            this.btnFilterSold.Click += new System.EventHandler(this.btnFilterSold_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Date To";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Date From";
            // 
            // dtpSoldTo
            // 
            this.dtpSoldTo.Location = new System.Drawing.Point(229, 25);
            this.dtpSoldTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpSoldTo.Name = "dtpSoldTo";
            this.dtpSoldTo.Size = new System.Drawing.Size(178, 27);
            this.dtpSoldTo.TabIndex = 6;
            // 
            // dtpSoldFrom
            // 
            this.dtpSoldFrom.Location = new System.Drawing.Point(31, 25);
            this.dtpSoldFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpSoldFrom.Name = "dtpSoldFrom";
            this.dtpSoldFrom.Size = new System.Drawing.Size(178, 27);
            this.dtpSoldFrom.TabIndex = 5;
            // 
            // lblAvailableUnitsCount
            // 
            this.lblAvailableUnitsCount.AutoSize = true;
            this.lblAvailableUnitsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableUnitsCount.Location = new System.Drawing.Point(160, 207);
            this.lblAvailableUnitsCount.Name = "lblAvailableUnitsCount";
            this.lblAvailableUnitsCount.Size = new System.Drawing.Size(17, 17);
            this.lblAvailableUnitsCount.TabIndex = 4;
            this.lblAvailableUnitsCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Available Units:";
            // 
            // chartSalesBySector
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSalesBySector.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartSalesBySector.Legends.Add(legend1);
            this.chartSalesBySector.Location = new System.Drawing.Point(87, 445);
            this.chartSalesBySector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartSalesBySector.Name = "chartSalesBySector";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSalesBySector.Series.Add(series1);
            this.chartSalesBySector.Size = new System.Drawing.Size(772, 178);
            this.chartSalesBySector.TabIndex = 2;
            this.chartSalesBySector.Text = "chart1";
            // 
            // dgvAvailableUnits
            // 
            this.dgvAvailableUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableUnits.Location = new System.Drawing.Point(34, 241);
            this.dgvAvailableUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAvailableUnits.Name = "dgvAvailableUnits";
            this.dgvAvailableUnits.RowHeadersWidth = 62;
            this.dgvAvailableUnits.RowTemplate.Height = 28;
            this.dgvAvailableUnits.Size = new System.Drawing.Size(731, 138);
            this.dgvAvailableUnits.TabIndex = 1;
            // 
            // dgvSoldUnits
            // 
            this.dgvSoldUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoldUnits.Location = new System.Drawing.Point(31, 57);
            this.dgvSoldUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSoldUnits.Name = "dgvSoldUnits";
            this.dgvSoldUnits.RowHeadersWidth = 62;
            this.dgvSoldUnits.RowTemplate.Height = 28;
            this.dgvSoldUnits.Size = new System.Drawing.Size(734, 138);
            this.dgvSoldUnits.TabIndex = 0;
            // 
            // tabMilestones
            // 
            this.tabMilestones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.tabMilestones.Controls.Add(this.btnDownload);
            this.tabMilestones.Controls.Add(this.btnNext);
            this.tabMilestones.Controls.Add(this.btnPrev);
            this.tabMilestones.Controls.Add(this.lblImageCounter);
            this.tabMilestones.Controls.Add(this.lblImageDescription);
            this.tabMilestones.Controls.Add(this.cmbProjects);
            this.tabMilestones.Controls.Add(this.btnRefresh);
            this.tabMilestones.Controls.Add(this.lblProgress);
            this.tabMilestones.Controls.Add(this.progressBar);
            this.tabMilestones.Controls.Add(this.picProjectImage);
            this.tabMilestones.Controls.Add(this.lblBudget);
            this.tabMilestones.Controls.Add(this.label6);
            this.tabMilestones.Controls.Add(this.label5);
            this.tabMilestones.Location = new System.Drawing.Point(4, 25);
            this.tabMilestones.Margin = new System.Windows.Forms.Padding(4);
            this.tabMilestones.Name = "tabMilestones";
            this.tabMilestones.Padding = new System.Windows.Forms.Padding(4);
            this.tabMilestones.Size = new System.Drawing.Size(1304, 797);
            this.tabMilestones.TabIndex = 0;
            this.tabMilestones.Text = "Project Progress";
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownload.ForeColor = System.Drawing.Color.White;
            this.btnDownload.Location = new System.Drawing.Point(474, 480);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(363, 51);
            this.btnDownload.TabIndex = 17;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(677, 361);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(52, 28);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(600, 361);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(56, 28);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageCounter.Location = new System.Drawing.Point(629, 113);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(70, 25);
            this.lblImageCounter.TabIndex = 14;
            this.lblImageCounter.Text = "label1";
            // 
            // lblImageDescription
            // 
            this.lblImageDescription.AutoSize = true;
            this.lblImageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageDescription.Location = new System.Drawing.Point(629, 421);
            this.lblImageDescription.Name = "lblImageDescription";
            this.lblImageDescription.Size = new System.Drawing.Size(70, 25);
            this.lblImageDescription.TabIndex = 13;
            this.lblImageDescription.Text = "label1";
            // 
            // cmbProjects
            // 
            this.cmbProjects.BackColor = System.Drawing.Color.White;
            this.cmbProjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(35, 189);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(368, 28);
            this.cmbProjects.TabIndex = 12;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(229, 230);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(174, 42);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Clash Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.Location = new System.Drawing.Point(31, 318);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(80, 23);
            this.lblProgress.TabIndex = 10;
            this.lblProgress.Text = "label10";
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.White;
            this.progressBar.ForeColor = System.Drawing.Color.Black;
            this.progressBar.Location = new System.Drawing.Point(31, 361);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(372, 29);
            this.progressBar.TabIndex = 9;
            // 
            // picProjectImage
            // 
            this.picProjectImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProjectImage.Location = new System.Drawing.Point(474, 145);
            this.picProjectImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picProjectImage.Name = "picProjectImage";
            this.picProjectImage.Size = new System.Drawing.Size(363, 264);
            this.picProjectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProjectImage.TabIndex = 8;
            this.picProjectImage.TabStop = false;
            // 
            // lblBudget
            // 
            this.lblBudget.AutoSize = true;
            this.lblBudget.Font = new System.Drawing.Font("Clash Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudget.Location = new System.Drawing.Point(254, 539);
            this.lblBudget.Name = "lblBudget";
            this.lblBudget.Size = new System.Drawing.Size(71, 23);
            this.lblBudget.TabIndex = 6;
            this.lblBudget.Text = "label8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Clash Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 533);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(222, 32);
            this.label6.TabIndex = 4;
            this.label6.Text = "Total Expense:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Clash Display", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Project";
            // 
            // tcmain
            // 
            this.tcmain.Controls.Add(this.tabMilestones);
            this.tcmain.Controls.Add(this.tabUnitSales);
            this.tcmain.Location = new System.Drawing.Point(286, 78);
            this.tcmain.Margin = new System.Windows.Forms.Padding(4);
            this.tcmain.Name = "tcmain";
            this.tcmain.SelectedIndex = 0;
            this.tcmain.Size = new System.Drawing.Size(1312, 826);
            this.tcmain.TabIndex = 36;
            // 
            // SMM_homeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tcmain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SMM_homeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMM_homeForm";
            this.Load += new System.EventHandler(this.SMM_homeForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabUnitSales.ResumeLayout(false);
            this.tabUnitSales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSalesBySector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldUnits)).EndInit();
            this.tabMilestones.ResumeLayout(false);
            this.tabMilestones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectImage)).EndInit();
            this.tcmain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TabPage tabUnitSales;
        private System.Windows.Forms.TabPage tabMilestones;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblImageCounter;
        private System.Windows.Forms.Label lblImageDescription;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox picProjectImage;
        private System.Windows.Forms.Label lblBudget;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tcmain;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSalesBySector;
        private System.Windows.Forms.DataGridView dgvAvailableUnits;
        private System.Windows.Forms.DataGridView dgvSoldUnits;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAvailableUnitsCount;
        private System.Windows.Forms.Button btnFilterSold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSoldTo;
        private System.Windows.Forms.DateTimePicker dtpSoldFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSectorFilter;
    }
}