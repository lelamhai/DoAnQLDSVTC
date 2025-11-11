using Microsoft.Data.SqlClient;
using System.Data;

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
            lbNameLogin.Text = "Xin chào " + Program.MLogin + "!";

            splitContainer1.SplitterWidth = 1;
        }
    }
}
