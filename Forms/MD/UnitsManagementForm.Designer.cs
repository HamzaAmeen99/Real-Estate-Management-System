namespace RECMS.Forms.MD
{
    partial class UnitsManagementForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.paneLeftUp = new System.Windows.Forms.Panel();
            this.CustData = new System.Windows.Forms.DataGridView();
            this.panelRightUp = new System.Windows.Forms.Panel();
            this.btnReport = new System.Windows.Forms.Button();
            this.chartPaymentStatus = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelDownLeft = new System.Windows.Forms.Panel();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSearchContact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.btnMarkSold = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAddUnit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblavlbunits = new System.Windows.Forms.Label();
            this.lblLastMonthSales = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAvailableUnits = new System.Windows.Forms.Label();
            this.lblCurrentMonthSales = new System.Windows.Forms.Label();
            this.lblTotalUnits = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.paneLeftUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustData)).BeginInit();
            this.panelRightUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartPaymentStatus)).BeginInit();
            this.panelDownLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1095, 79);
            this.panel1.TabIndex = 35;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RECMS.Properties.Resources.Back_round;
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(41, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(1050, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(45, 39);
            this.buttonClose.TabIndex = 21;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(233, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(680, 39);
            this.label2.TabIndex = 20;
            this.label2.Text = "BFS REAL ESTATE AND DEVELOPERS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBox1.Location = new System.Drawing.Point(122, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 76.3289F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.6711F));
            this.tableLayoutPanel1.Controls.Add(this.paneLeftUp, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelRightUp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelDownLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-2, 73);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.42493F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.57507F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1095, 565);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // paneLeftUp
            // 
            this.paneLeftUp.Controls.Add(this.CustData);
            this.paneLeftUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneLeftUp.Location = new System.Drawing.Point(3, 2);
            this.paneLeftUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paneLeftUp.Name = "paneLeftUp";
            this.paneLeftUp.Size = new System.Drawing.Size(829, 280);
            this.paneLeftUp.TabIndex = 0;
            // 
            // CustData
            // 
            this.CustData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CustData.Location = new System.Drawing.Point(0, 0);
            this.CustData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CustData.Name = "CustData";
            this.CustData.RowHeadersWidth = 62;
            this.CustData.RowTemplate.Height = 28;
            this.CustData.Size = new System.Drawing.Size(829, 280);
            this.CustData.TabIndex = 0;
            this.CustData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panelRightUp
            // 
            this.panelRightUp.Controls.Add(this.btnReport);
            this.panelRightUp.Controls.Add(this.chartPaymentStatus);
            this.panelRightUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightUp.Location = new System.Drawing.Point(838, 2);
            this.panelRightUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRightUp.Name = "panelRightUp";
            this.panelRightUp.Size = new System.Drawing.Size(254, 280);
            this.panelRightUp.TabIndex = 1;
            // 
            // btnReport
            // 
            this.btnReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.ForeColor = System.Drawing.Color.White;
            this.btnReport.Location = new System.Drawing.Point(0, 250);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(254, 30);
            this.btnReport.TabIndex = 4;
            this.btnReport.Text = "View More Reports";
            this.btnReport.UseVisualStyleBackColor = false;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // chartPaymentStatus
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPaymentStatus.ChartAreas.Add(chartArea2);
            this.chartPaymentStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartPaymentStatus.Legends.Add(legend2);
            this.chartPaymentStatus.Location = new System.Drawing.Point(0, 0);
            this.chartPaymentStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartPaymentStatus.Name = "chartPaymentStatus";
            this.chartPaymentStatus.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "seriesPaymentStatus";
            this.chartPaymentStatus.Series.Add(series2);
            this.chartPaymentStatus.Size = new System.Drawing.Size(254, 280);
            this.chartPaymentStatus.TabIndex = 43;
            this.chartPaymentStatus.Text = "chart1";
            // 
            // panelDownLeft
            // 
            this.panelDownLeft.Controls.Add(this.btnFilter);
            this.panelDownLeft.Controls.Add(this.label8);
            this.panelDownLeft.Controls.Add(this.label7);
            this.panelDownLeft.Controls.Add(this.label5);
            this.panelDownLeft.Controls.Add(this.dtpEndDate);
            this.panelDownLeft.Controls.Add(this.dtpStartDate);
            this.panelDownLeft.Controls.Add(this.btnUpdate);
            this.panelDownLeft.Controls.Add(this.label4);
            this.panelDownLeft.Controls.Add(this.label3);
            this.panelDownLeft.Controls.Add(this.txtSearchContact);
            this.panelDownLeft.Controls.Add(this.label1);
            this.panelDownLeft.Controls.Add(this.btnRefresh);
            this.panelDownLeft.Controls.Add(this.txtSearchName);
            this.panelDownLeft.Controls.Add(this.btnMarkSold);
            this.panelDownLeft.Controls.Add(this.btnSearch);
            this.panelDownLeft.Controls.Add(this.btnAddUnit);
            this.panelDownLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDownLeft.Location = new System.Drawing.Point(3, 286);
            this.panelDownLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelDownLeft.Name = "panelDownLeft";
            this.panelDownLeft.Size = new System.Drawing.Size(829, 277);
            this.panelDownLeft.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(586, 222);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(171, 33);
            this.btnFilter.TabIndex = 18;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(542, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Date From:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(542, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Date To:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(640, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "FILTER";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(546, 191);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(264, 22);
            this.dtpEndDate.TabIndex = 14;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(546, 136);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(264, 22);
            this.dtpStartDate.TabIndex = 12;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(314, 178);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(171, 35);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(276, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Contact";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Name";
            // 
            // txtSearchContact
            // 
            this.txtSearchContact.Location = new System.Drawing.Point(280, 139);
            this.txtSearchContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchContact.Name = "txtSearchContact";
            this.txtSearchContact.Size = new System.Drawing.Size(240, 22);
            this.txtSearchContact.TabIndex = 8;
            this.txtSearchContact.TextChanged += new System.EventHandler(this.txtSearchAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "SEARCH";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(829, 39);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh Tab";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(19, 141);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(240, 22);
            this.txtSearchName.TabIndex = 5;
            // 
            // btnMarkSold
            // 
            this.btnMarkSold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnMarkSold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarkSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarkSold.ForeColor = System.Drawing.Color.White;
            this.btnMarkSold.Location = new System.Drawing.Point(431, 43);
            this.btnMarkSold.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMarkSold.Name = "btnMarkSold";
            this.btnMarkSold.Size = new System.Drawing.Size(341, 40);
            this.btnMarkSold.TabIndex = 2;
            this.btnMarkSold.Text = "Unit Sale";
            this.btnMarkSold.UseVisualStyleBackColor = false;
            this.btnMarkSold.Click += new System.EventHandler(this.btnMarkSold_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(49, 178);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(171, 35);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAddUnit
            // 
            this.btnAddUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnAddUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUnit.ForeColor = System.Drawing.Color.White;
            this.btnAddUnit.Location = new System.Drawing.Point(49, 43);
            this.btnAddUnit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUnit.Name = "btnAddUnit";
            this.btnAddUnit.Size = new System.Drawing.Size(341, 40);
            this.btnAddUnit.TabIndex = 0;
            this.btnAddUnit.Text = "Add Unit";
            this.btnAddUnit.UseVisualStyleBackColor = false;
            this.btnAddUnit.Click += new System.EventHandler(this.btnAddUnit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblavlbunits);
            this.panel2.Controls.Add(this.lblLastMonthSales);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblAvailableUnits);
            this.panel2.Controls.Add(this.lblCurrentMonthSales);
            this.panel2.Controls.Add(this.lblTotalUnits);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(838, 286);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(254, 277);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblavlbunits
            // 
            this.lblavlbunits.AutoSize = true;
            this.lblavlbunits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblavlbunits.Location = new System.Drawing.Point(100, 222);
            this.lblavlbunits.Name = "lblavlbunits";
            this.lblavlbunits.Size = new System.Drawing.Size(58, 22);
            this.lblavlbunits.TabIndex = 6;
            this.lblavlbunits.Text = "label5";
            // 
            // lblLastMonthSales
            // 
            this.lblLastMonthSales.AutoSize = true;
            this.lblLastMonthSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMonthSales.Location = new System.Drawing.Point(99, 141);
            this.lblLastMonthSales.Name = "lblLastMonthSales";
            this.lblLastMonthSales.Size = new System.Drawing.Size(45, 24);
            this.lblLastMonthSales.TabIndex = 5;
            this.lblLastMonthSales.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(212, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Previous Month Sales";
            // 
            // lblAvailableUnits
            // 
            this.lblAvailableUnits.AutoSize = true;
            this.lblAvailableUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblAvailableUnits.Location = new System.Drawing.Point(26, 178);
            this.lblAvailableUnits.Name = "lblAvailableUnits";
            this.lblAvailableUnits.Size = new System.Drawing.Size(193, 29);
            this.lblAvailableUnits.TabIndex = 1;
            this.lblAvailableUnits.Text = "Available Units:";
            // 
            // lblCurrentMonthSales
            // 
            this.lblCurrentMonthSales.AutoSize = true;
            this.lblCurrentMonthSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMonthSales.Location = new System.Drawing.Point(99, 71);
            this.lblCurrentMonthSales.Name = "lblCurrentMonthSales";
            this.lblCurrentMonthSales.Size = new System.Drawing.Size(45, 24);
            this.lblCurrentMonthSales.TabIndex = 3;
            this.lblCurrentMonthSales.Text = "0.00";
            this.lblCurrentMonthSales.Click += new System.EventHandler(this.lblCurrentMonthSales_Click);
            // 
            // lblTotalUnits
            // 
            this.lblTotalUnits.AutoSize = true;
            this.lblTotalUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalUnits.Location = new System.Drawing.Point(2, 32);
            this.lblTotalUnits.Name = "lblTotalUnits";
            this.lblTotalUnits.Size = new System.Drawing.Size(250, 29);
            this.lblTotalUnits.TabIndex = 0;
            this.lblTotalUnits.Text = "Current Month Sales";
            // 
            // UnitsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 638);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UnitsManagementForm";
            this.Text = "UnitsManagementForm";
            this.Load += new System.EventHandler(this.UnitsManagementForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.paneLeftUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CustData)).EndInit();
            this.panelRightUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartPaymentStatus)).EndInit();
            this.panelDownLeft.ResumeLayout(false);
            this.panelDownLeft.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel paneLeftUp;
        private System.Windows.Forms.DataGridView CustData;
        private System.Windows.Forms.Panel panelRightUp;
        private System.Windows.Forms.Panel panelDownLeft;
        private System.Windows.Forms.Button btnMarkSold;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAddUnit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalUnits;
        private System.Windows.Forms.Label lblAvailableUnits;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPaymentStatus;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearchContact;
        private System.Windows.Forms.Label lblCurrentMonthSales;
        private System.Windows.Forms.Label lblLastMonthSales;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblavlbunits;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFilter;
    }
}