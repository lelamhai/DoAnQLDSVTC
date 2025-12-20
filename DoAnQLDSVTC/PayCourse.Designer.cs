namespace DoAnQLDSVTC
{
    partial class PayCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayCourse));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMaLop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtTenSV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dgvHocPhi = new System.Windows.Forms.DataGridView();
            this.ANIENKHOA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHOCKY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AHOCPHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TONGTIENDADONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOTIENCANDONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbsDSHOCPHI = new System.Windows.Forms.BindingSource(this.components);
            this.DS1 = new DoAnQLDSVTC.DS1();
            this.panel12 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.dgvCTHOCPHI = new System.Windows.Forms.DataGridView();
            this.BNGAYDONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BSOTIENDONG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbsCTHOCPHI = new System.Windows.Forms.BindingSource(this.components);
            this.panel15 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.SP_LAYDS_HOCPHITableAdapter = new DoAnQLDSVTC.DS1TableAdapters.SP_LAYDS_HOCPHITableAdapter();
            this.SP_LAYDS_CTDONGHOCPHITableAdapter = new DoAnQLDSVTC.DS1TableAdapters.SP_LAYDS_CTDONGHOCPHITableAdapter();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsDSHOCPHI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).BeginInit();
            this.panel14.SuspendLayout();
            this.panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHOCPHI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCTHOCPHI)).BeginInit();
            this.panel15.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel1.Size = new System.Drawing.Size(1282, 60);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnSearch);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(922, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(200, 60);
            this.panel8.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.IndianRed;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(3, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(892, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(30, 60);
            this.panel7.TabIndex = 6;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtMaLop);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(685, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(207, 60);
            this.panel6.TabIndex = 5;
            // 
            // txtMaLop
            // 
            this.txtMaLop.Location = new System.Drawing.Point(70, 18);
            this.txtMaLop.Name = "txtMaLop";
            this.txtMaLop.ReadOnly = true;
            this.txtMaLop.Size = new System.Drawing.Size(125, 26);
            this.txtMaLop.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 60);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mã Lớp";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(655, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(30, 60);
            this.panel5.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtTenSV);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(425, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(230, 60);
            this.panel4.TabIndex = 3;
            // 
            // txtTenSV
            // 
            this.txtTenSV.Location = new System.Drawing.Point(97, 18);
            this.txtTenSV.Name = "txtTenSV";
            this.txtTenSV.ReadOnly = true;
            this.txtTenSV.Size = new System.Drawing.Size(125, 26);
            this.txtTenSV.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 60);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên Sinh Viên";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(395, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 60);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtMaSV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(165, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(230, 60);
            this.panel2.TabIndex = 1;
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(94, 18);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(125, 26);
            this.txtMaSV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 60);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã Sinh Viên";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông Tin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 60);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1282, 15);
            this.panel9.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Controls.Add(this.panel12);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 75);
            this.panel10.Margin = new System.Windows.Forms.Padding(0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1282, 385);
            this.panel10.TabIndex = 2;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.dgvHocPhi);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(0, 80);
            this.panel13.Margin = new System.Windows.Forms.Padding(0);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(15, 0, 15, 15);
            this.panel13.Size = new System.Drawing.Size(1282, 305);
            this.panel13.TabIndex = 8;
            // 
            // dgvHocPhi
            // 
            this.dgvHocPhi.AllowUserToAddRows = false;
            this.dgvHocPhi.AutoGenerateColumns = false;
            this.dgvHocPhi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHocPhi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHocPhi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ANIENKHOA,
            this.AHOCKY,
            this.AHOCPHI,
            this.TONGTIENDADONG,
            this.SOTIENCANDONG});
            this.dgvHocPhi.DataSource = this.dbsDSHOCPHI;
            this.dgvHocPhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHocPhi.Location = new System.Drawing.Point(15, 0);
            this.dgvHocPhi.Margin = new System.Windows.Forms.Padding(0);
            this.dgvHocPhi.Name = "dgvHocPhi";
            this.dgvHocPhi.Size = new System.Drawing.Size(1252, 290);
            this.dgvHocPhi.TabIndex = 0;
            this.dgvHocPhi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHocPhi_CellClick);
            // 
            // ANIENKHOA
            // 
            this.ANIENKHOA.DataPropertyName = "NIENKHOA";
            this.ANIENKHOA.HeaderText = "Niên Khóa";
            this.ANIENKHOA.Name = "ANIENKHOA";
            this.ANIENKHOA.ReadOnly = true;
            // 
            // AHOCKY
            // 
            this.AHOCKY.DataPropertyName = "HOCKY";
            this.AHOCKY.HeaderText = "Học Kỳ";
            this.AHOCKY.Name = "AHOCKY";
            this.AHOCKY.ReadOnly = true;
            // 
            // AHOCPHI
            // 
            this.AHOCPHI.DataPropertyName = "HOCPHI";
            this.AHOCPHI.HeaderText = "Học Phí";
            this.AHOCPHI.Name = "AHOCPHI";
            this.AHOCPHI.ReadOnly = true;
            // 
            // TONGTIENDADONG
            // 
            this.TONGTIENDADONG.DataPropertyName = "TONGTIENDADONG";
            this.TONGTIENDADONG.HeaderText = "Số Tiền Đã Đóng";
            this.TONGTIENDADONG.Name = "TONGTIENDADONG";
            this.TONGTIENDADONG.ReadOnly = true;
            // 
            // SOTIENCANDONG
            // 
            this.SOTIENCANDONG.DataPropertyName = "SOTIENCANDONG";
            this.SOTIENCANDONG.HeaderText = "Số Tiền Cần Đóng";
            this.SOTIENCANDONG.Name = "SOTIENCANDONG";
            this.SOTIENCANDONG.ReadOnly = true;
            // 
            // dbsDSHOCPHI
            // 
            this.dbsDSHOCPHI.DataMember = "SP_LAYDS_HOCPHI";
            this.dbsDSHOCPHI.DataSource = this.DS1;
            // 
            // DS1
            // 
            this.DS1.DataSetName = "DS1";
            this.DS1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(0, 50);
            this.panel12.Margin = new System.Windows.Forms.Padding(0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1282, 30);
            this.panel12.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1282, 50);
            this.label5.TabIndex = 6;
            this.label5.Text = "Đóng Học Phí Theo Niên Khóa Và Học Kỳ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel11.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel11.Location = new System.Drawing.Point(0, 460);
            this.panel11.Margin = new System.Windows.Forms.Padding(0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(1282, 15);
            this.panel11.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 475);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1282, 50);
            this.label6.TabIndex = 7;
            this.label6.Text = "Chi Tiết Đóng Học Phí";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(0, 525);
            this.panel14.Margin = new System.Windows.Forms.Padding(0);
            this.panel14.Name = "panel14";
            this.panel14.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel14.Size = new System.Drawing.Size(1282, 224);
            this.panel14.TabIndex = 8;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.dgvCTHOCPHI);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel16.Location = new System.Drawing.Point(15, 30);
            this.panel16.Margin = new System.Windows.Forms.Padding(0);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1252, 194);
            this.panel16.TabIndex = 1;
            // 
            // dgvCTHOCPHI
            // 
            this.dgvCTHOCPHI.AllowUserToAddRows = false;
            this.dgvCTHOCPHI.AutoGenerateColumns = false;
            this.dgvCTHOCPHI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCTHOCPHI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTHOCPHI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BNGAYDONG,
            this.BSOTIENDONG});
            this.dgvCTHOCPHI.DataSource = this.dbsCTHOCPHI;
            this.dgvCTHOCPHI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCTHOCPHI.Location = new System.Drawing.Point(0, 0);
            this.dgvCTHOCPHI.Margin = new System.Windows.Forms.Padding(0);
            this.dgvCTHOCPHI.Name = "dgvCTHOCPHI";
            this.dgvCTHOCPHI.Size = new System.Drawing.Size(1252, 194);
            this.dgvCTHOCPHI.TabIndex = 0;
            this.dgvCTHOCPHI.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCTHOCPHI_CellBeginEdit);
            this.dgvCTHOCPHI.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCTHOCPHI_CellValueChanged);
            this.dgvCTHOCPHI.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCTHOCPHI_DataError);
            // 
            // BNGAYDONG
            // 
            this.BNGAYDONG.DataPropertyName = "NGAYDONG";
            this.BNGAYDONG.HeaderText = "Ngày Đóng";
            this.BNGAYDONG.Name = "BNGAYDONG";
            this.BNGAYDONG.ReadOnly = true;
            // 
            // BSOTIENDONG
            // 
            this.BSOTIENDONG.DataPropertyName = "SOTIENDONG";
            this.BSOTIENDONG.HeaderText = "Số Tiền Đóng";
            this.BSOTIENDONG.Name = "BSOTIENDONG";
            this.BSOTIENDONG.ReadOnly = true;
            // 
            // dbsCTHOCPHI
            // 
            this.dbsCTHOCPHI.DataMember = "SP_LAYDS_CTDONGHOCPHI";
            this.dbsCTHOCPHI.DataSource = this.DS1;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.tableLayoutPanel1);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(15, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(1252, 30);
            this.panel15.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 742F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddRow, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1252, 30);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(263, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(69, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(188, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(69, 24);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Ghi";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(78, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(104, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Chỉnh Sửa";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddRow
            // 
            this.btnAddRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddRow.FlatAppearance.BorderSize = 0;
            this.btnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRow.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRow.Image")));
            this.btnAddRow.Location = new System.Drawing.Point(3, 3);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(69, 24);
            this.btnAddRow.TabIndex = 1;
            this.btnAddRow.Text = "Thêm";
            this.btnAddRow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // SP_LAYDS_HOCPHITableAdapter
            // 
            this.SP_LAYDS_HOCPHITableAdapter.ClearBeforeFill = true;
            // 
            // SP_LAYDS_CTDONGHOCPHITableAdapter
            // 
            this.SP_LAYDS_CTDONGHOCPHITableAdapter.ClearBeforeFill = true;
            // 
            // PayCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 749);
            this.Controls.Add(this.panel14);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PayCourse";
            this.Text = "Học Phí";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PayCourse_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHocPhi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsDSHOCPHI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS1)).EndInit();
            this.panel14.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTHOCPHI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsCTHOCPHI)).EndInit();
            this.panel15.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaLop;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.DataGridView dgvHocPhi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.DataGridView dgvCTHOCPHI;
        private System.Windows.Forms.TextBox txtTenSV;
        private DS1 DS1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.BindingSource dbsDSHOCPHI;
        private System.Windows.Forms.BindingSource dbsCTHOCPHI;
        private DS1TableAdapters.SP_LAYDS_HOCPHITableAdapter SP_LAYDS_HOCPHITableAdapter;
        private DS1TableAdapters.SP_LAYDS_CTDONGHOCPHITableAdapter SP_LAYDS_CTDONGHOCPHITableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANIENKHOA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHOCKY;
        private System.Windows.Forms.DataGridViewTextBoxColumn AHOCPHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn TONGTIENDADONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOTIENCANDONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn BNGAYDONG;
        private System.Windows.Forms.DataGridViewTextBoxColumn BSOTIENDONG;
    }
}