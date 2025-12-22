using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class InputPoint : Form
    {
        private int currentKhoa;
        private bool isSaved = false;
        private float oldValue = 0f;
        private int lastRowIndex;
        private int lastColumnIndex;
        public InputPoint()
        {
            InitializeComponent();
        }

        private void InputPoint_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter_MonHoc();
            LoadCombox();
            SetupBeigin();
            SetupEnd();
            LoadNienKhoa();
        }

        private void LoadDatasetApdapter()
        {
            try
            {
                this.DS.EnforceConstraints = false;
                this.SP_LAYDS_NHAPDIEMTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.SP_LAYDS_NHAPDIEMTableAdapter.Fill(this.DS.SP_LAYDS_NHAPDIEM, txtNienKhoa.Text.Trim(), (int)nudHocKy.Value, cmbMonHoc.SelectedValue.ToString(), (int)nudNhom.Value);

                if (this.DS.SP_LAYDS_NHAPDIEM.Rows.Count == 0)
                {
                    MessageBox.Show("Chưa có dữ liệu để nhập điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDatasetApdapter_MonHoc()
        {
            try
            {
                this.DS.EnforceConstraints = false;
                this.MONHOCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
                this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadCombox()
        {
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";
            string quyen = Program.mGroup;
            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void SetupBeigin()
        {
            dtpBeigin.Format = DateTimePickerFormat.Custom;
            dtpBeigin.CustomFormat = "yyyy";
            dtpBeigin.ShowUpDown = true;
            dtpBeigin.Value = new DateTime(dtpBeigin.Value.Year, 1, 1);
        }
        private void SetupEnd()
        {
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "yyyy";
            dtpEnd.ShowUpDown = true;
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
        }

        private void LoadNienKhoa()
        {
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Visible || this.IsDisposed) return;
            int newIndex = cmbKhoa.SelectedIndex;

            if (newIndex < 0) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            currentKhoa = cmbKhoa.SelectedIndex;

            lblTitleKhoa.Text = cmbKhoa.Text;
            Program.ServerName = cmbKhoa.SelectedValue.ToString();
            if (currentKhoa != Program.MKhoa)
            {
                Program.MLogin = Program.remoteLogin;
                Program.MPass = Program.remotePass;
            }
            else
            {
                Program.MLogin = Program.MLoginDN;
                Program.MPass = Program.MPassDN;
            }

            if (Program.KetNoi() == 1)
            {
            }

            lblTitleKhoa.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadDiemHM();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Admin parent = this.TopLevelControl as Admin;
            parent.CloseForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!isSaved)
            {
                return;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("MALTC", typeof(int));
            dt.Columns.Add("MASV", typeof(string));
            dt.Columns.Add("DIEM_CC", typeof(int));
            dt.Columns.Add("DIEM_GK", typeof(decimal));
            dt.Columns.Add("DIEM_CK", typeof(decimal));

            foreach (DataGridViewRow gvRow in dgvDK.Rows)
            {
                if (gvRow.IsNewRow) continue;
                DataRow newRow = dt.NewRow();
                newRow["MALTC"] = gvRow.Cells["MALTC"].Value;
                newRow["MASV"] = gvRow.Cells["MASV"].Value;

                if(gvRow.Cells["DIEM_CC"].Value == DBNull.Value)
                {
                    gvRow.Cells["DIEM_CC"].Value = null;
                }
                else
                {
                    newRow["DIEM_CC"] = gvRow.Cells["DIEM_CC"].Value;
                }



                if (gvRow.Cells["DIEM_GK"].Value == DBNull.Value)
                {
                    gvRow.Cells["DIEM_GK"].Value = null;
                } else
                                    {
                    decimal diemGK = Convert.ToDecimal(gvRow.Cells["DIEM_GK"].Value);
                    newRow["DIEM_GK"] = Math.Round(diemGK, 2);
                }


                if (gvRow.Cells["DIEM_CK"].Value == DBNull.Value)
                {
                    gvRow.Cells["DIEM_CK"].Value = null;
                }
                else
                {
                    decimal diemGK = Convert.ToDecimal(gvRow.Cells["DIEM_CK"].Value);
                    newRow["DIEM_CK"] = Math.Round(diemGK, 2);
                }
              
                dt.Rows.Add(newRow);
            }

            SqlParameter para = new SqlParameter();
            para.SqlDbType = SqlDbType.Structured;
            para.TypeName = "dbo.TYPE_DANGKY";
            para.ParameterName = "@DIEMTHI";
            para.Value = dt;
            Program.KetNoi();

            SqlCommand cmd = new SqlCommand("SP_CAPNHAT_NHAPDIEM", Program.Conn);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(para);
            try
            {
                cmd.ExecuteNonQuery();
                LoadDatasetApdapter();
                LoadDiemHM();
                MessageBox.Show("Lưu điểm thành công.", "Thông báo", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK);
                return;
            }
        }

        private void dgvDK_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var value = dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

            if (value == null || value == DBNull.Value)
            {
                return;
            }

            if (!float.TryParse(Convert.ToString(value), out oldValue))
            {
                oldValue = 0;
            }
        }

        private void dgvDK_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var value = dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            double valueCell = TryParse(value);

            if (valueCell < 0 || valueCell > 10)
            {
                isSaved = false;
                return;
            }
            isSaved = true;
        }

        private void dgvDK_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var value = dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            double valueCell = TryParse(value);
            if (valueCell < 0 || valueCell > 10)
            {
                MessageBox.Show("Điểm vừa nhập không hợp lệ, điểm từ 0 đến 10", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
            }

            var row = dgvDK.Rows[e.RowIndex];
            double cc = TryParse(row.Cells["DIEM_CC"].Value);
            double gk = TryParse(row.Cells["DIEM_GK"].Value);
            double ck = TryParse(row.Cells["DIEM_CK"].Value);

            double hm = cc * 0.1 + gk * 0.3 + ck * 0.6;

            row.Cells["DIEM_HM"].Value = Math.Round(hm, 2);
        }

        private void LoadDiemHM()
        {
            foreach (DataGridViewRow row in dgvDK.Rows)
            {
                double cc = TryParse(row.Cells["DIEM_CC"].Value);
                double gk = TryParse(row.Cells["DIEM_GK"].Value);
                double ck = TryParse(row.Cells["DIEM_CK"].Value);

                double hm = cc * 0.1 + gk * 0.3 + ck * 0.6;

                row.Cells["DIEM_HM"].Value = Math.Round(hm, 2);
            }
        }

      
        private void dgvDK_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string value = e.FormattedValue.ToString();
            if (string.IsNullOrWhiteSpace(value))
            {
                dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                return;
            }
            

            if (dgvDK.Columns[e.ColumnIndex].Name == "DIEM_CC")
            {
                int temp;
                if (!int.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    MessageBox.Show("Bạn phải nhập vào một số nguyên dương (Ví dụ: 5) để hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                }
            }

            if (dgvDK.Columns[e.ColumnIndex].Name == "DIEM_GK" || dgvDK.Columns[e.ColumnIndex].Name == "DIEM_CK")
            {
                double temp;
                if (!double.TryParse(e.FormattedValue.ToString(), out temp))
                {
                    MessageBox.Show("Bạn phải nhập vào một số thực (Ví dụ: 5,5) để hợp lệ!", "Lỗi định dạng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                    dgvDK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = DBNull.Value;
                }
            }
        }

        private double TryParse(object val)
        {
            double result = 0;
            double.TryParse(Convert.ToString(val), out result);
            return result;
        }

        private void dgvDK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}