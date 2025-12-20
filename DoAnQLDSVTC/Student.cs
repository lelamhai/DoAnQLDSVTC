using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Student : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.ADD;
        private Stack<ActionStudent> undo = new Stack<ActionStudent>();
        private List<ActionStudent> oldData = new List<ActionStudent>();
        private Dictionary<int, Stack<ActionStudent>> sites = new Dictionary<int, Stack<ActionStudent>>();
        private int currentKhoa;
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadUndo();
            LoadLabelKhoa();
            LoadActiveLeft();
            lblTitleKhoa.Focus();
        }

        private void SetupNgaySinhSV()
        {
            dtpDOB.MaxDate = DateTime.Today.AddYears(-17);
            dtpDOB.Value = dtpDOB.MaxDate;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newIndex = cmbKhoa.SelectedIndex;

            if (newIndex < 0) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            sites[currentKhoa] = undo;
            undo = sites[newIndex];
            currentKhoa = newIndex;

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
                LoadDatasetApdapter();
            }

            lblTitleKhoa.Focus();
            LoadUndo();
            LoadActiveLeft();
        }

        private void LoadUndo()
        {
            if (undo.Count > 0)
            {
                btnUndo.Enabled = true;
                return;
            }

            btnUndo.Enabled = false;
        }

        void LoadDatasetApdapter()
        {
            DS.EnforceConstraints = false;
            this.LOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.LOPTableAdapter.Fill(this.DS.LOP);

            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
        }

        void LoadCombox()
        {
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";

            for (int i = 0; i < Program.bds_dspm.Count; i++)
            {
                sites[i] = new Stack<ActionStudent>();
            }


            string quyen = Program.mGroup;

            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void LoadLabelKhoa()
        {
            lblTitleKhoa.Text = cmbKhoa.Text;
        }

        public void AddData()
        {
            string maLop = lblMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            DateTime ngaySinh = dtpDOB.Value;
            string diaChi = txtDiaChi.Text.Trim();
            bool phai = cbFemale.Checked;
            bool dangNghiHoc = cbNotStudy.Checked;

            string strSP = "EXEC SP_CHECK_TAOSINHVIEN N'" + maSV.Trim() + "'";
            int result = Program.ExecSqlNonQuery(strSP);
            if (result == 0)
            {
                FKSINHVIENLOPBindingSource.EndEdit();
                SINHVIENTableAdapter.Update(DS.SINHVIEN);
                ActionStudent action = new ActionStudent(STATE_ACTION.ADD, maLop, maSV, ho, ten, ngaySinh, diaChi, phai, dangNghiHoc);
                undo.Push(action);
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                MessageBox.Show("Tạo thông tin sinh viên '"+ho+ " "+ ten +"' thành công!", "Thông báo");
            }
        }

        public void UpdateData()
        {
            try
            {
                FKSINHVIENLOPBindingSource.EndEdit();
                SINHVIENTableAdapter.Update(DS.SINHVIEN);
                undo.Push(oldData[0]);
                oldData.Clear();
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sinh viên. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public void DeleteData()
        {
            string maLop = lblMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            DateTime ngaySinh = dtpDOB.Value;
            string diaChi = txtDiaChi.Text.Trim();
            bool phai = cbFemale.Checked;
            bool dangNghiHoc = cbNotStudy.Checked;

            string strSP = "EXEC SP_CHECK_XOASINHVIEN N'" + maSV.Trim() + "'";
            int result = Program.ExecSqlNonQuery(strSP);
            if (result == 0)
            {
                FKSINHVIENLOPBindingSource.RemoveCurrent();
                SINHVIENTableAdapter.Update(DS.SINHVIEN);
                ActionStudent action = new ActionStudent(STATE_ACTION.DELETE, maLop, maSV, ho, ten, ngaySinh, diaChi, phai, dangNghiHoc);
                undo.Push(action);
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
        }

        public void UndoAction()
        {
            ActionStudent action = undo.Pop();
            switch (action.action)
            {
                case STATE_ACTION.ADD:
                    DS.SINHVIENRow rowADD = DS.SINHVIEN.FindByMASV(action.maSV.Trim());
                    if (rowADD == null)
                    {
                        MessageBox.Show("Không tìm mã sinh viên");
                        return;
                    }
                    rowADD.Delete();
                    SINHVIENTableAdapter.Update(DS.SINHVIEN);
                    break;
                case STATE_ACTION.EDIT:
                    DS.SINHVIENRow rowEDIT = DS.SINHVIEN.FindByMASV(action.maSV.Trim());
                    if (rowEDIT == null)
                    {
                        MessageBox.Show("Không tìm mã sinh viên");
                        return;
                    }
                    rowEDIT.MASV = action.maSV.Trim();
                    rowEDIT.HO = action.ho.Trim();
                    rowEDIT.TEN = action.ten.Trim();
                    rowEDIT.PHAI = action.phai;
                    rowEDIT.DIACHI = action.diaChi.Trim();
                    rowEDIT.NGAYSINH = action.ngaySinh;
                    rowEDIT.MALOP = action.maLop.Trim();
                    rowEDIT.DANGHIHOC = action.dangNghiHoc;
                    rowEDIT.PASSWORD = string.Empty;
                    SINHVIENTableAdapter.Update(DS.SINHVIEN);

                    break;
                case STATE_ACTION.DELETE:
                    SINHVIENTableAdapter.Insert(
                        action.maSV.Trim(),
                        action.ho.Trim(), 
                        action.ten.Trim(), 
                        action.phai, 
                        action.diaChi.Trim(),
                        action.ngaySinh, 
                        action.maLop.Trim(), 
                        action.dangNghiHoc, 
                        string.Empty);

                    SINHVIENTableAdapter.Fill(DS.SINHVIEN);
                    break;
            }
            currentAction = STATE_ACTION.NONE;
            LoadUndo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateStudent()) return;

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    AddData();
                    break;

                case STATE_ACTION.EDIT:
                    string message = "Bạn có muốn cập nhật sinh viên '"+txtHo.Text.Trim()+ " " + txtTen.Text.Trim()+"' này không?";
                    DialogResult result = MessageBox.Show(
                        message,
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.No)
                    {
                        return;
                    }

                    UpdateData();
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FKSINHVIENLOPBindingSource.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMaSV.Enabled = true;
            currentAction = STATE_ACTION.ADD;
            FKSINHVIENLOPBindingSource.AddNew();

            rbMale.Checked = true;
            rbStudying.Checked = true;

            SetupNgaySinhSV();
            lblTitleKhoa.Focus();
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadActiveLeft();
            txtMaSV.Enabled = false;
            string maLop = lblMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            DateTime ngaySinh = dtpDOB.Value;
            string diaChi = txtDiaChi.Text.Trim();
            bool phai = cbFemale.Checked;
            bool dangNghiHoc = cbNotStudy.Checked;

            currentAction = STATE_ACTION.EDIT;
            ActionStudent actionEdit = new ActionStudent(STATE_ACTION.EDIT, maLop, maSV, ho, ten, ngaySinh, diaChi, phai, dangNghiHoc);
            oldData.Add(actionEdit);
            LoadActiveRight();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn xóa sinh viên '" + txtHo.Text.Trim() + " " + txtTen.Text.Trim() + "' không?";
            DialogResult result = MessageBox.Show(
                message,
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                return;
            }
            currentAction = STATE_ACTION.DELETE;
            DeleteData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undo.Count <= 0)
            {
                return;
            }
            UndoAction();
        }

        private void LoadActiveLeft()
        {
            pLeft.Enabled = true;
            pRight.Enabled = false;
        }

        private void LoadActiveRight()
        {
            pLeft.Enabled = false;
            pRight.Enabled = true;
        }

        private void bntExit_Click(object sender, EventArgs e)
        {
            Admin parent = this.TopLevelControl as Admin;
            parent.CloseForm(this);
        }

        private void dgvStudent_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStudent.Columns[e.ColumnIndex].Name == "GENDER_TEXT")
            {
                bool phai = Convert.ToBoolean(dgvStudent.Rows[e.RowIndex].Cells["PHAI"].Value);
                e.Value = phai ? "Nữ" : "Nam";
            }

            if (dgvStudent.Columns[e.ColumnIndex].Name == "STUDY_TEXT")
            {
                bool phai = Convert.ToBoolean(dgvStudent.Rows[e.RowIndex].Cells["DANGHIHOC"].Value);
                e.Value = phai ? "Đã nghỉ" : "Đang học";
            }
        }

        private void cbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFemale.Checked)
            {
                rbFemale.Checked = true;
            }
            else
            {
                rbMale.Checked = true;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
           cbFemale.Checked = rbFemale.Checked;
        }

        private void cbNotStudy_CheckedChanged(object sender, EventArgs e)
        {
            if(cbNotStudy.Checked)
            {
                rbNotStudy.Checked = true;
            }
            else
            {
                rbStudying.Checked = true;
            }
        }

        private void rbNotStudy_CheckedChanged(object sender, EventArgs e)
        {
            cbNotStudy.Checked = rbNotStudy.Checked;
        }

        private bool ValidateStudent()
        {
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                lblMessage.Text = "Vui lòng nhập Mã Sinh Viên.";
                txtMaSV.Focus();
                return false;
            }

            if (txtMaSV.Text.Length < 10)
            {
                lblMessage.Text = "Mã Sinh Viên phải từ 10 ký tự.";
                txtMaSV.Focus();
                return false;
            }

            // Họ
            if (string.IsNullOrWhiteSpace(txtHo.Text))
            {
                lblMessage.Text = "Vui lòng nhập Họ.";
                txtHo.Focus();
                return false;
            }

            if (txtHo.Text.Length < 2)
            {
                lblMessage.Text = "Họ phải từ 2 ký tự.";
                txtHo.Focus();
                return false;
            }

            // Tên
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                lblMessage.Text = "Vui lòng nhập Tên.";
                txtTen.Focus();
                return false;
            }

            if (txtTen.Text.Length < 2)
            {
                lblMessage.Text = "Tên phải từ 2 ký tự.";
                txtTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                lblMessage.Text = "Vui lòng nhập Địa Chỉ.";
                txtDiaChi.Focus();
                return false;
            }

            if (txtDiaChi.Text.Length < 5)
            {
                lblMessage.Text = "Địa Chỉ phải từ 5 ký tự.";
                txtDiaChi.Focus();
                return false;
            }

            lblMessage.Text = "";
            return true;
        }

    }

    public class ActionStudent
    {
        public STATE_ACTION action;
        public string maLop;
        public string maSV;
        public string ho;
        public string ten;
        public DateTime ngaySinh;
        public string diaChi;
        public bool phai;
        public bool dangNghiHoc;

        public ActionStudent(STATE_ACTION action, string maLop, string maSV, string ho, string ten, DateTime ngaySinh, string diaChi, bool phai, bool dangNghiHoc)
        {
            this.action = action;
            this.maLop = maLop;
            this.maSV = maSV;
            this.ho = ho;
            this.ten = ten;
            this.ngaySinh = ngaySinh;
            this.diaChi = diaChi;
            this.phai = phai;
            this.dangNghiHoc = dangNghiHoc;
        }
    }
}
