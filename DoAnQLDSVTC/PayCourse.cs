using System;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PayCourse : Form
    {
        string nienKhoa;
        string hocKy;
        DateTime ngayDong = DateTime.Now;
        int soTienDong = 0;
        DateTime getTimeColumn;
        enum ActionForm
        {
            ADD,
            UPDATE,
            NONE
        }

        ActionForm current = ActionForm.NONE;

        public PayCourse()
        {
            InitializeComponent();
        }
        
        private void PayCourse_Load(object sender, EventArgs e)
        {
            FormatColumnDSHP();
            FormatColumnCTHP();
            GetHocPhi();
        }

        void FormatColumnDSHP()
        {
            dgvHocPhi.Columns["AHOCPHI"].DefaultCellStyle.Format = "N0";
            dgvHocPhi.Columns["TONGTIENDADONG"].DefaultCellStyle.Format = "N0";
            dgvHocPhi.Columns["SOTIENCANDONG"].DefaultCellStyle.Format = "N0";


            dgvHocPhi.Columns["AHOCPHI"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvHocPhi.Columns["TONGTIENDADONG"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvHocPhi.Columns["SOTIENCANDONG"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        void FormatColumnCTHP()
        {
            dgvCTHOCPHI.Columns["BSOTIENDONG"].DefaultCellStyle.Format = "N0";
            dgvCTHOCPHI.Columns["BSOTIENDONG"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetInfoSV();
            GetDSHP();
            LoadSTCD();
        }

        private void GetHocPhi()
        {
            try
            {
                string strLenh = "EXEC SP_TINH_HOCPHI N'" + txtMaSV.Text + "'";
                Program.ExecSqlDataTable(strLenh);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetInfoSV()
        {
            string strLenh = "EXEC SP_LAY_THONGTIN_SV '" + txtMaSV.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            txtTenSV.Text = Program.myReader.GetString(0);
            txtMaLop.Text = Program.myReader.GetString(1);
            Program.myReader.Close();
        }

        void GetDSHP()
        {
            try
            {
                this.SP_DSHOCPHITableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_DSHOCPHITableAdapter.Fill(this.DS1.SP_DSHOCPHI, txtMaSV.Text);
                if (dbsDSHOCPHI.Count > 0)
                {
                    dbsDSHOCPHI.Position = 0;

                    DataRowView drv = (DataRowView)dbsDSHOCPHI.Current;
                    nienKhoa = drv["NIENKHOA"].ToString();
                    hocKy = drv["HOCKY"].ToString();

                    GetCTHP();
                }
                else
                {
                    ResetCTHocPhi();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void ResetCTHocPhi()
        {
            DS1.SP_CTHOCPHI.Clear();
            nienKhoa = null;
            hocKy = null;
        }

        void GetCTHP()
        {
            try
            {
                this.SP_CTHOCPHITableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_CTHOCPHITableAdapter.Fill(this.DS1.SP_CTHOCPHI, txtMaSV.Text, nienKhoa, int.Parse(hocKy));
                btnAddRow.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadSTCD()
        {
            foreach (DataGridViewRow row in dgvHocPhi.Rows)
            {
                double hocphi = TryParse(row.Cells["AHOCPHI"].Value);
                double sotiendadong = TryParse(row.Cells["TONGTIENDADONG"].Value);

                double sotiencandong = hocphi - sotiendadong;

                row.Cells["SOTIENCANDONG"].Value = sotiencandong;
            }
        }

        private void dgvHocPhi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvHocPhi.Rows[e.RowIndex];
            nienKhoa = row.Cells["ANIENKHOA"].Value?.ToString();
            hocKy = row.Cells["AHOCKY"].Value.ToString();
            GetCTHP();
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "") return;
            dbsCTHOCPHI.AddNew();

            var drv = (DataRowView)dbsCTHOCPHI.Current;
            
            string date = ngayDong.ToString("dd/MM/yyyy");
            drv["NGAYDONG"] = date;
            drv["SOTIENDONG"] = 0;

            dgvCTHOCPHI.Columns["BSOTIENDONG"].ReadOnly = false;

            dgvCTHOCPHI.CurrentCell = dgvCTHOCPHI.Rows[dgvCTHOCPHI.CurrentRow.Index].Cells["BSOTIENDONG"];
            dgvCTHOCPHI.BeginEdit(true);

            btnAddRow.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            current = ActionForm.ADD;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dbsCTHOCPHI.Current == null) return;
            dgvCTHOCPHI.Columns["BSOTIENDONG"].ReadOnly = false;
            dgvCTHOCPHI.CurrentCell = dgvCTHOCPHI.Rows[dgvCTHOCPHI.CurrentRow.Index].Cells["BSOTIENDONG"];
            getTimeColumn = Convert.ToDateTime(dgvCTHOCPHI.Rows[dgvCTHOCPHI.CurrentRow.Index].Cells["BNGAYDONG"].Value);
            dgvCTHOCPHI.BeginEdit(true);
            current = ActionForm.UPDATE;
            btnAddRow.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                switch(current)
                {
                    case ActionForm.ADD:
                        InsertCTHOCPHI();
                        break;
                    case ActionForm.UPDATE:
                        UpdateCTHOCPHI();
                        break;
                    default:
                        break;
                }

                GetDSHP();
                GetCTHP();
                LoadSTCD();
                dgvCTHOCPHI.Columns["BSOTIENDONG"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        void InsertCTHOCPHI()
        {
            var drv = (DataRowView)dbsCTHOCPHI.Current;
            string cmd = string.Format(
                "EXEC dbo.SP_INSERT_CTDONGHOCPHI " +
                "@MASV = N'{0}', " +
                "@NIENKHOA = N'{1}', " +
                "@HOCKY = {2}, " +
                "@NGAYDONG = '{3}', " +
                "@SOTIENDONG = {4}",
                txtMaSV.Text,
                nienKhoa,
                int.Parse(hocKy),
                ngayDong.ToString("yyyy-MM-dd"),
                soTienDong
                );
            int result = Program.ExecSqlNonQuery(cmd);
            if(result == 0)
            {
                MessageBox.Show("Đóng học phí '"+ soTienDong.ToString("N0") + "' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        void UpdateCTHOCPHI()
        {
            var drv = (DataRowView)dbsCTHOCPHI.Current;
            string cmd = string.Format(
                "EXEC dbo.SP_UPDATE_CTDONGHOCPHI " +
                "@MASV = N'{0}', " +
                "@NIENKHOA = N'{1}', " +
                "@HOCKY = {2}, " +
                "@NGAYDONG = '{3}', " +
                "@SOTIENDONG = {4}",
                txtMaSV.Text,
                nienKhoa,
                int.Parse(hocKy),
                getTimeColumn.ToString("yyyy-MM-dd"),
                soTienDong
                );
            int result = Program.ExecSqlNonQuery(cmd);
            if (result == 0)
            {
                MessageBox.Show("Cập nhật đóng học phí " + soTienDong.ToString("N0") + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            GetCTHP();
            btnAddRow.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            dgvCTHOCPHI.Columns["BSOTIENDONG"].ReadOnly = true;
        }

        private void dgvCTHOCPHI_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var value = dgvCTHOCPHI.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            soTienDong = TryParse(value);
        }

        private int TryParse(object val)
        {
            int result = 0;
            int.TryParse(Convert.ToString(val), out result);
            return result;
        }
    }
}
