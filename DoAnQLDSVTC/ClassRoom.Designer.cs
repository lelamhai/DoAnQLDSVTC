using System.Drawing;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    partial class ClassRoom
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
            panel1 = new Panel();
            lblLogin = new Label();
            label2 = new Label();
            splitContainer1 = new SplitContainer();
            panel3 = new Panel();
            dgvLop = new DataGridView();
            MALOP = new DataGridViewTextBoxColumn();
            TENLOP = new DataGridViewTextBoxColumn();
            KHOAHOC = new DataGridViewTextBoxColumn();
            MAKHOA = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Update = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            panel2 = new Panel();
            btnUndo = new Button();
            label1 = new Label();
            cmbKhoa = new ComboBox();
            panel13 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnSave = new Button();
            btnClear = new Button();
            panel12 = new Panel();
            panel11 = new Panel();
            label7 = new Label();
            txtMaKhoa = new TextBox();
            panel10 = new Panel();
            panel9 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            textBox6 = new TextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            panel8 = new Panel();
            panel7 = new Panel();
            TxtTenLop = new TextBox();
            label5 = new Label();
            panel6 = new Panel();
            panel5 = new Panel();
            txtMaLop = new TextBox();
            label4 = new Label();
            panel4 = new Panel();
            label3 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            panel2.SuspendLayout();
            panel13.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(lblLogin);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1309, 63);
            panel1.TabIndex = 0;
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.Font = new Font("Times New Roman", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(1195, 18);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(99, 16);
            lblLogin.TabIndex = 1;
            lblLogin.Text = "Xin chào NULL!";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 18);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(137, 22);
            label2.TabIndex = 0;
            label2.Text = "Danh Sách Lớp";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(10, 63);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(panel3);
            splitContainer1.Panel1.Controls.Add(panel2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.Transparent;
            splitContainer1.Panel2.Controls.Add(panel13);
            splitContainer1.Panel2.Controls.Add(panel12);
            splitContainer1.Panel2.Controls.Add(panel11);
            splitContainer1.Panel2.Controls.Add(panel10);
            splitContainer1.Panel2.Controls.Add(panel9);
            splitContainer1.Panel2.Controls.Add(panel8);
            splitContainer1.Panel2.Controls.Add(panel7);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Panel2.Controls.Add(panel5);
            splitContainer1.Panel2.Controls.Add(panel4);
            splitContainer1.Panel2.Padding = new Padding(15, 0, 15, 0);
            splitContainer1.Size = new Size(1309, 781);
            splitContainer1.SplitterDistance = 985;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkRed;
            panel3.Controls.Add(dgvLop);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 71);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(985, 710);
            panel3.TabIndex = 1;
            // 
            // dgvLop
            // 
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.BackgroundColor = Color.White;
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Columns.AddRange(new DataGridViewColumn[] { MALOP, TENLOP, KHOAHOC, MAKHOA, Edit, Update, Delete });
            dgvLop.Dock = DockStyle.Fill;
            dgvLop.Location = new Point(0, 0);
            dgvLop.Margin = new Padding(4);
            dgvLop.Name = "dgvLop";
            dgvLop.Size = new Size(985, 710);
            dgvLop.TabIndex = 0;
            // 
            // MALOP
            // 
            MALOP.DataPropertyName = "MALOP";
            MALOP.HeaderText = "Mã Lớp";
            MALOP.Name = "MALOP";
            // 
            // TENLOP
            // 
            TENLOP.DataPropertyName = "TENLOP";
            TENLOP.HeaderText = "Tên Lớp";
            TENLOP.Name = "TENLOP";
            // 
            // KHOAHOC
            // 
            KHOAHOC.DataPropertyName = "KHOAHOC";
            KHOAHOC.HeaderText = "Khóa Học";
            KHOAHOC.Name = "KHOAHOC";
            // 
            // MAKHOA
            // 
            MAKHOA.DataPropertyName = "MAKHOA";
            MAKHOA.HeaderText = "Mã Khoa";
            MAKHOA.Name = "MAKHOA";
            // 
            // Edit
            // 
            Edit.HeaderText = "";
            Edit.Name = "Edit";
            Edit.Text = "Chỉnh Sửa";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // Update
            // 
            Update.HeaderText = "";
            Update.Name = "Update";
            Update.Text = "Cập Nhật";
            Update.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            Delete.HeaderText = "";
            Delete.Name = "Delete";
            Delete.Text = "Xóa";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.Controls.Add(btnUndo);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(cmbKhoa);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(985, 71);
            panel2.TabIndex = 0;
            // 
            // btnUndo
            // 
            btnUndo.Anchor = AnchorStyles.Right;
            btnUndo.Location = new Point(885, 22);
            btnUndo.Margin = new Padding(4);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(96, 29);
            btnUndo.TabIndex = 2;
            btnUndo.Text = "Phục Hồi";
            btnUndo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 25);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 1;
            label1.Text = "Khoa";
            // 
            // cmbKhoa
            // 
            cmbKhoa.FormattingEnabled = true;
            cmbKhoa.Location = new Point(62, 22);
            cmbKhoa.Margin = new Padding(4);
            cmbKhoa.Name = "cmbKhoa";
            cmbKhoa.Size = new Size(385, 27);
            cmbKhoa.TabIndex = 0;
            // 
            // panel13
            // 
            panel13.Controls.Add(tableLayoutPanel2);
            panel13.Dock = DockStyle.Top;
            panel13.Location = new Point(15, 446);
            panel13.Name = "panel13";
            panel13.Padding = new Padding(50, 0, 50, 0);
            panel13.Size = new Size(289, 50);
            panel13.TabIndex = 24;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnSave, 0, 0);
            tableLayoutPanel2.Controls.Add(btnClear, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(50, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(189, 50);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Top;
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(88, 35);
            btnSave.TabIndex = 2;
            btnSave.Text = "Ghi";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Dock = DockStyle.Top;
            btnClear.Location = new Point(97, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(89, 35);
            btnClear.TabIndex = 1;
            btnClear.Text = "Làm Mới";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // panel12
            // 
            panel12.Dock = DockStyle.Top;
            panel12.Location = new Point(15, 346);
            panel12.Name = "panel12";
            panel12.Size = new Size(289, 100);
            panel12.TabIndex = 23;
            // 
            // panel11
            // 
            panel11.Controls.Add(label7);
            panel11.Controls.Add(txtMaKhoa);
            panel11.Dock = DockStyle.Top;
            panel11.Location = new Point(15, 296);
            panel11.Name = "panel11";
            panel11.Size = new Size(289, 50);
            panel11.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Top;
            label7.Location = new Point(0, 0);
            label7.Name = "label7";
            label7.Size = new Size(68, 19);
            label7.TabIndex = 0;
            label7.Text = "Mã Khoa";
            // 
            // txtMaKhoa
            // 
            txtMaKhoa.Dock = DockStyle.Bottom;
            txtMaKhoa.Enabled = false;
            txtMaKhoa.Location = new Point(0, 24);
            txtMaKhoa.Name = "txtMaKhoa";
            txtMaKhoa.Size = new Size(289, 26);
            txtMaKhoa.TabIndex = 10;
            // 
            // panel10
            // 
            panel10.Dock = DockStyle.Top;
            panel10.Location = new Point(15, 271);
            panel10.Name = "panel10";
            panel10.Size = new Size(289, 25);
            panel10.TabIndex = 21;
            // 
            // panel9
            // 
            panel9.Controls.Add(tableLayoutPanel1);
            panel9.Controls.Add(label6);
            panel9.Dock = DockStyle.Top;
            panel9.Location = new Point(15, 221);
            panel9.Name = "panel9";
            panel9.Size = new Size(289, 50);
            panel9.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Controls.Add(textBox6, 2, 0);
            tableLayoutPanel1.Controls.Add(textBox3, 0, 0);
            tableLayoutPanel1.Controls.Add(textBox1, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(289, 30);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // textBox6
            // 
            textBox6.Dock = DockStyle.Fill;
            textBox6.Location = new Point(89, 3);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(66, 26);
            textBox6.TabIndex = 14;
            // 
            // textBox3
            // 
            textBox3.Dock = DockStyle.Fill;
            textBox3.Location = new Point(3, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(66, 26);
            textBox3.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(175, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(111, 26);
            textBox1.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Top;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(73, 19);
            label6.TabIndex = 5;
            label6.Text = "Khóa Học";
            // 
            // panel8
            // 
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(15, 196);
            panel8.Name = "panel8";
            panel8.Size = new Size(289, 25);
            panel8.TabIndex = 19;
            // 
            // panel7
            // 
            panel7.Controls.Add(TxtTenLop);
            panel7.Controls.Add(label5);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(15, 146);
            panel7.Name = "panel7";
            panel7.Size = new Size(289, 50);
            panel7.TabIndex = 18;
            // 
            // TxtTenLop
            // 
            TxtTenLop.Dock = DockStyle.Bottom;
            TxtTenLop.Location = new Point(0, 24);
            TxtTenLop.Name = "TxtTenLop";
            TxtTenLop.Size = new Size(289, 26);
            TxtTenLop.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Top;
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(61, 19);
            label5.TabIndex = 0;
            label5.Text = "Tên Lớp";
            // 
            // panel6
            // 
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(15, 121);
            panel6.Name = "panel6";
            panel6.Size = new Size(289, 25);
            panel6.TabIndex = 17;
            // 
            // panel5
            // 
            panel5.Controls.Add(txtMaLop);
            panel5.Controls.Add(label4);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(15, 71);
            panel5.Name = "panel5";
            panel5.Size = new Size(289, 50);
            panel5.TabIndex = 16;
            // 
            // txtMaLop
            // 
            txtMaLop.Dock = DockStyle.Bottom;
            txtMaLop.Location = new Point(0, 24);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(289, 26);
            txtMaLop.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 19);
            label4.TabIndex = 17;
            label4.Text = "Mã Lớp";
            // 
            // panel4
            // 
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(15, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(289, 71);
            panel4.TabIndex = 15;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Top;
            label3.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(289, 71);
            label3.TabIndex = 0;
            label3.Text = "Thêm Dữ Liệu";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ClassRoom
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1329, 844);
            Controls.Add(splitContainer1);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "ClassRoom";
            Padding = new Padding(10, 0, 10, 0);
            Text = "ClassRoom";
            WindowState = FormWindowState.Maximized;
            Load += ClassRoom_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel13.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private SplitContainer splitContainer1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvLop;
        private ComboBox cmbKhoa;
        private Label label1;
        private Button btnUndo;
        private Label lblLogin;
        private Label label2;
        private DataGridViewTextBoxColumn MALOP;
        private DataGridViewTextBoxColumn TENLOP;
        private DataGridViewTextBoxColumn KHOAHOC;
        private DataGridViewTextBoxColumn MAKHOA;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
        private Label label3;
        private Label label6;
        private Label label9;
        private TextBox textBox3;
        private Panel panel5;
        private Panel panel4;
        private Label label4;
        private Panel panel6;
        private Panel panel7;
        private TextBox TxtTenLop;
        private Label label5;
        private Panel panel8;
        private Panel panel9;
        private TextBox textBox6;
        private Panel panel11;
        private Panel panel10;
        private Panel panel12;
        private TextBox txtMaLop;
        private Label label7;
        private TextBox txtMaKhoa;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private Panel panel13;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnSave;
        private Button btnClear;
        private DataGridViewButtonColumn Update;
    }
}