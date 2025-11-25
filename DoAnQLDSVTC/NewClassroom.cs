using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class NewClassroom : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.NONE;
        private Stack<ActionClassroom> undo = new Stack<ActionClassroom>();
        private List<ActionClassroom> oldData = new List<ActionClassroom>();
        private Dictionary<int, Stack<ActionClassroom>> sites = new Dictionary<int, Stack<ActionClassroom>>();
        private int currentKhoa;


        public NewClassroom()
        {
            InitializeComponent();
        }

        private void NewClassroom_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadUndo();
            LoadLabelKhoa();
            LoadActiveLeft();
            SetupBeigin();
            SetupEnd();
            lblTitleKhoa.Focus();
        }

        private void LoadUndo()
        {
            if(undo.Count > 0)
            {
                btnUndo.Enabled = true;
                return;
            } 
            
            btnUndo.Enabled = false;
        }

        private void SetupBeigin()
        {
            dtpBeigin.Format = DateTimePickerFormat.Custom;
            dtpBeigin.CustomFormat = "yyyy";
            dtpBeigin.ShowUpDown = true;
        }
        private void SetupEnd()
        {
            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "yyyy";
            dtpEnd.ShowUpDown = true;
        }

        void LoadDatasetApdapter()
        {
            this.LOPTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.LOPTableAdapter.Fill(this.DS.LOP);
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
                sites[i] = new Stack<ActionClassroom>();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentAction = STATE_ACTION.ADD;

            dbsLOP.AddNew();

            txtMaLop.Enabled = true;
            dtpBeigin.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEnd.Value = new DateTime(DateTime.Now.Year + 1, 1, 1);
            txtKhoaHoc.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;

            txtMaKhoa.Text = ((DataRowView)dbsLOP[0])["MAKHOA"].ToString(); ;
            txtMaLop.Focus();
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadActiveLeft();

            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();
            txtMaLop.Enabled = false;

            currentAction = STATE_ACTION.EDIT;
            ActionClassroom actionEdit = new ActionClassroom(STATE_ACTION.EDIT, maLop, tenLop, khoaHoc, maKhoa);
            oldData.Add(actionEdit);
            LoadUndo();
            LoadActiveRight();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn xóa lớp " + txtTenLop.Text.Trim() + " không?";
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();

            if (!ValidateLogin())
            {
                return;
            }

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    AddData();
                    break;

                case STATE_ACTION.EDIT:
                    string message = "Bạn có muốn cập nhật thông tin lớp này không?";
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
            dbsLOP.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
            txtMaLop.Enabled = true;
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

        public void AddData()
        {
            try
            {
                string maLop = txtMaLop.Text.Trim();
                string tenLop = txtTenLop.Text.Trim();
                string khoaHoc = txtKhoaHoc.Text.Trim();
                string maKhoa = txtMaKhoa.Text.Trim();
                string strSP = "EXEC SP_CHECKMALOP '" + maLop.Trim() + "'";
                int result = CheckMaLop(strSP);

                if (result == -1)
                {
                    MessageBox.Show("Lỗi kết nối CSDL!", "", MessageBoxButtons.OK);
                    return;
                }
                if (result == 1)
                {
                    MessageBox.Show("Mã Lớp đã tồn tại trong khoa này!", "", MessageBoxButtons.OK);
                    txtMaLop.Focus();
                    return;

                }
                if (result == 2)
                {
                    MessageBox.Show("Mã Lớp đã tồn tại trong khoa khác!", "", MessageBoxButtons.OK);
                    txtMaLop.Focus();
                    return;
                }


                dbsLOP.EndEdit();
                LOPTableAdapter.Update(DS.LOP);
                ActionClassroom action = new ActionClassroom(STATE_ACTION.ADD, maLop, tenLop, khoaHoc, maKhoa);
                undo.Push(action);
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                MessageBox.Show("Tạo thông tin lớp thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp. Vui lòng kiểm tra lại thông tin lớp.", "", MessageBoxButtons.OK);
                return;
            }

           
        }

        public void UpdateData()
        {
            try
            {
                dbsLOP.EndEdit();
                LOPTableAdapter.Update(DS.LOP);
                undo.Push(oldData[0]);
                oldData.Clear();
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật lớp. Vui lòng kiểm tra lại thông tin lớp.\n" + ex.Message, "", MessageBoxButtons.OK);
                return;

            }
        }

        public void DeleteData()
        {
            try
            {
                string maLop = txtMaLop.Text.Trim();
                string tenLop = txtTenLop.Text.Trim();
                string khoaHoc = txtKhoaHoc.Text.Trim();
                string maKhoa = txtMaKhoa.Text.Trim();

                dbsLOP.RemoveCurrent();
                LOPTableAdapter.Update(DS.LOP);

                ActionClassroom action = new ActionClassroom(STATE_ACTION.DELETE, maLop, tenLop, khoaHoc, maKhoa);
                undo.Push(action);
                LoadUndo();
                currentAction = STATE_ACTION.DELETE;
            }
            catch (Exception ex)
            {
                string message = "Lớp "+ txtTenLop.Text.Trim() +" đã có Sinh Viên.";
                MessageBox.Show(message, "", MessageBoxButtons.OK);
                return;
            }
        }

        public void UndoAction()
        {
            ActionClassroom action = undo.Pop();
            switch (action.Action)
            {
                case STATE_ACTION.ADD:
                    DS.LOPRow rowADD = DS.LOP.FindByMALOP(action.MaLop.Trim());
                    if (rowADD == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    rowADD.Delete();
                    LOPTableAdapter.Update(DS.LOP);
                    break;

                case STATE_ACTION.EDIT:
                    DS.LOPRow rowEDIT = DS.LOP.FindByMALOP(action.MaLop.Trim());
                    if (rowEDIT == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    rowEDIT.TENLOP = action.TenLop.Trim();
                    rowEDIT.KHOAHOC = action.KhoaHoc.Trim();
                    rowEDIT.MAKHOA = action.MaKhoa.Trim();
                    LOPTableAdapter.Update(DS.LOP);
                    break;

                case STATE_ACTION.DELETE:
                    LOPTableAdapter.Insert(action.MaLop.Trim(), action.TenLop.Trim(), action.KhoaHoc.Trim(), action.MaKhoa.Trim());
                    LOPTableAdapter.Fill(DS.LOP);

                    break;
            }
            currentAction = STATE_ACTION.NONE;
            LoadUndo();
        }

        private int CheckMaLop(string cmd)
        {
            SqlDataReader dataReader = Program.ExecSqlDataReader(cmd);

            if (dataReader == null) return -1;

            dataReader.Read();
            int result = int.Parse(dataReader.GetValue(0).ToString());
            dataReader.Close();
            return result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Admin parent = this.TopLevelControl as Admin;
            Form form = btn.FindForm();
            parent.DeleteButtonInTabBar(form);
        }

        private bool ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                lblMessage.Text = "Vui lòng nhập Mã Lớp.";
                txtMaLop.Focus();
                return false;
            }

            if (txtMaLop.Text.Length < 9)
            {
                lblMessage.Text = " Mã Lớp phải từ 10 ký tự.";
                txtMaLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                lblMessage.Text = "Vui lòng nhập Tên Lớp.";
                txtTenLop.Focus();
                return false;
            }

            if (txtTenLop.Text.Length < 6)
            {
                lblMessage.Text = "Tên Lớp phải từ 6 ký tự.";
                txtTenLop.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtKhoaHoc.Text))
            {
                lblMessage.Text = "Vui lòng nhập Năm Khóa.";
                txtKhoaHoc.Focus();
                return false;
            }

            if (txtKhoaHoc.Text.Length < 8)
            {
                lblMessage.Text = "Mật Khẩu phải từ 9 ký tự.";
                txtKhoaHoc.Focus();
                return false;
            }

            lblMessage.Text = "";
            return true;
        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBeigin.Value.Year >= dtpEnd.Value.Year)
            {
                dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            }
            txtKhoaHoc.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Year <= dtpBeigin.Value.Year)
            {
                dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            }
            txtKhoaHoc.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void txtKhoaHoc_TextChanged(object sender, EventArgs e)
        {
            if (txtKhoaHoc.Text == "") return;

            string khoahoc = txtKhoaHoc.Text;
            string[] arr = khoahoc.Split('-');
            int yBegin = int.Parse(arr[0].Trim());
            int yEnd = int.Parse(arr[1].Trim());

            dtpBeigin.Value = new DateTime(yBegin, 1, 1);
            dtpEnd.Value = new DateTime(yEnd, 1, 1);
        }
    }

    class ActionClassroom
    {
        public STATE_ACTION Action { get; set; }
        public string MaLop { get; set; }
        public string TenLop { get; set; }
        public string KhoaHoc { get; set; }
        public string MaKhoa { get; set; }

        public ActionClassroom(STATE_ACTION action, string maLop, string oldTenLop, string oldKhoaHoc, string oldMaKhoa)
        {
            this.Action = action;
            this.MaLop = maLop;
            this.TenLop = oldTenLop;
            this.KhoaHoc = oldKhoaHoc;
            this.MaKhoa = oldMaKhoa;
        }
    }
}
