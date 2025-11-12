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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            splitContainer1 = new SplitContainer();
            panel2 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            btnStudent = new Button();
            btnClassroom = new Button();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            pContent = new Panel();
            lbNameLogin = new Label();
            timerSlide = new System.Windows.Forms.Timer(components);
            lblTitle = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            pContent.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.BackColor = SystemColors.Control;
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Margin = new Padding(10);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = SystemColors.HotTrack;
            splitContainer1.Panel1.Controls.Add(panel2);
            splitContainer1.Panel1.Controls.Add(panel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = SystemColors.Control;
            splitContainer1.Panel2.Controls.Add(panel3);
            splitContainer1.Panel2.Padding = new Padding(10, 0, 0, 0);
            splitContainer1.Size = new Size(1280, 706);
            splitContainer1.SplitterDistance = 180;
            splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(btnStudent);
            panel2.Controls.Add(btnClassroom);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 161);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 545);
            panel2.TabIndex = 2;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Top;
            button6.Location = new Point(0, 150);
            button6.Margin = new Padding(3, 50, 3, 3);
            button6.Name = "button6";
            button6.Size = new Size(180, 30);
            button6.TabIndex = 5;
            button6.Text = "Tạo Tài Khoản";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Top;
            button5.Location = new Point(0, 120);
            button5.Margin = new Padding(3, 50, 3, 3);
            button5.Name = "button5";
            button5.Size = new Size(180, 30);
            button5.TabIndex = 4;
            button5.Text = "Điểm";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Top;
            button4.Location = new Point(0, 90);
            button4.Margin = new Padding(3, 50, 3, 3);
            button4.Name = "button4";
            button4.Size = new Size(180, 30);
            button4.TabIndex = 3;
            button4.Text = "Lớp Tín Chỉ";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Top;
            button3.Location = new Point(0, 60);
            button3.Margin = new Padding(3, 50, 3, 3);
            button3.Name = "button3";
            button3.Size = new Size(180, 30);
            button3.TabIndex = 2;
            button3.Text = "Môn Học";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnStudent
            // 
            btnStudent.Dock = DockStyle.Top;
            btnStudent.Location = new Point(0, 30);
            btnStudent.Margin = new Padding(3, 50, 3, 3);
            btnStudent.Name = "btnStudent";
            btnStudent.Size = new Size(180, 30);
            btnStudent.TabIndex = 1;
            btnStudent.Text = "Sinh Viên";
            btnStudent.UseVisualStyleBackColor = true;
            btnStudent.Click += btnStudent_Click;
            // 
            // btnClassroom
            // 
            btnClassroom.Dock = DockStyle.Top;
            btnClassroom.Location = new Point(0, 0);
            btnClassroom.Margin = new Padding(3, 50, 3, 3);
            btnClassroom.Name = "btnClassroom";
            btnClassroom.Size = new Size(180, 30);
            btnClassroom.TabIndex = 0;
            btnClassroom.Text = "Lớp";
            btnClassroom.UseVisualStyleBackColor = true;
            btnClassroom.Click += btnClassroom_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 161);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(24, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(130, 130);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Controls.Add(pContent);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(10, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1086, 706);
            panel3.TabIndex = 1;
            // 
            // pContent
            // 
            pContent.BackColor = SystemColors.Highlight;
            pContent.Controls.Add(lblTitle);
            pContent.Controls.Add(lbNameLogin);
            pContent.Dock = DockStyle.Fill;
            pContent.Location = new Point(0, 0);
            pContent.Margin = new Padding(0);
            pContent.Name = "pContent";
            pContent.Size = new Size(1086, 706);
            pContent.TabIndex = 2;
            // 
            // lbNameLogin
            // 
            lbNameLogin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lbNameLogin.AutoSize = true;
            lbNameLogin.BackColor = Color.Transparent;
            lbNameLogin.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbNameLogin.ForeColor = SystemColors.ControlText;
            lbNameLogin.Location = new Point(990, 12);
            lbNameLogin.Name = "lbNameLogin";
            lbNameLogin.Size = new Size(84, 15);
            lbNameLogin.TabIndex = 0;
            lbNameLogin.Text = "Xin chào Thư!";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(13, 21);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(36, 19);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Lớp";
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.HotTrack;
            ClientSize = new Size(1280, 706);
            Controls.Add(splitContainer1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "Admin";
            Text = "Trang Quản Trị";
            WindowState = FormWindowState.Maximized;
            Load += Admin_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            pContent.ResumeLayout(false);
            pContent.PerformLayout();
            ResumeLayout(false);
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
    }
}