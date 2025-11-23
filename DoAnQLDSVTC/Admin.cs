using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Admin : Form
    {
        public List<Button> listButton = new List<Button>();

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
            if(listButton.Count > 0)
            {
                foreach (Button btn in listButton)
                {
                    if (btn.Tag.GetType() == form.GetType())
                    {
                        return;
                    }
                }
            }
            Form currentForm = form as Form;
            currentForm.TopLevel = false;
            currentForm.Dock = DockStyle.Fill;
            this.pMain.Controls.Add(currentForm);
            this.pMain.Tag = currentForm;
            currentForm.Show();
            currentForm.BringToFront();
            CreateButton(currentForm);
        }

        void CreateButton(Form form)
        {
            Button button = new Button();
            button.Text = form.Text;
            button.Tag = form;
            button.Dock = DockStyle.Left;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Click += TabButton_Click;
            pTabBar.Controls.Add(button);
            button.BringToFront();
            listButton.Add(button);
        }

        private void TabButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn == null) return;

            Form f = btn.Tag as Form;
            if (f == null) return;

            pMain.Controls.Clear();

            if (!pMain.Controls.Contains(f))
            {
                f.TopLevel = false;
                f.FormBorderStyle = FormBorderStyle.None;
                f.Dock = DockStyle.Fill;
                pMain.Controls.Add(f);
            }

            f.Show();
            f.BringToFront();
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

        public void DeleteButtonInTabBar(Form form)
        {
            for (int i = 0; i < listButton.Count; i++)
            {
                if (listButton[i].Tag == form)
                {
                    pTabBar.Controls.Remove(listButton[i]);
                    listButton.RemoveAt(i);
                    form.Close();
                    break;
                }
            }

            if (listButton.Count > 0)
            {
                Form f = (Form)listButton[0].Tag;

                pMain.Controls.Clear();

                if (!pMain.Controls.Contains(f))
                {
                    f.TopLevel = false;
                    f.FormBorderStyle = FormBorderStyle.None;
                    f.Dock = DockStyle.Fill;
                    pMain.Controls.Add(f);
                }

                f.Show();
                f.BringToFront();
            }
        }
    }
}
