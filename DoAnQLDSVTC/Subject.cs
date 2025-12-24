using DoAnQLDSVTC.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Subject : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.NONE;
        private Stack<ActionSubject> undo = new Stack<ActionSubject>();
        private List<ActionSubject> oldData = new List<ActionSubject>();
        private Dictionary<int, Stack<ActionSubject>> sites = new Dictionary<int, Stack<ActionSubject>>();
        private int currentKhoa;

        public Subject()
        {
            InitializeComponent();
        }

        private void Subject_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadUndo();
            LoadLabelKhoa();
            LoadActiveLeft();
            lblTitleKhoa.Focus();
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

        private void LoadLabelKhoa()
        {
            lblTitleKhoa.Text = cmbKhoa.Text;
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

        private void LoadCombox()
        {
            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";
            for (int i = 0; i < Program.bds_dspm.Count; i++)
            {
                sites[i] = new Stack<ActionSubject>();
            }

            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;


            string quyen = Program.mGroup;
            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void LoadDatasetApdapter()
        {
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
        }

        public void AddData()
        {
            string maMH = txtMaMonHoc.Text.Trim();
            string tenMH = txtTenMonHoc.Text.Trim();
            int soTietLT = int.Parse(nudSTLT.Value.ToString());
            int soTietTH = int.Parse(nudSTTH.Value.ToString());

            string cmd = "EXEC SP_CHECK_TAOMONHOC N'" + maMH + "', N'" + tenMH + "'";
            int result = Program.ExecSqlNonQuery(cmd);
            if (result == 0)
            {
                dbsMONHOC.EndEdit();
                MONHOCTableAdapter.Update(DS.MONHOC);
                ActionSubject action = new ActionSubject(STATE_ACTION.ADD, maMH, tenMH, soTietLT, soTietTH);
                undo.Push(action);
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                MessageBox.Show("Tạo thông tin môn học '"+tenMH+"' thành công!", "Thông báo");
                LoadDatasetApdapter();
            }
        }

        public void DeleteData()
        {

            string maMH = txtMaMonHoc.Text.Trim();
            string tenMH = txtTenMonHoc.Text.Trim();
            int soTietLT = int.Parse(nudSTLT.Value.ToString());
            int soTietTH = int.Parse(nudSTLT.Value.ToString());
            string cmd = "EXEC SP_CHECK_XOAMONHOC N'" + maMH + "'";
            int result = Program.ExecSqlNonQuery(cmd);
            if (result == 0)
            {
                dbsMONHOC.RemoveCurrent();
                MONHOCTableAdapter.Update(DS.MONHOC);

                ActionSubject action = new ActionSubject(STATE_ACTION.DELETE, maMH, tenMH, soTietLT, soTietTH);
                undo.Push(action);
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
        }

        public void UpdateData()
        {
            string cmd = "EXEC SP_CHECK_CAPNHATMONHOC N'" + txtTenMonHoc.Text.Trim() + "'";
            int result = Program.ExecSqlNonQuery(cmd);
            if (result == 0)
            {
                dbsMONHOC.EndEdit();
                MONHOCTableAdapter.Update(DS.MONHOC);
                undo.Push(oldData[0]);
                oldData.Clear();
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                LoadDatasetApdapter();
            }
        }
        public void UndoAction()
        {
            ActionSubject action = undo.Pop();
            switch (action.Action)
            {
                case STATE_ACTION.ADD:
                    DS.MONHOCRow rowADD = DS.MONHOC.FindByMAMH(action.MaMH.Trim());
                    if (rowADD == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    rowADD.Delete();
                    MONHOCTableAdapter.Update(DS.MONHOC);
                    break;

                case STATE_ACTION.EDIT:
                    DS.MONHOCRow rowEDIT = DS.MONHOC.FindByMAMH(action.MaMH.Trim());
                    if (rowEDIT == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    rowEDIT.TENMH = action.TenHM.Trim();
                    rowEDIT.SOTIET_LT = action.STLT;
                    rowEDIT.SOTIET_TH = action.STTH;
                    MONHOCTableAdapter.Update(DS.MONHOC);
                    break;

                case STATE_ACTION.DELETE:
                    MONHOCTableAdapter.Insert(action.MaMH.Trim(), action.TenHM.Trim(), action.STLT, action.STTH);
                    MONHOCTableAdapter.Fill(DS.MONHOC);

                    break;
            }
            currentAction = STATE_ACTION.NONE;
            LoadUndo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentAction = STATE_ACTION.ADD;
            dbsMONHOC.AddNew();
            nudSTLT.Value = 0;
            nudSTTH.Value = 0;
            txtMaMonHoc.Enabled = true;
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMonHoc.Text.Trim();
            string tenMH = txtTenMonHoc.Text.Trim();
            int soTietLT = int.Parse(nudSTLT.Value.ToString());
            int soTietTH = int.Parse(nudSTLT.Value.ToString());

            currentAction = STATE_ACTION.EDIT;
            LoadActiveLeft();
            txtMaMonHoc.Enabled = false;
            ActionSubject actionEdit = new ActionSubject(STATE_ACTION.EDIT, maMH, tenMH, soTietLT, soTietTH);
            oldData.Add(actionEdit);
            LoadUndo();
            LoadActiveRight();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn xóa lớp '" + txtTenMonHoc.Text.Trim() + "' không?";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Admin parent = this.TopLevelControl as Admin;
            parent.CloseForm(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maMH = txtMaMonHoc.Text.Trim();
            string tenMH = txtTenMonHoc.Text.Trim();
            int soTietLT = int.Parse(nudSTLT.Value.ToString());
            int soTietTH = int.Parse(nudSTTH.Value.ToString());

            if (!ValidateSubject())
            {
                return;
            }

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    AddData();
                    break;

                case STATE_ACTION.EDIT:
                    string message = "Bạn có muốn cập nhật thông tin môn học '"+txtTenMonHoc.Text.Trim()+"' này không?";
                    DialogResult result = MessageBox.Show(
                        message,
                        "Xác nhận",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
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
            dbsMONHOC.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
            txtMaMonHoc.Enabled = true;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newIndex = cmbKhoa.SelectedIndex;

            if (newIndex < 0) return;
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView") return;

            sites[currentKhoa] = undo;
            undo = sites[newIndex];
            currentKhoa = newIndex;
            LoadUndo();

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

        private bool ValidateSubject()
        {
            if (string.IsNullOrWhiteSpace(txtMaMonHoc.Text))
            {
                lblMessage.Text = "Vui lòng nhập Mã Môn Học.";
                txtMaMonHoc.Focus();
                return false;
            }

            if (txtMaMonHoc.Text.Length < 2)
            {
                lblMessage.Text = "Mã Môn Học phải từ 2 ký tự.";
                txtMaMonHoc.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenMonHoc.Text))
            {
                lblMessage.Text = "Vui lòng nhập Tên Môn Học.";
                txtTenMonHoc.Focus();
                return false;
            }

            if (txtTenMonHoc.Text.Length < 6)
            {
                lblMessage.Text = "Tên Môn Học phải từ 6 ký tự.";
                txtTenMonHoc.Focus();
                return false;
            }

            if (nudSTLT.Value <= 0)
            {
                lblMessage.Text = "Số Tiết Lý Thuyết phải lớn 0.";
                nudSTLT.Focus();
                return false;
            }

            //if (nudSTTH.Value <= 0)
            //{
            //    lblMessage.Text = "Số Tiết Thực Hành phải lớn 0.";
            //    nudSTTH.Focus();
            //    return false;
            //}

            lblMessage.Text = "";
            return true;
        }
    }

    class ActionSubject
    {
        public STATE_ACTION Action { get; set; }
        public string MaMH { get; set; }
        public string TenHM { get; set; }
        public int STLT { get; set; }
        public int STTH { get; set; }

        public ActionSubject(STATE_ACTION action, string maMH, string oldTenMN, int oldSoTietLT, int oldSoTietTH)
        {
            this.Action = action;
            this.MaMH = maMH;
            this.TenHM = oldTenMN;
            this.STLT = oldSoTietLT;
            this.STTH = oldSoTietTH;
        }
    }
}
