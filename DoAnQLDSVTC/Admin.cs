using System;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            LoadForm(new NewClassroom());
        }

        private void LoadForm(object form)
        {
            if (this.pMain.Controls.Count > 0)
            {
                this.pMain.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pMain.Controls.Add(f);
            this.pMain.Tag = f;
            f.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new Student());
        }

        private void btnLop_Click(object sender, EventArgs e)
        {
            LoadForm(new NewClassroom());
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            LoadForm(new CreateAccount());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();       // mở Form2
            this.Hide();     // ẩn Form1
        }
    }
}
