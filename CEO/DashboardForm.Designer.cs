namespace RECMS.CEO
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.dgvLabor = new System.Windows.Forms.DataGridView();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.panelNetProfit = new System.Windows.Forms.Panel();
            this.lblTotalBudgetExpenses = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelExpenses = new System.Windows.Forms.Panel();
            this.lblTotalLaborExpenses = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelRevenue = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalMaterialExpensesUnfiltered = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.PrintAvailableUnits = new System.Windows.Forms.Button();
            this.btnPrintSoldUnits = new System.Windows.Forms.Button();
            this.dgvAvailableUnits = new System.Windows.Forms.DataGridView();
            this.btnFilter = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.txtSearchContact = new System.Windows.Forms.TextBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSoldUnits = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblAvailableUnits = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblLastMonthSales = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.lblCurrentMonthSales = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelMainContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.panelNetProfit.SuspendLayout();
            this.panelExpenses.SuspendLayout();
            this.panelRevenue.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldUnits)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.pictureBox2);
            this.panelTitleBar.Controls.Add(this.pictureBoxLogo);
            this.panelTitleBar.Controls.Add(this.label1);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1200, 63);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::RECMS.Properties.Resources.WhatsApp_Image_2025_05_28_at_14_422;
            this.pictureBox2.Location = new System.Drawing.Point(1165, 5);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBoxLogo.Location = new System.Drawing.Point(7, 5);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(0, 10, 20, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(51, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 1;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.Click += new System.EventHandler(this.pictureBoxLogo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.label1.Location = new System.Drawing.Point(81, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 63);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 737);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelMainContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1192, 708);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Projects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panelMainContent.Controls.Add(this.dgvLabor);
            this.panelMainContent.Controls.Add(this.dgvMaterials);
            this.panelMainContent.Controls.Add(this.btnRefresh);
            this.panelMainContent.Controls.Add(this.label12);
            this.panelMainContent.Controls.Add(this.cmbProjects);
            this.panelMainContent.Controls.Add(this.panelNetProfit);
            this.panelMainContent.Controls.Add(this.label3);
            this.panelMainContent.Controls.Add(this.panelExpenses);
            this.panelMainContent.Controls.Add(this.panelRevenue);
            this.panelMainContent.Location = new System.Drawing.Point(3, 2);
            this.panelMainContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1186, 704);
            this.panelMainContent.TabIndex = 2;
            // 
            // dgvLabor
            // 
            this.dgvLabor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvLabor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabor.Location = new System.Drawing.Point(376, 412);
            this.dgvLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLabor.Name = "dgvLabor";
            this.dgvLabor.ReadOnly = true;
            this.dgvLabor.RowHeadersWidth = 62;
            this.dgvLabor.RowTemplate.Height = 28;
            this.dgvLabor.Size = new System.Drawing.Size(733, 287);
            this.dgvLabor.TabIndex = 12;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(376, 113);
            this.dgvMaterials.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.ReadOnly = true;
            this.dgvMaterials.RowHeadersWidth = 62;
            this.dgvMaterials.RowTemplate.Height = 28;
            this.dgvMaterials.Size = new System.Drawing.Size(733, 287);
            this.dgvMaterials.TabIndex = 11;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRefresh.Location = new System.Drawing.Point(913, 41);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 40);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(534, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(109, 38);
            this.label12.TabIndex = 8;
            this.label12.Text = "Project";
            // 
            // cmbProjects
            // 
            this.cmbProjects.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(541, 52);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(356, 24);
            this.cmbProjects.TabIndex = 3;
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged_1);
            // 
            // panelNetProfit
            // 
            this.panelNetProfit.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panelNetProfit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelNetProfit.Controls.Add(this.lblTotalBudgetExpenses);
            this.panelNetProfit.Controls.Add(this.label9);
            this.panelNetProfit.Location = new System.Drawing.Point(44, 517);
            this.panelNetProfit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelNetProfit.Name = "panelNetProfit";
            this.panelNetProfit.Size = new System.Drawing.Size(249, 155);
            this.panelNetProfit.TabIndex = 2;
            // 
            // lblTotalBudgetExpenses
            // 
            this.lblTotalBudgetExpenses.AutoSize = true;
            this.lblTotalBudgetExpenses.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBudgetExpenses.Location = new System.Drawing.Point(88, 56);
            this.lblTotalBudgetExpenses.Name = "lblTotalBudgetExpenses";
            this.lblTotalBudgetExpenses.Size = new System.Drawing.Size(43, 24);
            this.lblTotalBudgetExpenses.TabIndex = 7;
            this.lblTotalBudgetExpenses.Text = "000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(18, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 24);
            this.label9.TabIndex = 5;
            this.label9.Text = "Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 38);
            this.label3.TabIndex = 0;
            this.label3.Text = "Expenses";
            // 
            // panelExpenses
            // 
            this.panelExpenses.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panelExpenses.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelExpenses.Controls.Add(this.lblTotalLaborExpenses);
            this.panelExpenses.Controls.Add(this.label6);
            this.panelExpenses.Location = new System.Drawing.Point(44, 326);
            this.panelExpenses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelExpenses.Name = "panelExpenses";
            this.panelExpenses.Size = new System.Drawing.Size(249, 177);
            this.panelExpenses.TabIndex = 1;
            // 
            // lblTotalLaborExpenses
            // 
            this.lblTotalLaborExpenses.AutoSize = true;
            this.lblTotalLaborExpenses.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLaborExpenses.Location = new System.Drawing.Point(96, 71);
            this.lblTotalLaborExpenses.Name = "lblTotalLaborExpenses";
            this.lblTotalLaborExpenses.Size = new System.Drawing.Size(43, 24);
            this.lblTotalLaborExpenses.TabIndex = 6;
            this.lblTotalLaborExpenses.Text = "000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Labor:";
            // 
            // panelRevenue
            // 
            this.panelRevenue.BackColor = System.Drawing.Color.Honeydew;
            this.panelRevenue.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRevenue.Controls.Add(this.label5);
            this.panelRevenue.Controls.Add(this.lblTotalMaterialExpensesUnfiltered);
            this.panelRevenue.Location = new System.Drawing.Point(44, 150);
            this.panelRevenue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRevenue.Name = "panelRevenue";
            this.panelRevenue.Size = new System.Drawing.Size(249, 170);
            this.panelRevenue.TabIndex = 0;
            this.panelRevenue.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRevenue_Paint_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Material:";
            // 
            // lblTotalMaterialExpensesUnfiltered
            // 
            this.lblTotalMaterialExpensesUnfiltered.AutoSize = true;
            this.lblTotalMaterialExpensesUnfiltered.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMaterialExpensesUnfiltered.Location = new System.Drawing.Point(116, 70);
            this.lblTotalMaterialExpensesUnfiltered.Name = "lblTotalMaterialExpensesUnfiltered";
            this.lblTotalMaterialExpensesUnfiltered.Size = new System.Drawing.Size(43, 24);
            this.lblTotalMaterialExpensesUnfiltered.TabIndex = 3;
            this.lblTotalMaterialExpensesUnfiltered.Text = "000";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1192, 708);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Units";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.PrintAvailableUnits);
            this.panel1.Controls.Add(this.btnPrintSoldUnits);
            this.panel1.Controls.Add(this.dgvAvailableUnits);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.txtSearchContact);
            this.panel1.Controls.Add(this.txtSearchName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dgvSoldUnits);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1186, 704);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.label7.Location = new System.Drawing.Point(831, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 34);
            this.label7.TabIndex = 24;
            this.label7.Text = "Filter:";
            // 
            // PrintAvailableUnits
            // 
            this.PrintAvailableUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.PrintAvailableUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PrintAvailableUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.PrintAvailableUnits.ForeColor = System.Drawing.Color.White;
            this.PrintAvailableUnits.Location = new System.Drawing.Point(1048, 661);
            this.PrintAvailableUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrintAvailableUnits.Name = "PrintAvailableUnits";
            this.PrintAvailableUnits.Size = new System.Drawing.Size(116, 29);
            this.PrintAvailableUnits.TabIndex = 23;
            this.PrintAvailableUnits.Text = "Print";
            this.PrintAvailableUnits.UseVisualStyleBackColor = false;
            this.PrintAvailableUnits.Click += new System.EventHandler(this.PrintAvailableUnits_Click);
            // 
            // btnPrintSoldUnits
            // 
            this.btnPrintSoldUnits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnPrintSoldUnits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintSoldUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPrintSoldUnits.ForeColor = System.Drawing.Color.White;
            this.btnPrintSoldUnits.Location = new System.Drawing.Point(1048, 394);
            this.btnPrintSoldUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintSoldUnits.Name = "btnPrintSoldUnits";
            this.btnPrintSoldUnits.Size = new System.Drawing.Size(116, 29);
            this.btnPrintSoldUnits.TabIndex = 22;
            this.btnPrintSoldUnits.Text = "Print";
            this.btnPrintSoldUnits.UseVisualStyleBackColor = false;
            this.btnPrintSoldUnits.Click += new System.EventHandler(this.btnPrintSoldUnits_Click);
            // 
            // dgvAvailableUnits
            // 
            this.dgvAvailableUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvailableUnits.Location = new System.Drawing.Point(331, 427);
            this.dgvAvailableUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAvailableUnits.Name = "dgvAvailableUnits";
            this.dgvAvailableUnits.ReadOnly = true;
            this.dgvAvailableUnits.RowHeadersWidth = 62;
            this.dgvAvailableUnits.RowTemplate.Height = 28;
            this.dgvAvailableUnits.Size = new System.Drawing.Size(833, 230);
            this.dgvAvailableUnits.TabIndex = 21;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(664, 105);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(500, 42);
            this.btnFilter.TabIndex = 20;
            this.btnFilter.Text = "Apply";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(914, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 24);
            this.label11.TabIndex = 19;
            this.label11.Text = "Date To";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(660, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 24);
            this.label10.TabIndex = 18;
            this.label10.Text = "Date From";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(918, 69);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(246, 22);
            this.dtpEndDate.TabIndex = 17;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(664, 69);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(248, 22);
            this.dtpStartDate.TabIndex = 16;
            // 
            // txtSearchContact
            // 
            this.txtSearchContact.Location = new System.Drawing.Point(467, 73);
            this.txtSearchContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchContact.Name = "txtSearchContact";
            this.txtSearchContact.Size = new System.Drawing.Size(176, 22);
            this.txtSearchContact.TabIndex = 14;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(285, 71);
            this.txtSearchName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(176, 22);
            this.txtSearchName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(281, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(463, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "Contact";
            // 
            // dgvSoldUnits
            // 
            this.dgvSoldUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoldUnits.Location = new System.Drawing.Point(331, 160);
            this.dgvSoldUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSoldUnits.Name = "dgvSoldUnits";
            this.dgvSoldUnits.ReadOnly = true;
            this.dgvSoldUnits.RowHeadersWidth = 62;
            this.dgvSoldUnits.RowTemplate.Height = 28;
            this.dgvSoldUnits.Size = new System.Drawing.Size(833, 230);
            this.dgvSoldUnits.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(285, 105);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(358, 42);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.label8.Location = new System.Drawing.Point(391, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 34);
            this.label8.TabIndex = 8;
            this.label8.Text = "Search:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(90, 114);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(128, 38);
            this.label18.TabIndex = 0;
            this.label18.Text = "Revenue";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lblAvailableUnits);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Location = new System.Drawing.Point(30, 518);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 155);
            this.panel2.TabIndex = 2;
            // 
            // lblAvailableUnits
            // 
            this.lblAvailableUnits.AutoSize = true;
            this.lblAvailableUnits.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvailableUnits.Location = new System.Drawing.Point(19, 79);
            this.lblAvailableUnits.Name = "lblAvailableUnits";
            this.lblAvailableUnits.Size = new System.Drawing.Size(43, 24);
            this.lblAvailableUnits.TabIndex = 7;
            this.lblAvailableUnits.Text = "000";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(19, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 24);
            this.label14.TabIndex = 5;
            this.label14.Text = "Available Units";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lblLastMonthSales);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(30, 337);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(249, 177);
            this.panel3.TabIndex = 1;
            // 
            // lblLastMonthSales
            // 
            this.lblLastMonthSales.AutoSize = true;
            this.lblLastMonthSales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastMonthSales.Location = new System.Drawing.Point(19, 88);
            this.lblLastMonthSales.Name = "lblLastMonthSales";
            this.lblLastMonthSales.Size = new System.Drawing.Size(43, 24);
            this.lblLastMonthSales.TabIndex = 6;
            this.lblLastMonthSales.Text = "000";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(216, 24);
            this.label15.TabIndex = 4;
            this.label15.Text = "Previous Month Sales";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Honeydew;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.lblCurrentMonthSales);
            this.panel4.Location = new System.Drawing.Point(30, 163);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 170);
            this.panel4.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(19, 35);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(205, 24);
            this.label17.TabIndex = 1;
            this.label17.Text = "Current Month Sales";
            // 
            // lblCurrentMonthSales
            // 
            this.lblCurrentMonthSales.AutoSize = true;
            this.lblCurrentMonthSales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentMonthSales.Location = new System.Drawing.Point(19, 78);
            this.lblCurrentMonthSales.Name = "lblCurrentMonthSales";
            this.lblCurrentMonthSales.Size = new System.Drawing.Size(43, 24);
            this.lblCurrentMonthSales.TabIndex = 3;
            this.lblCurrentMonthSales.Text = "000";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelTitleBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CEO Dashboard";
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelMainContent.ResumeLayout(false);
            this.panelMainContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.panelNetProfit.ResumeLayout(false);
            this.panelNetProfit.PerformLayout();
            this.panelExpenses.ResumeLayout(false);
            this.panelExpenses.PerformLayout();
            this.panelRevenue.ResumeLayout(false);
            this.panelRevenue.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoldUnits)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Panel panelNetProfit;
        private System.Windows.Forms.Panel panelExpenses;
        private System.Windows.Forms.Label lblTotalBudgetExpenses;
        private System.Windows.Forms.Label lblTotalLaborExpenses;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalMaterialExpensesUnfiltered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelRevenue;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblAvailableUnits;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblLastMonthSales;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblCurrentMonthSales;
        private System.Windows.Forms.DataGridView dgvLabor;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.DataGridView dgvSoldUnits;
        private System.Windows.Forms.TextBox txtSearchContact;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DataGridView dgvAvailableUnits;
        private System.Windows.Forms.Button btnPrintSoldUnits;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button PrintAvailableUnits;
        private System.Windows.Forms.Label label7;
    }
}