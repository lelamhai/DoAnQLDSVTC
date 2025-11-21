using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Student : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.ADD;
        private Stack<ActionStudent> undo = new Stack<ActionStudent>();
        private List<ActionStudent> oldData = new List<ActionStudent>();
        private int currentKhoa;
        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadLabelKhoa();
            LoadActiveLeft();
            lblTitleKhoa.Focus();
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentKhoa = cmbKhoa.SelectedIndex;
            lblTitleKhoa.Text = cmbKhoa.Text;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

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
            FKSINHVIENLOPBindingSource.EndEdit();
            SINHVIENTableAdapter.Update(DS.SINHVIEN);
            LoadActiveLeft();
        }

        public void UpdateData()
        {
            FKSINHVIENLOPBindingSource.EndEdit();
            SINHVIENTableAdapter.Update(DS.SINHVIEN);
        }

        public void DeleteData()
        {
            FKSINHVIENLOPBindingSource.RemoveCurrent();
            SINHVIENTableAdapter.Update(DS.SINHVIEN);
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
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    rowADD.Delete();
                    SINHVIENTableAdapter.Update(DS.SINHVIEN);
                    break;
                case STATE_ACTION.EDIT:
                    lblMaLop.Text = action.maLop;
                    txtMaSV.Text = action.maSV;
                    txtHo.Text = action.ho;
                    txtTen.Text = action.ten;
                    dtpDOB.Value = action.ngaySinh;
                    txtDiaChi.Text = action.diaChi;
                    cbFemale.Checked = action.phai;
                    cbNotStudy.Checked = action.dangNghiHoc;
                    FKSINHVIENLOPBindingSource.EndEdit();
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
                        action.maLop, 
                        action.dangNghiHoc, 
                        string.Empty);

                    SINHVIENTableAdapter.Fill(DS.SINHVIEN);
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = lblMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            DateTime ngaySinh = dtpDOB.Value;
            string diaChi = txtDiaChi.Text.Trim();
            bool phai = cbFemale.Checked;
            bool dangNghiHoc = cbNotStudy.Checked;

            switch(currentAction)
            {
                case STATE_ACTION.ADD:
                    AddData();
                    ActionStudent action = new ActionStudent(STATE_ACTION.ADD, maLop, maSV, ho, ten, ngaySinh, diaChi, phai, dangNghiHoc);
                    undo.Push(action);
                    break;

                case STATE_ACTION.EDIT:
                    UpdateData();
                    undo.Push(oldData[0]);
                    oldData.Clear();
                    break;
            }

            FKSINHVIENLOPBindingSource.EndEdit();
            SINHVIENTableAdapter.Update(DS.SINHVIEN);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            FKSINHVIENLOPBindingSource.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentAction = STATE_ACTION.ADD;
            cbFemale.Checked = false;
            cbNotStudy.Checked = false;
            FKSINHVIENLOPBindingSource.AddNew();
            lblTitleKhoa.Focus();
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadActiveLeft();

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
            string maLop = lblMaLop.Text.Trim();
            string maSV = txtMaSV.Text.Trim();
            string ho = txtHo.Text.Trim();
            string ten = txtTen.Text.Trim();
            DateTime ngaySinh = dtpDOB.Value;
            string diaChi = txtDiaChi.Text.Trim();
            bool phai = cbFemale.Checked;
            bool dangNghiHoc = cbNotStudy.Checked;

            currentAction = STATE_ACTION.DELETE;
            DeleteData();
            ActionStudent action = new ActionStudent(STATE_ACTION.DELETE, maLop, maSV, ho, ten, ngaySinh, diaChi, phai, dangNghiHoc);
            undo.Push(action);
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
