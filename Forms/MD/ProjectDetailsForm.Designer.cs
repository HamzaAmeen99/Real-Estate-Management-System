namespace RECMS.Forms
{
    partial class ProjectDetailsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMatBack = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.btnAddProject = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.lblActiveLabor = new System.Windows.Forms.Label();
            this.lblBudgetUsed = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.tabProgress = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelT1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterSupplier = new System.Windows.Forms.ComboBox();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbFilterMaterial = new System.Windows.Forms.ComboBox();
            this.dgvdatamaterial = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteLabor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalSalary = new System.Windows.Forms.Label();
            this.btnClearLaborFilters = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFilterRole = new System.Windows.Forms.ComboBox();
            this.cmbFilterContractor = new System.Windows.Forms.ComboBox();
            this.cmbFilterName = new System.Windows.Forms.ComboBox();
            this.btnApplyLaborFilter = new System.Windows.Forms.Button();
            this.btnAddLabor = new System.Windows.Forms.Button();
            this.dgvLabor = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSaveProgress = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblImageCounter = new System.Windows.Forms.Label();
            this.txtImageDescription = new System.Windows.Forms.TextBox();
            this.btnSaveDescription = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnAddImage = new System.Windows.Forms.Button();
            this.picProjectImage = new System.Windows.Forms.PictureBox();
            this.lblProgressPercentage = new System.Windows.Forms.Label();
            this.progressBarProject = new System.Windows.Forms.ProgressBar();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTotalBudgetExpenses = new System.Windows.Forms.Label();
            this.lblTotalMaterialExpensesUnfiltered = new System.Windows.Forms.Label();
            this.lblTotalLaborExpenses = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMatBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabProgress.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelT1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdatamaterial)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.panel1.Controls.Add(this.btnMatBack);
            this.panel1.Controls.Add(this.buttonClose);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1130, 81);
            this.panel1.TabIndex = 0;
            // 
            // btnMatBack
            // 
            this.btnMatBack.Image = global::RECMS.Properties.Resources.Back_round;
            this.btnMatBack.Location = new System.Drawing.Point(1, 1);
            this.btnMatBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMatBack.Name = "btnMatBack";
            this.btnMatBack.Size = new System.Drawing.Size(44, 38);
            this.btnMatBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnMatBack.TabIndex = 23;
            this.btnMatBack.TabStop = false;
            this.btnMatBack.Click += new System.EventHandler(this.btnMatBack_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(142)))), ((int)(((byte)(136)))));
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.ForeColor = System.Drawing.Color.Red;
            this.buttonClose.Location = new System.Drawing.Point(1081, 0);
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
            this.label2.Location = new System.Drawing.Point(252, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(680, 39);
            this.label2.TabIndex = 20;
            this.label2.Text = "BFS REAL ESTATE AND DEVELOPERS";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RECMS.Properties.Resources.BFS_White;
            this.pictureBox1.Location = new System.Drawing.Point(141, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(92, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // cmbProjects
            // 
            this.cmbProjects.DisplayMember = "ProjectName";
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(329, 86);
            this.cmbProjects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(308, 24);
            this.cmbProjects.TabIndex = 2;
            this.cmbProjects.ValueMember = "ProjectID";
            this.cmbProjects.SelectedIndexChanged += new System.EventHandler(this.cmbProjects_SelectedIndexChanged);
            // 
            // btnAddProject
            // 
            this.btnAddProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnAddProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProject.ForeColor = System.Drawing.Color.White;
            this.btnAddProject.Location = new System.Drawing.Point(874, 85);
            this.btnAddProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(194, 43);
            this.btnAddProject.TabIndex = 3;
            this.btnAddProject.Text = "New Project";
            this.btnAddProject.UseVisualStyleBackColor = false;
            this.btnAddProject.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(38, 46);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(198, 28);
            this.lbl1.TabIndex = 0;
            this.lbl1.Text = "Materials Expenses:";
            // 
            // lblActiveLabor
            // 
            this.lblActiveLabor.AutoSize = true;
            this.lblActiveLabor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveLabor.Location = new System.Drawing.Point(52, 142);
            this.lblActiveLabor.Name = "lblActiveLabor";
            this.lblActiveLabor.Size = new System.Drawing.Size(162, 28);
            this.lblActiveLabor.TabIndex = 1;
            this.lblActiveLabor.Text = "Labor Expenses:";
            // 
            // lblBudgetUsed
            // 
            this.lblBudgetUsed.AutoSize = true;
            this.lblBudgetUsed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBudgetUsed.Location = new System.Drawing.Point(52, 261);
            this.lblBudgetUsed.Name = "lblBudgetUsed";
            this.lblBudgetUsed.Size = new System.Drawing.Size(176, 28);
            this.lblBudgetUsed.TabIndex = 2;
            this.lblBudgetUsed.Text = "Project Expenses:";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.AutoSize = true;
            this.lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpenses.Location = new System.Drawing.Point(274, 60);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Size = new System.Drawing.Size(70, 28);
            this.lblTotalExpenses.TabIndex = 7;
            this.lblTotalExpenses.Text = "label4";
            this.lblTotalExpenses.Click += new System.EventHandler(this.lblTotalExpenses_Click);
            // 
            // tabProgress
            // 
            this.tabProgress.Controls.Add(this.tabPage1);
            this.tabProgress.Controls.Add(this.tabPage2);
            this.tabProgress.Controls.Add(this.tabPage3);
            this.tabProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProgress.Location = new System.Drawing.Point(0, 0);
            this.tabProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.SelectedIndex = 0;
            this.tabProgress.Size = new System.Drawing.Size(813, 479);
            this.tabProgress.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelT1);
            this.tabPage1.Controls.Add(this.dgvdatamaterial);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(805, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Material_Manage";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelT1
            // 
            this.panelT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panelT1.Controls.Add(this.cmbFilterMaterial);
            this.panelT1.Controls.Add(this.label8);
            this.panelT1.Controls.Add(this.btnDeleteMaterial);
            this.panelT1.Controls.Add(this.lblTotalExpenses);
            this.panelT1.Controls.Add(this.label1);
            this.panelT1.Controls.Add(this.cmbFilterSupplier);
            this.panelT1.Controls.Add(this.btnAddMaterial);
            this.panelT1.Controls.Add(this.label3);
            this.panelT1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelT1.Location = new System.Drawing.Point(3, 354);
            this.panelT1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelT1.Name = "panelT1";
            this.panelT1.Size = new System.Drawing.Size(799, 94);
            this.panelT1.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(141, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 28);
            this.label8.TabIndex = 9;
            this.label8.Text = "Expenses:";
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnDeleteMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteMaterial.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMaterial.Location = new System.Drawing.Point(560, 52);
            this.btnDeleteMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(220, 44);
            this.btnDeleteMaterial.TabIndex = 2;
            this.btnDeleteMaterial.Text = "Delete";
            this.btnDeleteMaterial.UseVisualStyleBackColor = false;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Filter by Supplier:";
            // 
            // cmbFilterSupplier
            // 
            this.cmbFilterSupplier.FormattingEnabled = true;
            this.cmbFilterSupplier.Location = new System.Drawing.Point(219, 34);
            this.cmbFilterSupplier.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterSupplier.Name = "cmbFilterSupplier";
            this.cmbFilterSupplier.Size = new System.Drawing.Size(198, 24);
            this.cmbFilterSupplier.TabIndex = 4;
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnAddMaterial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMaterial.ForeColor = System.Drawing.Color.White;
            this.btnAddMaterial.Location = new System.Drawing.Point(560, 2);
            this.btnAddMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(220, 48);
            this.btnAddMaterial.TabIndex = 0;
            this.btnAddMaterial.Text = "Add";
            this.btnAddMaterial.UseVisualStyleBackColor = false;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Filter by Materials:";
            // 
            // cmbFilterMaterial
            // 
            this.cmbFilterMaterial.FormattingEnabled = true;
            this.cmbFilterMaterial.Location = new System.Drawing.Point(5, 34);
            this.cmbFilterMaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterMaterial.Name = "cmbFilterMaterial";
            this.cmbFilterMaterial.Size = new System.Drawing.Size(192, 24);
            this.cmbFilterMaterial.TabIndex = 3;
            // 
            // dgvdatamaterial
            // 
            this.dgvdatamaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdatamaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvdatamaterial.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvdatamaterial.Location = new System.Drawing.Point(3, 2);
            this.dgvdatamaterial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvdatamaterial.Name = "dgvdatamaterial";
            this.dgvdatamaterial.ReadOnly = true;
            this.dgvdatamaterial.RowHeadersWidth = 62;
            this.dgvdatamaterial.RowTemplate.Height = 28;
            this.dgvdatamaterial.Size = new System.Drawing.Size(799, 446);
            this.dgvdatamaterial.TabIndex = 0;
            this.dgvdatamaterial.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.dgvLabor);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(805, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Labor_Manage";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.btnDeleteLabor);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblTotalSalary);
            this.panel2.Controls.Add(this.btnClearLaborFilters);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cmbFilterRole);
            this.panel2.Controls.Add(this.cmbFilterContractor);
            this.panel2.Controls.Add(this.cmbFilterName);
            this.panel2.Controls.Add(this.btnApplyLaborFilter);
            this.panel2.Controls.Add(this.btnAddLabor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 261);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(799, 187);
            this.panel2.TabIndex = 1;
            // 
            // btnDeleteLabor
            // 
            this.btnDeleteLabor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnDeleteLabor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteLabor.ForeColor = System.Drawing.Color.White;
            this.btnDeleteLabor.Location = new System.Drawing.Point(8, 98);
            this.btnDeleteLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteLabor.Name = "btnDeleteLabor";
            this.btnDeleteLabor.Size = new System.Drawing.Size(161, 52);
            this.btnDeleteLabor.TabIndex = 13;
            this.btnDeleteLabor.Text = "Delete";
            this.btnDeleteLabor.UseVisualStyleBackColor = false;
            this.btnDeleteLabor.Click += new System.EventHandler(this.btnDeleteLabor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(367, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 19);
            this.label7.TabIndex = 12;
            this.label7.Text = "Contractor:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(558, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "Role:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(185, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Name:";
            // 
            // lblTotalSalary
            // 
            this.lblTotalSalary.AutoSize = true;
            this.lblTotalSalary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSalary.Location = new System.Drawing.Point(292, 147);
            this.lblTotalSalary.Name = "lblTotalSalary";
            this.lblTotalSalary.Size = new System.Drawing.Size(254, 28);
            this.lblTotalSalary.TabIndex = 10;
            this.lblTotalSalary.Text = "Total Salary/Expenses: 00";
            this.lblTotalSalary.Click += new System.EventHandler(this.lblTotalSalary_Click);
            // 
            // btnClearLaborFilters
            // 
            this.btnClearLaborFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnClearLaborFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearLaborFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearLaborFilters.ForeColor = System.Drawing.Color.White;
            this.btnClearLaborFilters.Location = new System.Drawing.Point(458, 101);
            this.btnClearLaborFilters.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearLaborFilters.Name = "btnClearLaborFilters";
            this.btnClearLaborFilters.Size = new System.Drawing.Size(220, 47);
            this.btnClearLaborFilters.TabIndex = 9;
            this.btnClearLaborFilters.Text = "Clear Filters";
            this.btnClearLaborFilters.UseVisualStyleBackColor = false;
            this.btnClearLaborFilters.Click += new System.EventHandler(this.btnClearLaborFilters_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(393, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Apply Filter:";
            // 
            // cmbFilterRole
            // 
            this.cmbFilterRole.FormattingEnabled = true;
            this.cmbFilterRole.Location = new System.Drawing.Point(562, 58);
            this.cmbFilterRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterRole.Name = "cmbFilterRole";
            this.cmbFilterRole.Size = new System.Drawing.Size(167, 24);
            this.cmbFilterRole.TabIndex = 4;
            // 
            // cmbFilterContractor
            // 
            this.cmbFilterContractor.FormattingEnabled = true;
            this.cmbFilterContractor.Location = new System.Drawing.Point(370, 58);
            this.cmbFilterContractor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterContractor.Name = "cmbFilterContractor";
            this.cmbFilterContractor.Size = new System.Drawing.Size(167, 24);
            this.cmbFilterContractor.TabIndex = 3;
            // 
            // cmbFilterName
            // 
            this.cmbFilterName.FormattingEnabled = true;
            this.cmbFilterName.Location = new System.Drawing.Point(188, 58);
            this.cmbFilterName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbFilterName.Name = "cmbFilterName";
            this.cmbFilterName.Size = new System.Drawing.Size(167, 24);
            this.cmbFilterName.TabIndex = 2;
            // 
            // btnApplyLaborFilter
            // 
            this.btnApplyLaborFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnApplyLaborFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyLaborFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyLaborFilter.ForeColor = System.Drawing.Color.White;
            this.btnApplyLaborFilter.Location = new System.Drawing.Point(232, 101);
            this.btnApplyLaborFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApplyLaborFilter.Name = "btnApplyLaborFilter";
            this.btnApplyLaborFilter.Size = new System.Drawing.Size(220, 47);
            this.btnApplyLaborFilter.TabIndex = 1;
            this.btnApplyLaborFilter.Text = "Apply Filters";
            this.btnApplyLaborFilter.UseVisualStyleBackColor = false;
            this.btnApplyLaborFilter.Click += new System.EventHandler(this.btnApplyLaborFilter_Click);
            // 
            // btnAddLabor
            // 
            this.btnAddLabor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnAddLabor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddLabor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLabor.ForeColor = System.Drawing.Color.White;
            this.btnAddLabor.Location = new System.Drawing.Point(8, 38);
            this.btnAddLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddLabor.Name = "btnAddLabor";
            this.btnAddLabor.Size = new System.Drawing.Size(161, 52);
            this.btnAddLabor.TabIndex = 0;
            this.btnAddLabor.Text = "Add";
            this.btnAddLabor.UseVisualStyleBackColor = false;
            this.btnAddLabor.Click += new System.EventHandler(this.btnAddLabor_Click);
            // 
            // dgvLabor
            // 
            this.dgvLabor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLabor.Location = new System.Drawing.Point(3, 2);
            this.dgvLabor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLabor.Name = "dgvLabor";
            this.dgvLabor.ReadOnly = true;
            this.dgvLabor.RowHeadersWidth = 62;
            this.dgvLabor.RowTemplate.Height = 28;
            this.dgvLabor.Size = new System.Drawing.Size(799, 446);
            this.dgvLabor.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.tabPage3.Controls.Add(this.panel5);
            this.tabPage3.Controls.Add(this.panel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage3.Size = new System.Drawing.Size(805, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Project_Progress";
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click);
            // 
            // panel5
            // 
            this.panel5.AutoScroll = true;
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panel5.Controls.Add(this.btnSaveProgress);
            this.panel5.Location = new System.Drawing.Point(-4, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(280, 456);
            this.panel5.TabIndex = 2;
            // 
            // btnSaveProgress
            // 
            this.btnSaveProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnSaveProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveProgress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveProgress.ForeColor = System.Drawing.Color.White;
            this.btnSaveProgress.Location = new System.Drawing.Point(0, 398);
            this.btnSaveProgress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveProgress.Name = "btnSaveProgress";
            this.btnSaveProgress.Size = new System.Drawing.Size(280, 58);
            this.btnSaveProgress.TabIndex = 2;
            this.btnSaveProgress.Text = "Update Progress";
            this.btnSaveProgress.UseVisualStyleBackColor = false;
            this.btnSaveProgress.Click += new System.EventHandler(this.btnSaveProgress_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.panel3.Controls.Add(this.lblImageCounter);
            this.panel3.Controls.Add(this.txtImageDescription);
            this.panel3.Controls.Add(this.btnSaveDescription);
            this.panel3.Controls.Add(this.btnNext);
            this.panel3.Controls.Add(this.btnDeleteImage);
            this.panel3.Controls.Add(this.btnPrev);
            this.panel3.Controls.Add(this.btnAddImage);
            this.panel3.Controls.Add(this.picProjectImage);
            this.panel3.Controls.Add(this.lblProgressPercentage);
            this.panel3.Controls.Add(this.progressBarProject);
            this.panel3.Location = new System.Drawing.Point(274, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(490, 643);
            this.panel3.TabIndex = 1;
            // 
            // lblImageCounter
            // 
            this.lblImageCounter.AutoSize = true;
            this.lblImageCounter.Location = new System.Drawing.Point(94, 334);
            this.lblImageCounter.Name = "lblImageCounter";
            this.lblImageCounter.Size = new System.Drawing.Size(25, 16);
            this.lblImageCounter.TabIndex = 11;
            this.lblImageCounter.Text = "0/0";
            // 
            // txtImageDescription
            // 
            this.txtImageDescription.Location = new System.Drawing.Point(61, 367);
            this.txtImageDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtImageDescription.Multiline = true;
            this.txtImageDescription.Name = "txtImageDescription";
            this.txtImageDescription.Size = new System.Drawing.Size(350, 22);
            this.txtImageDescription.TabIndex = 10;
            // 
            // btnSaveDescription
            // 
            this.btnSaveDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnSaveDescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDescription.ForeColor = System.Drawing.Color.White;
            this.btnSaveDescription.Location = new System.Drawing.Point(132, 398);
            this.btnSaveDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveDescription.Name = "btnSaveDescription";
            this.btnSaveDescription.Size = new System.Drawing.Size(212, 48);
            this.btnSaveDescription.TabIndex = 9;
            this.btnSaveDescription.Text = "Save Description";
            this.btnSaveDescription.UseVisualStyleBackColor = false;
            this.btnSaveDescription.Click += new System.EventHandler(this.btnSaveDescription_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(246, 334);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(67, 28);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnDeleteImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage.ForeColor = System.Drawing.Color.White;
            this.btnDeleteImage.Location = new System.Drawing.Point(277, 55);
            this.btnDeleteImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(133, 37);
            this.btnDeleteImage.TabIndex = 7;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = false;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.ForeColor = System.Drawing.Color.White;
            this.btnPrev.Location = new System.Drawing.Point(174, 334);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(67, 28);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.Text = "<";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnAddImage
            // 
            this.btnAddImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnAddImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImage.ForeColor = System.Drawing.Color.White;
            this.btnAddImage.Location = new System.Drawing.Point(61, 55);
            this.btnAddImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddImage.Name = "btnAddImage";
            this.btnAddImage.Size = new System.Drawing.Size(133, 37);
            this.btnAddImage.TabIndex = 5;
            this.btnAddImage.Text = "Add Image";
            this.btnAddImage.UseVisualStyleBackColor = false;
            this.btnAddImage.Click += new System.EventHandler(this.btnAddImage_Click);
            // 
            // picProjectImage
            // 
            this.picProjectImage.Location = new System.Drawing.Point(61, 97);
            this.picProjectImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picProjectImage.Name = "picProjectImage";
            this.picProjectImage.Size = new System.Drawing.Size(349, 219);
            this.picProjectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProjectImage.TabIndex = 4;
            this.picProjectImage.TabStop = false;
            // 
            // lblProgressPercentage
            // 
            this.lblProgressPercentage.AutoSize = true;
            this.lblProgressPercentage.Location = new System.Drawing.Point(214, 43);
            this.lblProgressPercentage.Name = "lblProgressPercentage";
            this.lblProgressPercentage.Size = new System.Drawing.Size(44, 16);
            this.lblProgressPercentage.TabIndex = 3;
            this.lblProgressPercentage.Text = "label9";
            // 
            // progressBarProject
            // 
            this.progressBarProject.Location = new System.Drawing.Point(0, 0);
            this.progressBarProject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBarProject.Name = "progressBarProject";
            this.progressBarProject.Size = new System.Drawing.Size(490, 32);
            this.progressBarProject.TabIndex = 0;
            this.progressBarProject.Value = 60;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(79)))), ((int)(((byte)(72)))));
            this.btnGenerateReport.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Location = new System.Drawing.Point(3, 422);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(310, 55);
            this.btnGenerateReport.TabIndex = 3;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(0, 120);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabProgress);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(1133, 479);
            this.splitContainer1.SplitterDistance = 813;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(316, 479);
            this.panel4.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTotalBudgetExpenses);
            this.groupBox1.Controls.Add(this.lblTotalMaterialExpensesUnfiltered);
            this.groupBox1.Controls.Add(this.lblTotalLaborExpenses);
            this.groupBox1.Controls.Add(this.btnGenerateReport);
            this.groupBox1.Controls.Add(this.lblBudgetUsed);
            this.groupBox1.Controls.Add(this.lblActiveLabor);
            this.groupBox1.Controls.Add(this.lbl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(316, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblTotalBudgetExpenses
            // 
            this.lblTotalBudgetExpenses.AutoSize = true;
            this.lblTotalBudgetExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalBudgetExpenses.Location = new System.Drawing.Point(129, 304);
            this.lblTotalBudgetExpenses.Name = "lblTotalBudgetExpenses";
            this.lblTotalBudgetExpenses.Size = new System.Drawing.Size(53, 28);
            this.lblTotalBudgetExpenses.TabIndex = 10;
            this.lblTotalBudgetExpenses.Text = "0.00";
            // 
            // lblTotalMaterialExpensesUnfiltered
            // 
            this.lblTotalMaterialExpensesUnfiltered.AutoSize = true;
            this.lblTotalMaterialExpensesUnfiltered.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMaterialExpensesUnfiltered.Location = new System.Drawing.Point(106, 90);
            this.lblTotalMaterialExpensesUnfiltered.Name = "lblTotalMaterialExpensesUnfiltered";
            this.lblTotalMaterialExpensesUnfiltered.Size = new System.Drawing.Size(53, 28);
            this.lblTotalMaterialExpensesUnfiltered.TabIndex = 9;
            this.lblTotalMaterialExpensesUnfiltered.Text = "0.00";
            // 
            // lblTotalLaborExpenses
            // 
            this.lblTotalLaborExpenses.AutoSize = true;
            this.lblTotalLaborExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLaborExpenses.Location = new System.Drawing.Point(106, 185);
            this.lblTotalLaborExpenses.Name = "lblTotalLaborExpenses";
            this.lblTotalLaborExpenses.Size = new System.Drawing.Size(53, 28);
            this.lblTotalLaborExpenses.TabIndex = 8;
            this.lblTotalLaborExpenses.Text = "0.00";
            // 
            // ProjectDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(243)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1128, 600);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ProjectDetailsForm";
            this.Text = "ProjectDetailsForm";
            this.Load += new System.EventHandler(this.ProjectDetailsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMatBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabProgress.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelT1.ResumeLayout(false);
            this.panelT1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdatamaterial)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectImage)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnMatBack;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Button btnAddProject;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lblActiveLabor;
        private System.Windows.Forms.Label lblBudgetUsed;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.TabControl tabProgress;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panelT1;
        private System.Windows.Forms.Button btnDeleteMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterSupplier;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbFilterMaterial;
        private System.Windows.Forms.DataGridView dgvdatamaterial;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnApplyLaborFilter;
        private System.Windows.Forms.Button btnAddLabor;
        private System.Windows.Forms.DataGridView dgvLabor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbFilterRole;
        private System.Windows.Forms.ComboBox cmbFilterContractor;
        private System.Windows.Forms.ComboBox cmbFilterName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClearLaborFilters;
        private System.Windows.Forms.Label lblTotalSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDeleteLabor;
        private System.Windows.Forms.Label lblTotalLaborExpenses;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTotalMaterialExpensesUnfiltered;
        private System.Windows.Forms.Label lblTotalBudgetExpenses;
        private System.Windows.Forms.Label lblProgressPercentage;
        private System.Windows.Forms.Button btnSaveProgress;
        private System.Windows.Forms.ProgressBar progressBarProject;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSaveDescription;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnAddImage;
        private System.Windows.Forms.PictureBox picProjectImage;
        private System.Windows.Forms.TextBox txtImageDescription;
        private System.Windows.Forms.Label lblImageCounter;
    }
}