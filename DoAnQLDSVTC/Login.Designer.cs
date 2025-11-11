namespace DoAnQLDSVTC
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            cmbKhoa = new ComboBox();
            panel1 = new Panel();
            btnLogin = new Button();
            cbStudent = new CheckBox();
            txtPassword = new TextBox();
            txtUserName = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1258, 817);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // cmbKhoa
            // 
            cmbKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbKhoa.FormattingEnabled = true;
            cmbKhoa.Location = new Point(203, 355);
            cmbKhoa.Name = "cmbKhoa";
            cmbKhoa.Size = new Size(175, 23);
            cmbKhoa.TabIndex = 1;
            cmbKhoa.SelectedIndexChanged += cmbKhoa_SelectedIndexChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(cbStudent);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(cmbKhoa);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(789, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(469, 817);
            panel1.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Font = new Font("Times New Roman", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = SystemColors.ButtonHighlight;
            btnLogin.Location = new Point(122, 536);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(249, 47);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Đăng Nhập";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // cbStudent
            // 
            cbStudent.AutoSize = true;
            cbStudent.Font = new Font("Times New Roman", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            cbStudent.Location = new Point(203, 483);
            cbStudent.Name = "cbStudent";
            cbStudent.Size = new Size(88, 23);
            cbStudent.TabIndex = 10;
            cbStudent.Text = "Sinh Viên";
            cbStudent.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(203, 447);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(175, 23);
            txtPassword.TabIndex = 9;
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(203, 400);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(175, 23);
            txtUserName.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 12F);
            label5.Location = new Point(106, 449);
            label5.Name = "label5";
            label5.Size = new Size(71, 19);
            label5.TabIndex = 7;
            label5.Text = "Mật Khẩu";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 12F);
            label4.Location = new Point(106, 402);
            label4.Name = "label4";
            label4.Size = new Size(73, 19);
            label4.TabIndex = 6;
            label4.Text = "Tài Khoản";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 12F);
            label3.Location = new Point(106, 355);
            label3.Name = "label3";
            label3.Size = new Size(43, 19);
            label3.TabIndex = 5;
            label3.Text = "Khoa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold);
            label2.Location = new Point(112, 250);
            label2.Name = "label2";
            label2.Size = new Size(276, 24);
            label2.TabIndex = 4;
            label2.Text = "QUẢN LÝ ĐIỂM SINH VIÊN";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 15.75F, FontStyle.Bold);
            label1.Location = new Point(61, 212);
            label1.Name = "label1";
            label1.Size = new Size(359, 24);
            label1.TabIndex = 3;
            label1.Text = "CHÀO MỪNG BẠN ĐẾN HỆ THỐNG";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(178, 72);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(110, 110);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 817);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Name = "Login";
            Text = "Đăng Nhập";
            WindowState = FormWindowState.Maximized;
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ComboBox cmbKhoa;
        private Panel panel1;
        private PictureBox pictureBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPassword;
        private TextBox txtUserName;
        private Label label5;
        private Button btnLogin;
        private CheckBox cbStudent;
    }
}
