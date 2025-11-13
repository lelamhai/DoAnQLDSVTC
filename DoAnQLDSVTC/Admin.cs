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
            LoadForm(new ClassRoom());
            LoadSayHi();

            splitContainer1.SplitterWidth = 10;
        }

        private void LoadForm(object form)
        {
            if (this.pContent.Controls.Count > 0)
            {
                this.pContent.Controls.RemoveAt(0);
            }
            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pContent.Controls.Add(f);
            this.pContent.Tag = f;
            f.Show();
        }

        private void LoadSayHi()
        {
            if (Program.MLogin != "")
            {
                lbNameLogin.Text = "Xin chào " + Program.MLogin + "!";
                return;
            }

            lbNameLogin.Text = "Xin chào NULL!";
        }

        private void btnClassroom_Click(object sender, EventArgs e)
        {
            LoadForm(new ClassRoom());
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoadForm(new Student());
        }
    }
}
