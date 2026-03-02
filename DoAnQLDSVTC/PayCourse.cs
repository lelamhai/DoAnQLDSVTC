using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class PayCourse : Form
    {
        const int min_price = 1000;
        string nienKhoa;
        string hocKy;
        DateTime ngayDong = DateTime.Now;
        DateTime getTimeColumn;
        int soTienNhapVao = 0;

        int soTienDaDong = 0;
        int soTienConLai = 0;
        int hocPhi = 0;
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
            if(txtTenSV.Text == "")
            {
                RestetDSHocPhi();
                ResetCTHocPhi();
                btnAddRow.Enabled = false;
                btnEdit.Enabled = false;
                return;
            }
            GetHocPhi();
            GetDSHP();
            LoadSTCD();
        }

        void GetInfoSV()
        {
            string strLenh = "EXEC SP_LAYTHONGTINSV_HOCPHI N'" + txtMaSV.Text + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null)
            {
                txtMaLop.Text = "";
                txtTenSV.Text = "";
                return;
            } 
            Program.myReader.Read();
            txtTenSV.Text = Program.myReader.GetString(0);
            txtMaLop.Text = Program.myReader.GetString(1);
            Program.myReader.Close();
        }

        private void GetHocPhi()
        {
            try
            {
                string strLenh = "EXEC SP_TINH_HOCPHI N'" + txtMaSV.Text + "'";
                int result = Program.ExecSqlNonQuery(strLenh);
                if (result != 0)
                {
                    MessageBox.Show("Tính học phí thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void GetDSHP()
        {
            try
            {
                this.SP_LAYDS_HOCPHITableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_LAYDS_HOCPHITableAdapter.Fill(this.DS1.SP_LAYDS_HOCPHI, txtMaSV.Text);
                if (dbsDSHOCPHI.Count > 0)
                {
                    DataRowView drv = (DataRowView)dbsDSHOCPHI.Current;
                    nienKhoa = drv["NIENKHOA"].ToString();
                    hocKy = drv["HOCKY"].ToString();
                    btnAddRow.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void RestetDSHocPhi()
        {
            DS1.SP_LAYDS_HOCPHI.Clear();
        }

        void ResetCTHocPhi()
        {
            DS1.SP_LAYDS_CTDONGHOCPHI.Clear();
            nienKhoa = null;
            hocKy = null;
        }

        void GetCTHP()
        {
            try
            {
                this.SP_LAYDS_CTDONGHOCPHITableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_LAYDS_CTDONGHOCPHITableAdapter.Fill(this.DS1.SP_LAYDS_CTDONGHOCPHI, txtMaSV.Text, nienKhoa, int.Parse(hocKy));
                btnAddRow.Enabled = true;
                btnEdit.Enabled = true;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnEdit.Enabled = false;
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

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text == "") return;
            current = ActionForm.ADD;
            CalculateSTCD();
            if (soTienConLai == 0)
            {
                MessageBox.Show("Sinh viên đã đóng đủ học phí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dbsCTHOCPHI.AddNew();

            var drv = (DataRowView)dbsCTHOCPHI.Current;
            string date = ngayDong.ToString("dd/MM/yyyy");
            drv["NGAYDONG"] = date;
            drv["SOTIENDONG"] = 0;

            int rowIndex = dgvCTHOCPHI.CurrentRow.Index;
            dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].ReadOnly = false;
            dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].Style.BackColor = Color.LightGreen;
            dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].Value = soTienConLai;
            dgvCTHOCPHI.CurrentCell = dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"];
            dgvCTHOCPHI.BeginEdit(true);


            btnAddRow.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dbsCTHOCPHI.Current == null) return;
            current = ActionForm.UPDATE;
            CalculateSTCD();

            if (soTienConLai == 0)
            {
                DialogResult result = MessageBox.Show(
                   "Sinh viên đã đóng đủ học phí.\nBạn có muốn chỉnh sửa lại học phí không?",
                   "Thông báo",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Warning
                );

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            int rowIndex = dgvCTHOCPHI.CurrentRow.Index;

            dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].ReadOnly = false;
            dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].Style.BackColor = Color.LightGreen;
            soTienDaDong = TryParse(dgvCTHOCPHI.Rows[dgvCTHOCPHI.CurrentRow.Index].Cells["BSOTIENDONG"].Value);
            getTimeColumn = Convert.ToDateTime(dgvCTHOCPHI.Rows[dgvCTHOCPHI.CurrentRow.Index].Cells["BNGAYDONG"].Value);

            dgvCTHOCPHI.CurrentCell = dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"];
            dgvCTHOCPHI.BeginEdit(true);

            var value = dgvCTHOCPHI.Rows[rowIndex].Cells["BSOTIENDONG"].Value;
            soTienNhapVao = TryParse(value);


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
                        if (soTienNhapVao < min_price)
                        {
                            MessageBox.Show("Số tiền nhập vào phải lớn hơn " + min_price.ToString("N0") + " VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        
                        if (hocPhi-soTienNhapVao < 0)
                        {
                            MessageBox.Show("Số tiền nhập vào vượt quá số tiền cần đóng. Hệ thống sẽ tự động điều chỉnh thành số tiền học phí là '" + hocPhi.ToString("N0") + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            soTienNhapVao = hocPhi;
                        }
                        InsertCTHOCPHI();
                        break;
                    case ActionForm.UPDATE:
                        if (soTienNhapVao < min_price)
                        {
                            MessageBox.Show("Số tiền nhập vào phải lớn hơn " + min_price.ToString("N0") + " VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (soTienDaDong + soTienConLai < soTienNhapVao)
                        {
                            soTienNhapVao = soTienDaDong + soTienConLai;
                            MessageBox.Show("Số tiền nhập vào vượt quá số tiền cần đóng. Hệ thống sẽ tự động điều chỉnh thành số tiền '" + soTienNhapVao.ToString("N0") + "'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
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
                "EXEC dbo.SP_TAO_CTDONGHOCPHI " +
                "@MASV = N'{0}', " +
                "@NIENKHOA = N'{1}', " +
                "@HOCKY = {2}, " +
                "@NGAYDONG = '{3}', " +
                "@SOTIENDONG = {4}",
                txtMaSV.Text,
                nienKhoa,
                int.Parse(hocKy),
                ngayDong.ToString("yyyy-MM-dd"),
                soTienNhapVao
                );
            int result = Program.ExecSqlNonQuery(cmd);
            if(result == 0)
            {
                MessageBox.Show("Đóng học phí '"+ soTienNhapVao.ToString("N0") + "' thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        void UpdateCTHOCPHI()
        {
            var drv = (DataRowView)dbsCTHOCPHI.Current;
            string cmd = string.Format(
                "EXEC dbo.SP_CAPNHAT_CTDONGHOCPHI " +
                "@MASV = N'{0}', " +
                "@NIENKHOA = N'{1}', " +
                "@HOCKY = {2}, " +
                "@NGAYDONG = '{3}', " +
                "@SOTIENDONG = {4}",
                txtMaSV.Text,
                nienKhoa,
                int.Parse(hocKy),
                getTimeColumn.ToString("yyyy-MM-dd"),
                soTienNhapVao
                );
            int result = Program.ExecSqlNonQuery(cmd);
            if (result == 0)
            {
                MessageBox.Show("Cập nhật đóng học phí " + soTienNhapVao.ToString("N0") + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void CalculateSTCD()
        {
            string cmd = "EXEC dbo.SP_HOCPHICONLAI_HOCPHI N'"+txtMaSV.Text.Trim()+"', N'"+nienKhoa+"', "+hocKy+"";
            Program.myReader = Program.ExecSqlDataReader(cmd);
            if (Program.myReader == null) return;

            Program.myReader.Read();
            soTienConLai = Program.myReader.GetInt32(0);
            hocPhi = Program.myReader.GetInt32(1);

            Program.myReader.Close();
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
            soTienNhapVao = TryParse(value);
        }

        private void dgvCTHOCPHI_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvCTHOCPHI.Columns[e.ColumnIndex].Name == "BSOTIENDONG")
            {
                MessageBox.Show("Bạn phải nhập vào một số tiền nguyên dương để hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvCTHOCPHI.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
            }
        }
        private int TryParse(object val)
        {
            int result = 0;
            int.TryParse(Convert.ToString(val), out result);
            return result;
        }

        private void dgvHocPhi_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvHocPhi.Rows[e.RowIndex];
            nienKhoa = row.Cells["ANIENKHOA"].Value?.ToString();
            hocKy = row.Cells["AHOCKY"].Value.ToString();
            GetCTHP();
        }
    }
}
