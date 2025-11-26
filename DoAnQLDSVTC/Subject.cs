using DoAnQLDSVTC.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.MKhoa;

            Program.bds_dspm.Filter = "TENKHOA <> 'PHÒNG KẾ TOÁN'";


            for (int i = 0; i < Program.bds_dspm.Count; i++)
            {
                sites[i] = new Stack<ActionSubject>();
            }


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
            try
            {
                string maMH = txtMaMonHoc.Text.Trim();
                string tenMH = txtTenMonHoc.Text.Trim();
                int soTietLT = int.Parse(nudSTLT.Value.ToString());
                int soTietTH = int.Parse(nudSTTH.Value.ToString());

                string strSP = "EXEC SP_CHECKTMAMH '" + maMH.Trim() + "'";
                int result = CheckMaMH(strSP);

                if (result == -1)
                {
                    MessageBox.Show("Lỗi kết nối CSDL!", "", MessageBoxButtons.OK);
                    return;
                }
                if (result == 1)
                {
                    MessageBox.Show("Mã Lớp đã tồn tại trong khoa này!", "", MessageBoxButtons.OK);
                    txtMaMonHoc.Focus();
                    return;

                }
                if (result == 2)
                {
                    MessageBox.Show("Mã Lớp đã tồn tại trong khoa khác!", "", MessageBoxButtons.OK);
                    txtMaMonHoc.Focus();
                    return;
                }

                // fix bug SOTIET_LT và SOTIET_TH khi thêm dữ liệu mới 2 lần mới giá trị 1
                var current = (DataRowView)dbsMONHOC.Current;
                current["MAMH"] = maMH;
                current["TENMH"] = tenMH;
                current["SOTIET_LT"] = soTietLT;
                current["SOTIET_TH"] = soTietTH;


                dbsMONHOC.EndEdit();
                MONHOCTableAdapter.Update(DS.MONHOC);
                ActionSubject action = new ActionSubject(STATE_ACTION.ADD, maMH, tenMH, soTietLT, soTietTH);
                undo.Push(action);
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                MessageBox.Show("Tạo thông tin môn học thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm môn học. Vui lòng kiểm tra lại thông tin môn học.", "", MessageBoxButtons.OK);
                return;
            }
        }

        private int CheckMaMH(string cmd)
        {
            SqlDataReader dataReader = Program.ExecSqlDataReader(cmd);

            if (dataReader == null) return -1;

            dataReader.Read();
            int result = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();
            return result;
        }

        public void DeleteData()
        {
            try
            {
                string maMH = txtMaMonHoc.Text.Trim();
                string tenMH = txtTenMonHoc.Text.Trim();
                int soTietLT = int.Parse(nudSTLT.Value.ToString());
                int soTietTH = int.Parse(nudSTLT.Value.ToString());

                dbsMONHOC.RemoveCurrent();
                MONHOCTableAdapter.Update(DS.MONHOC);

                ActionSubject action = new ActionSubject(STATE_ACTION.DELETE, maMH, tenMH, soTietLT, soTietTH);
                undo.Push(action);
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                string message = "Môn học " + txtTenMonHoc.Text.Trim() + " đã có lớp tín chỉ.";
                MessageBox.Show(message, "", MessageBoxButtons.OK);
                return;
            }
        }

        public void UpdateData()
        {
            try
            {
                dbsMONHOC.EndEdit();
                MONHOCTableAdapter.Update(DS.MONHOC);
                undo.Push(oldData[0]);
                oldData.Clear();
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật môn học. Vui lòng kiểm tra lại thông tin lớp.", "", MessageBoxButtons.OK);
                return;

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
            nudSTLT.Value = 1;
            nudSTTH.Value = 1;
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
            string message = "Bạn có chắc chắn muốn xóa lớp " + txtTenMonHoc.Text.Trim() + " không?";
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Admin parent = this.TopLevelControl as Admin;
            Form form = btn.FindForm();
            parent.DeleteButtonInTabBar(form);
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
                    string message = "Bạn có muốn cập nhật thông tin môn học này không?";
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
            dbsMONHOC.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
            txtMaMonHoc.Enabled = true;
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

            lblMessage.Text = "";
            return true;
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
