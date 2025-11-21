using System.Drawing;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    partial class Student
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitleKhoa = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel30 = new System.Windows.Forms.Panel();
            this.pRight = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel29 = new System.Windows.Forms.Panel();
            this.panel28 = new System.Windows.Forms.Panel();
            this.cbNotStudy = new System.Windows.Forms.CheckBox();
            this.FKSINHVIENLOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dbsLOP = new System.Windows.Forms.BindingSource(this.components);
            this.DS = new DoAnQLDSVTC.DS();
            this.label12 = new System.Windows.Forms.Label();
            this.panel27 = new System.Windows.Forms.Panel();
            this.panel26 = new System.Windows.Forms.Panel();
            this.cbFemale = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel25 = new System.Windows.Forms.Panel();
            this.panel24 = new System.Windows.Forms.Panel();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel23 = new System.Windows.Forms.Panel();
            this.panel22 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.panel21 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.txtHo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel32 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTenLop = new System.Windows.Forms.Label();
            this.panel31 = new System.Windows.Forms.Panel();
            this.lblMaLop = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.dgvClassroom = new System.Windows.Forms.DataGridView();
            this.MALOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TENLOP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KHOAHOC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pLeft = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.MASV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYSINH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIACHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PHAI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DANGHIHOC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LOPTableAdapter = new DoAnQLDSVTC.DSTableAdapters.LOPTableAdapter();
            this.SINHVIENTableAdapter = new DoAnQLDSVTC.DSTableAdapters.SINHVIENTableAdapter();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel30.SuspendLayout();
            this.pRight.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel28.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FKSINHVIENLOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsLOP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.panel26.SuspendLayout();
            this.panel24.SuspendLayout();
            this.panel22.SuspendLayout();
            this.panel20.SuspendLayout();
            this.panel18.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel32.SuspendLayout();
            this.panel31.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).BeginInit();
            this.panel9.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.panel10.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblTitleKhoa);
            this.panel1.Controls.Add(this.cmbKhoa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 0, 30, 0);
            this.panel1.Size = new System.Drawing.Size(1215, 60);
            this.panel1.TabIndex = 0;
            // 
            // lblTitleKhoa
            // 
            this.lblTitleKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitleKhoa.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleKhoa.Location = new System.Drawing.Point(960, 20);
            this.lblTitleKhoa.Name = "lblTitleKhoa";
            this.lblTitleKhoa.Size = new System.Drawing.Size(246, 25);
            this.lblTitleKhoa.TabIndex = 3;
            this.lblTitleKhoa.Text = "Khoa Công Nghệ Thông Tin";
            this.lblTitleKhoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(70, 19);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(300, 27);
            this.cmbKhoa.TabIndex = 1;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Khoa";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 60);
            this.panel7.Margin = new System.Windows.Forms.Padding(0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1215, 15);
            this.panel7.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 75);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1215, 692);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(900, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(15, 692);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel30);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(915, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 692);
            this.panel3.TabIndex = 2;
            // 
            // panel30
            // 
            this.panel30.Controls.Add(this.pRight);
            this.panel30.Controls.Add(this.label5);
            this.panel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel30.Location = new System.Drawing.Point(0, 0);
            this.panel30.Margin = new System.Windows.Forms.Padding(0);
            this.panel30.Name = "panel30";
            this.panel30.Size = new System.Drawing.Size(300, 692);
            this.panel30.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.BackColor = System.Drawing.Color.Transparent;
            this.pRight.Controls.Add(this.panel12);
            this.pRight.Controls.Add(this.panel29);
            this.pRight.Controls.Add(this.panel28);
            this.pRight.Controls.Add(this.panel27);
            this.pRight.Controls.Add(this.panel26);
            this.pRight.Controls.Add(this.panel25);
            this.pRight.Controls.Add(this.panel24);
            this.pRight.Controls.Add(this.panel23);
            this.pRight.Controls.Add(this.panel22);
            this.pRight.Controls.Add(this.panel21);
            this.pRight.Controls.Add(this.panel20);
            this.pRight.Controls.Add(this.panel19);
            this.pRight.Controls.Add(this.panel18);
            this.pRight.Controls.Add(this.panel17);
            this.pRight.Controls.Add(this.panel16);
            this.pRight.Controls.Add(this.panel15);
            this.pRight.Controls.Add(this.panel14);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(0, 50);
            this.pRight.Margin = new System.Windows.Forms.Padding(0);
            this.pRight.Name = "pRight";
            this.pRight.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pRight.Size = new System.Drawing.Size(300, 642);
            this.pRight.TabIndex = 5;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.tableLayoutPanel4);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(15, 555);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(270, 40);
            this.panel12.TabIndex = 33;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnCancel, 2, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(270, 40);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Brown;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(0, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 40);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Ghi";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Brown;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(145, 0);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(125, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel29
            // 
            this.panel29.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel29.Location = new System.Drawing.Point(15, 505);
            this.panel29.Name = "panel29";
            this.panel29.Size = new System.Drawing.Size(270, 50);
            this.panel29.TabIndex = 32;
            // 
            // panel28
            // 
            this.panel28.Controls.Add(this.cbNotStudy);
            this.panel28.Controls.Add(this.label12);
            this.panel28.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel28.Location = new System.Drawing.Point(15, 455);
            this.panel28.Name = "panel28";
            this.panel28.Size = new System.Drawing.Size(270, 50);
            this.panel28.TabIndex = 31;
            // 
            // cbNotStudy
            // 
            this.cbNotStudy.AutoSize = true;
            this.cbNotStudy.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.FKSINHVIENLOPBindingSource, "DANGHIHOC", true));
            this.cbNotStudy.Location = new System.Drawing.Point(16, 27);
            this.cbNotStudy.Name = "cbNotStudy";
            this.cbNotStudy.Size = new System.Drawing.Size(109, 23);
            this.cbNotStudy.TabIndex = 2;
            this.cbNotStudy.Text = "Đã Nghỉ Học";
            this.cbNotStudy.UseVisualStyleBackColor = true;
            // 
            // FKSINHVIENLOPBindingSource
            // 
            this.FKSINHVIENLOPBindingSource.DataMember = "FK_SINHVIEN_LOP";
            this.FKSINHVIENLOPBindingSource.DataSource = this.dbsLOP;
            // 
            // dbsLOP
            // 
            this.dbsLOP.DataMember = "LOP";
            this.dbsLOP.DataSource = this.DS;
            // 
            // DS
            // 
            this.DS.DataSetName = "DS";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 19);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tình Trạng Học";
            // 
            // panel27
            // 
            this.panel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel27.Location = new System.Drawing.Point(15, 440);
            this.panel27.Name = "panel27";
            this.panel27.Size = new System.Drawing.Size(270, 15);
            this.panel27.TabIndex = 30;
            // 
            // panel26
            // 
            this.panel26.Controls.Add(this.cbFemale);
            this.panel26.Controls.Add(this.label11);
            this.panel26.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel26.Location = new System.Drawing.Point(15, 390);
            this.panel26.Name = "panel26";
            this.panel26.Size = new System.Drawing.Size(270, 50);
            this.panel26.TabIndex = 29;
            // 
            // cbFemale
            // 
            this.cbFemale.AutoSize = true;
            this.cbFemale.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.FKSINHVIENLOPBindingSource, "PHAI", true));
            this.cbFemale.Location = new System.Drawing.Point(17, 27);
            this.cbFemale.Name = "cbFemale";
            this.cbFemale.Size = new System.Drawing.Size(49, 23);
            this.cbFemale.TabIndex = 1;
            this.cbFemale.Text = "Nữ";
            this.cbFemale.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 19);
            this.label11.TabIndex = 0;
            this.label11.Text = "Giới Tính";
            // 
            // panel25
            // 
            this.panel25.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel25.Location = new System.Drawing.Point(15, 375);
            this.panel25.Name = "panel25";
            this.panel25.Size = new System.Drawing.Size(270, 15);
            this.panel25.TabIndex = 28;
            // 
            // panel24
            // 
            this.panel24.Controls.Add(this.txtDiaChi);
            this.panel24.Controls.Add(this.label10);
            this.panel24.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel24.Location = new System.Drawing.Point(15, 325);
            this.panel24.Name = "panel24";
            this.panel24.Size = new System.Drawing.Size(270, 50);
            this.panel24.TabIndex = 27;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FKSINHVIENLOPBindingSource, "DIACHI", true));
            this.txtDiaChi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtDiaChi.Location = new System.Drawing.Point(0, 24);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(270, 26);
            this.txtDiaChi.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 19);
            this.label10.TabIndex = 0;
            this.label10.Text = "Địa Chỉ";
            // 
            // panel23
            // 
            this.panel23.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel23.Location = new System.Drawing.Point(15, 310);
            this.panel23.Name = "panel23";
            this.panel23.Size = new System.Drawing.Size(270, 15);
            this.panel23.TabIndex = 26;
            // 
            // panel22
            // 
            this.panel22.Controls.Add(this.label9);
            this.panel22.Controls.Add(this.dtpDOB);
            this.panel22.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel22.Location = new System.Drawing.Point(15, 260);
            this.panel22.Name = "panel22";
            this.panel22.Size = new System.Drawing.Size(270, 50);
            this.panel22.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Ngày Sinh";
            // 
            // dtpDOB
            // 
            this.dtpDOB.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FKSINHVIENLOPBindingSource, "NGAYSINH", true));
            this.dtpDOB.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.FKSINHVIENLOPBindingSource, "NGAYSINH", true));
            this.dtpDOB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtpDOB.Location = new System.Drawing.Point(0, 24);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(270, 26);
            this.dtpDOB.TabIndex = 0;
            // 
            // panel21
            // 
            this.panel21.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel21.Location = new System.Drawing.Point(15, 245);
            this.panel21.Name = "panel21";
            this.panel21.Size = new System.Drawing.Size(270, 15);
            this.panel21.TabIndex = 24;
            // 
            // panel20
            // 
            this.panel20.Controls.Add(this.txtTen);
            this.panel20.Controls.Add(this.label8);
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(15, 195);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(270, 50);
            this.panel20.TabIndex = 23;
            // 
            // txtTen
            // 
            this.txtTen.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FKSINHVIENLOPBindingSource, "TEN", true));
            this.txtTen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtTen.Location = new System.Drawing.Point(0, 24);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(270, 26);
            this.txtTen.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Tên";
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel19.Location = new System.Drawing.Point(15, 180);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(270, 15);
            this.panel19.TabIndex = 22;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.txtHo);
            this.panel18.Controls.Add(this.label7);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel18.Location = new System.Drawing.Point(15, 130);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(270, 50);
            this.panel18.TabIndex = 21;
            // 
            // txtHo
            // 
            this.txtHo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FKSINHVIENLOPBindingSource, "HO", true));
            this.txtHo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtHo.Location = new System.Drawing.Point(0, 24);
            this.txtHo.Name = "txtHo";
            this.txtHo.Size = new System.Drawing.Size(270, 26);
            this.txtHo.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Họ";
            // 
            // panel17
            // 
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(15, 115);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(270, 15);
            this.panel17.TabIndex = 20;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.txtMaSV);
            this.panel16.Controls.Add(this.label6);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(15, 65);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(270, 50);
            this.panel16.TabIndex = 19;
            // 
            // txtMaSV
            // 
            this.txtMaSV.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.FKSINHVIENLOPBindingSource, "MASV", true));
            this.txtMaSV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtMaSV.Location = new System.Drawing.Point(0, 24);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(270, 26);
            this.txtMaSV.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã Sinh Viên";
            // 
            // panel15
            // 
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(15, 50);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(270, 15);
            this.panel15.TabIndex = 18;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel32);
            this.panel14.Controls.Add(this.panel31);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel14.Location = new System.Drawing.Point(15, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(270, 50);
            this.panel14.TabIndex = 17;
            // 
            // panel32
            // 
            this.panel32.Controls.Add(this.label13);
            this.panel32.Controls.Add(this.lblTenLop);
            this.panel32.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel32.Location = new System.Drawing.Point(0, 25);
            this.panel32.Name = "panel32";
            this.panel32.Size = new System.Drawing.Size(270, 25);
            this.panel32.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 4);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 19);
            this.label13.TabIndex = 5;
            this.label13.Text = "Tên Lớp:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenLop
            // 
            this.lblTenLop.AutoSize = true;
            this.lblTenLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsLOP, "TENLOP", true));
            this.lblTenLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenLop.Location = new System.Drawing.Point(74, 4);
            this.lblTenLop.Name = "lblTenLop";
            this.lblTenLop.Size = new System.Drawing.Size(63, 19);
            this.lblTenLop.TabIndex = 0;
            this.lblTenLop.Text = "Tên Lớp";
            this.lblTenLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel31
            // 
            this.panel31.Controls.Add(this.lblMaLop);
            this.panel31.Controls.Add(this.label3);
            this.panel31.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel31.Location = new System.Drawing.Point(0, 0);
            this.panel31.Name = "panel31";
            this.panel31.Size = new System.Drawing.Size(270, 25);
            this.panel31.TabIndex = 2;
            // 
            // lblMaLop
            // 
            this.lblMaLop.AutoSize = true;
            this.lblMaLop.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dbsLOP, "MALOP", true));
            this.lblMaLop.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaLop.Location = new System.Drawing.Point(75, 4);
            this.lblMaLop.Name = "lblMaLop";
            this.lblMaLop.Size = new System.Drawing.Size(60, 19);
            this.lblMaLop.TabIndex = 1;
            this.lblMaLop.Text = "Mã Lớp";
            this.lblMaLop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Lớp:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(300, 50);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thông Tin Sinh Viên";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tableLayoutPanel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(900, 692);
            this.panel4.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel9, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(900, 692);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(900, 270);
            this.panel5.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.Controls.Add(this.panel13);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panel8.Size = new System.Drawing.Size(900, 270);
            this.panel8.TabIndex = 1;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.Transparent;
            this.panel13.Controls.Add(this.dgvClassroom);
            this.panel13.Controls.Add(this.label2);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel13.Location = new System.Drawing.Point(15, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(870, 270);
            this.panel13.TabIndex = 0;
            // 
            // dgvClassroom
            // 
            this.dgvClassroom.AllowUserToAddRows = false;
            this.dgvClassroom.AutoGenerateColumns = false;
            this.dgvClassroom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClassroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassroom.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MALOP,
            this.TENLOP,
            this.KHOAHOC});
            this.dgvClassroom.DataSource = this.dbsLOP;
            this.dgvClassroom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvClassroom.Location = new System.Drawing.Point(0, 50);
            this.dgvClassroom.Name = "dgvClassroom";
            this.dgvClassroom.Size = new System.Drawing.Size(870, 220);
            this.dgvClassroom.TabIndex = 5;
            // 
            // MALOP
            // 
            this.MALOP.DataPropertyName = "MALOP";
            this.MALOP.HeaderText = "Mã Lớp";
            this.MALOP.Name = "MALOP";
            // 
            // TENLOP
            // 
            this.TENLOP.DataPropertyName = "TENLOP";
            this.TENLOP.HeaderText = "Tên Lớp";
            this.TENLOP.Name = "TENLOP";
            // 
            // KHOAHOC
            // 
            this.KHOAHOC.DataPropertyName = "KHOAHOC";
            this.KHOAHOC.HeaderText = "Khóa Học";
            this.KHOAHOC.Name = "KHOAHOC";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(870, 50);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh Sách Lớp";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 270);
            this.panel6.Margin = new System.Windows.Forms.Padding(0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(900, 15);
            this.panel6.TabIndex = 1;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.pLeft);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 285);
            this.panel9.Margin = new System.Windows.Forms.Padding(0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(900, 407);
            this.panel9.TabIndex = 2;
            // 
            // pLeft
            // 
            this.pLeft.Controls.Add(this.panel11);
            this.pLeft.Controls.Add(this.panel10);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft.Location = new System.Drawing.Point(0, 50);
            this.pLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pLeft.Name = "pLeft";
            this.pLeft.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.pLeft.Size = new System.Drawing.Size(900, 357);
            this.pLeft.TabIndex = 5;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.dgvStudent);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel11.Location = new System.Drawing.Point(15, 30);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(870, 327);
            this.panel11.TabIndex = 1;
            // 
            // dgvStudent
            // 
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AutoGenerateColumns = false;
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MASV,
            this.HO,
            this.TEN,
            this.NGAYSINH,
            this.DIACHI,
            this.PHAI,
            this.DANGHIHOC});
            this.dgvStudent.DataSource = this.FKSINHVIENLOPBindingSource;
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(0, 0);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.Size = new System.Drawing.Size(870, 327);
            this.dgvStudent.TabIndex = 0;
            // 
            // MASV
            // 
            this.MASV.DataPropertyName = "MASV";
            this.MASV.HeaderText = "Mã SV";
            this.MASV.Name = "MASV";
            // 
            // HO
            // 
            this.HO.DataPropertyName = "HO";
            this.HO.HeaderText = "Họ";
            this.HO.Name = "HO";
            // 
            // TEN
            // 
            this.TEN.DataPropertyName = "TEN";
            this.TEN.HeaderText = "Tên";
            this.TEN.Name = "TEN";
            // 
            // NGAYSINH
            // 
            this.NGAYSINH.DataPropertyName = "NGAYSINH";
            this.NGAYSINH.HeaderText = "Ngày Sinh";
            this.NGAYSINH.Name = "NGAYSINH";
            // 
            // DIACHI
            // 
            this.DIACHI.DataPropertyName = "DIACHI";
            this.DIACHI.HeaderText = "Địa Chỉ";
            this.DIACHI.Name = "DIACHI";
            // 
            // PHAI
            // 
            this.PHAI.DataPropertyName = "PHAI";
            this.PHAI.HeaderText = "Phái";
            this.PHAI.Name = "PHAI";
            // 
            // DANGHIHOC
            // 
            this.DANGHIHOC.DataPropertyName = "DANGHIHOC";
            this.DANGHIHOC.HeaderText = "Đã Nghỉ Học";
            this.DANGHIHOC.Name = "DANGHIHOC";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.tableLayoutPanel3);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(15, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(870, 30);
            this.panel10.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 492F));
            this.tableLayoutPanel3.Controls.Add(this.btnUndo, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnRefresh, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnDelete, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEdit, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAdd, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(870, 30);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnUndo.FlatAppearance.BorderSize = 0;
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.Location = new System.Drawing.Point(328, 3);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(94, 24);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "Phục Hồi";
            this.btnUndo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUndo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(228, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(94, 24);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Làm Mới";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(153, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 24);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(78, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 24);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(3, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 24);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(900, 50);
            this.label4.TabIndex = 3;
            this.label4.Text = "Danh Sách Sinh Viên";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LOPTableAdapter
            // 
            this.LOPTableAdapter.ClearBeforeFill = true;
            // 
            // SINHVIENTableAdapter
            // 
            this.SINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1215, 767);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Student";
            this.Text = "Student";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Student_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel30.ResumeLayout(false);
            this.pRight.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel28.ResumeLayout(false);
            this.panel28.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FKSINHVIENLOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbsLOP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.panel26.ResumeLayout(false);
            this.panel26.PerformLayout();
            this.panel24.ResumeLayout(false);
            this.panel24.PerformLayout();
            this.panel22.ResumeLayout(false);
            this.panel22.PerformLayout();
            this.panel20.ResumeLayout(false);
            this.panel20.PerformLayout();
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel32.ResumeLayout(false);
            this.panel32.PerformLayout();
            this.panel31.ResumeLayout(false);
            this.panel31.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassroom)).EndInit();
            this.panel9.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.panel10.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private ComboBox cmbKhoa;
        private Label label1;
        private Panel panel7;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel5;
        private Panel panel8;
        private Panel panel6;
        private Panel panel9;
        private Label label4;
        private Panel panel30;
        private Label label5;
        private Panel pRight;
        private Panel pLeft;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnUndo;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Panel panel10;
        private Panel panel11;
        private DataGridView dgvStudent;
        private Panel panel12;
        private TableLayoutPanel tableLayoutPanel4;
        private Button btnSave;
        private Button btnCancel;
        private Panel panel29;
        private Panel panel28;
        private Label label12;
        private Panel panel27;
        private Panel panel26;
        private Label label11;
        private Panel panel25;
        private Panel panel24;
        private TextBox txtDiaChi;
        private Label label10;
        private Panel panel23;
        private Panel panel22;
        private Label label9;
        private DateTimePicker dtpDOB;
        private Panel panel21;
        private Panel panel20;
        private TextBox txtTen;
        private Label label8;
        private Panel panel19;
        private Panel panel18;
        private TextBox txtHo;
        private Label label7;
        private Panel panel17;
        private Panel panel16;
        private TextBox txtMaSV;
        private Label label6;
        private Panel panel15;
        private Panel panel14;
        private Label lblMaLop;
        private Label lblTenLop;
        private Panel panel13;
        private DataGridView dgvClassroom;
        private Label label2;
        private DS DS;
        private BindingSource dbsLOP;
        private DSTableAdapters.LOPTableAdapter LOPTableAdapter;
        private BindingSource FKSINHVIENLOPBindingSource;
        private DSTableAdapters.SINHVIENTableAdapter SINHVIENTableAdapter;
        private DataGridViewTextBoxColumn MALOP;
        private DataGridViewTextBoxColumn TENLOP;
        private DataGridViewTextBoxColumn KHOAHOC;
        private Label lblTitleKhoa;
        private Panel panel32;
        private Panel panel31;
        private Label label3;
        private Label label13;
        private CheckBox cbNotStudy;
        private CheckBox cbFemale;
        private DataGridViewTextBoxColumn MASV;
        private DataGridViewTextBoxColumn HO;
        private DataGridViewTextBoxColumn TEN;
        private DataGridViewTextBoxColumn NGAYSINH;
        private DataGridViewTextBoxColumn DIACHI;
        private DataGridViewCheckBoxColumn PHAI;
        private DataGridViewCheckBoxColumn DANGHIHOC;
    }
}