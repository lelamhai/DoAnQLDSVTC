using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ClassRoom : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.ADD;
        private Stack<ActionClassroom> undo = new Stack<ActionClassroom>();
        private List<ActionClassroom> oldData = new List<ActionClassroom>();
        private int currentKhoa;

        public ClassRoom()
        {
            InitializeComponent();
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {
            currentKhoa = Program.MKhoa;
            LoadDatasetApdapter();
            LoadCombox();
            LoadNameLogin();
            CleanTextBox();
            ActionForm();
            isButtonUndo();
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            switch (dgvLop.Columns[e.ColumnIndex].Name.ToUpper())
            {
                case nameof(STATE_ACTION.EDIT):
                    MessageBox.Show("EDIT");
                    oldData.Clear();
                    currentAction = STATE_ACTION.EDIT;
                    txtMaLop.Enabled = false;
                    DataGridViewRow rowEdit = dgvLop.Rows[e.RowIndex];
                    txtMaLop.Text = rowEdit.Cells["MALOP"].Value?.ToString();
                    txtTenLop.Text = rowEdit.Cells["TENLOP"].Value?.ToString();
                    txtKhoaHoc.Text = rowEdit.Cells["KHOAHOC"].Value?.ToString();
                    
                    ActionClassroom actionEdit = new ActionClassroom(STATE_ACTION.EDIT, rowEdit.Cells["MALOP"].Value?.ToString(), rowEdit.Cells["TENLOP"].Value?.ToString(), rowEdit.Cells["KHOAHOC"].Value?.ToString(), rowEdit.Cells["MAKHOA"].Value?.ToString());
                    oldData.Add(actionEdit);
                    ActionForm();
                    break;

                case nameof(STATE_ACTION.DELETE):
                    MessageBox.Show("DELETE");
                    DataGridViewRow rowDelete = dgvLop.Rows[e.RowIndex];
                    string maLop = rowDelete.Cells["MALOP"].Value?.ToString();
                    string tenLop = rowDelete.Cells["TENLOP"].Value?.ToString();
                    string khoaHoc = rowDelete.Cells["KHOAHOC"].Value?.ToString();
                    string maKhoa = rowDelete.Cells["MAKHOA"].Value?.ToString();
                    try
                    {
                        DeleteData(maLop);
                        ActionClassroom action = new ActionClassroom(STATE_ACTION.DELETE, maLop, tenLop, khoaHoc, maKhoa);
                        undo.Push(action);
                        isButtonUndo();
                        CleanTextBox();
                        currentAction = STATE_ACTION.ADD;
                        ActionForm();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Xóa lớp thất bại. Vui lòng kiểm tra lại!\n" + ex.Message);
                    }
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    try
                    {
                        AddData(maLop, tenLop, khoaHoc, maKhoa);

                        ActionClassroom action = new ActionClassroom(STATE_ACTION.ADD, maLop, tenLop, khoaHoc, maKhoa);
                        undo.Push(action);
                        isButtonUndo();
                        CleanTextBox();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm lớp thất bại. Vui lòng kiểm tra lại!\n" + ex.Message);
                    }
                    break;

                case STATE_ACTION.EDIT:
                    try
                    {
                        EditData(maLop, tenLop, khoaHoc, maKhoa);
                        undo.Push(oldData[0]);
                        isButtonUndo();
                        oldData.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Chỉnh sửa lớp thất bại. Vui lòng kiểm tra lại!\n" + ex.Message);
                    }
                    break;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undo.Count <= 0)
            {
                return;
            }
            UndoAction();
            CleanTextBox();
            currentAction = STATE_ACTION.ADD;
            ActionForm();
            isButtonUndo();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanTextBox();
            currentAction = STATE_ACTION.ADD;
            ActionForm();
        }


        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentKhoa = cmbKhoa.SelectedIndex;

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
        }

        public void AddData(params object[] args)
        {
            string maLop = (string)args[0];
            string tenLop = (string)args[1];
            string khoaHoc = (string)args[2];
            string maKhoa = (string)args[3];

            LOPTableAdapter.Insert(maLop.Trim(), tenLop.Trim(), khoaHoc.Trim(), maKhoa.Trim());
            LOPTableAdapter.Fill(DS.LOP);
        }

        public void EditData(params object[] args)
        {
            string maLop = (string)args[0];
            string tenLop = (string)args[1];
            string khoaHoc = (string)args[2];
            string maKhoa = (string)args[3];

            DS.LOPRow row = DS.LOP.FindByMALOP(maLop.Trim());
            row.TENLOP = tenLop.Trim();
            row.KHOAHOC = khoaHoc.Trim();
            row.MAKHOA = maKhoa.Trim();
            LOPTableAdapter.Update(DS.LOP);
        }

        public void DeleteData(params object[] args)
        {
            string maLop = (string)args[0];
            DS.LOPRow rowADD = DS.LOP.FindByMALOP(maLop.Trim());
            rowADD.Delete();
            LOPTableAdapter.Update(DS.LOP);
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
                    DeleteData(action.MaLop);
                    break;

                case STATE_ACTION.EDIT:
                    DS.LOPRow rowEDIT = DS.LOP.FindByMALOP(action.MaLop.Trim());
                    if (rowEDIT == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }
                    EditData(action.MaLop, action.TenLop, action.KhoaHoc, action.MaKhoa);
                    break;

                case STATE_ACTION.DELETE:
                    AddData(action.MaLop, action.TenLop, action.KhoaHoc, action.MaKhoa);
                    break;

            }
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
        }

        void LoadNameLogin()
        {
            lblLogin.Text = "Xin chào " + Program.MLogin + "!";
        }

        void CleanTextBox()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
        }

        void ActionForm()
        {
            string strTitle = "";
            string strClear = "";

            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    strTitle = "Thêm Mới Dữ Liệu";
                    strClear = "Làm Mới";
                    txtMaLop.Enabled = true;
                    lblTitleForm.Text = strTitle;
                    btnClear.Text = strClear;
                    break;

                case STATE_ACTION.EDIT:
                    strTitle = "Chỉnh Sửa Dữ Liệu";
                    strClear = "Hủy";
                    txtMaLop.Enabled = false;
                    lblTitleForm.Text = strTitle;
                    btnClear.Text = strClear;
                    break;
            }
        }

        void isButtonUndo()
        {
            if(undo.Count >= 1)
            {
                btnUndo.Enabled = true;
            } else
            {
                btnUndo.Enabled = false;
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
}
