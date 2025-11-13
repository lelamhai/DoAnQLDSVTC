using System.Drawing;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnStudent = new System.Windows.Forms.Button();
            this.btnClassroom = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pContent = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbNameLogin = new System.Windows.Forms.Label();
            this.timerSlide = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 706);
            this.splitContainer1.SplitterDistance = 180;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.btnStudent);
            this.panel2.Controls.Add(this.btnClassroom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 161);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 545);
            this.panel2.TabIndex = 2;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Location = new System.Drawing.Point(0, 150);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(180, 30);
            this.button6.TabIndex = 5;
            this.button6.Text = "Tạo Tài Khoản";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(0, 120);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(180, 30);
            this.button5.TabIndex = 4;
            this.button5.Text = "Điểm";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Location = new System.Drawing.Point(0, 90);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "Lớp Tín Chỉ";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 60);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Môn Học";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnStudent
            // 
            this.btnStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStudent.Location = new System.Drawing.Point(0, 30);
            this.btnStudent.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btnStudent.Name = "btnStudent";
            this.btnStudent.Size = new System.Drawing.Size(180, 30);
            this.btnStudent.TabIndex = 1;
            this.btnStudent.Text = "Sinh Viên";
            this.btnStudent.UseVisualStyleBackColor = true;
            this.btnStudent.Click += new System.EventHandler(this.btnStudent_Click);
            // 
            // btnClassroom
            // 
            this.btnClassroom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClassroom.Location = new System.Drawing.Point(0, 0);
            this.btnClassroom.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btnClassroom.Name = "btnClassroom";
            this.btnClassroom.Size = new System.Drawing.Size(180, 30);
            this.btnClassroom.TabIndex = 0;
            this.btnClassroom.Text = "Lớp";
            this.btnClassroom.UseVisualStyleBackColor = true;
            this.btnClassroom.Click += new System.EventHandler(this.btnClassroom_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 161);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 130);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.pContent);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1086, 706);
            this.panel3.TabIndex = 1;
            // 
            // pContent
            // 
            this.pContent.BackColor = System.Drawing.SystemColors.Highlight;
            this.pContent.Controls.Add(this.lblTitle);
            this.pContent.Controls.Add(this.lbNameLogin);
            this.pContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContent.Location = new System.Drawing.Point(0, 0);
            this.pContent.Margin = new System.Windows.Forms.Padding(0);
            this.pContent.Name = "pContent";
            this.pContent.Size = new System.Drawing.Size(1086, 706);
            this.pContent.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(36, 19);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Lớp";
            // 
            // lbNameLogin
            // 
            this.lbNameLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNameLogin.AutoSize = true;
            this.lbNameLogin.BackColor = System.Drawing.Color.Transparent;
            this.lbNameLogin.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbNameLogin.Location = new System.Drawing.Point(990, 12);
            this.lbNameLogin.Name = "lbNameLogin";
            this.lbNameLogin.Size = new System.Drawing.Size(84, 15);
            this.lbNameLogin.TabIndex = 0;
            this.lbNameLogin.Text = "Xin chào Thư!";
            // 
            // btnExit
            // 
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnExit.Location = new System.Drawing.Point(0, 515);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 30);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 180);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Đăng Xuất";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1280, 706);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Admin";
            this.Text = "Trang Quản Trị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Admin_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pContent.ResumeLayout(false);
            this.pContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button btnStudent;
        private Button btnClassroom;
        private Button button6;
        private System.Windows.Forms.Timer timerSlide;
        private Panel panel3;
        private Panel pContent;
        private Label lbNameLogin;
        private Label lblTitle;
        private Button btnExit;
        private Button button1;
    }
}