using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class ClassRoom : Form
    {
        enum STATE_ACTION
        {
            ADD,
            EDIT,
            DELETE
        }
        private STATE_ACTION currentAction = STATE_ACTION.ADD;

        class ActionClassroom
        {
            public ActionClassroom(STATE_ACTION action, string maLop, string oldTenLop, string oldKhoaHoc, string oldMaKhoa)
            {
                Action = action;
                MaLop = maLop;
                OldTenLop = oldTenLop;
                OldKhoaHoc = oldKhoaHoc;
                OldMaKhoa = oldMaKhoa;
            }

            public STATE_ACTION Action { get; set; }

            public string MaLop { get; set; }

            public string OldTenLop { get; set; }
            public string OldKhoaHoc { get; set; }
            public string OldMaKhoa { get; set; }
        }

        Stack<ActionClassroom> undo = new Stack<ActionClassroom>();  

        public ClassRoom()
        {
            InitializeComponent();
        }

        private void ClassRoom_Load(object sender, EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadNameLogin();
            CleanTextBox();
            ActionForm();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();


            switch(currentAction)
            {
                case STATE_ACTION.ADD:
                    LOPTableAdapter.Insert(maLop, tenLop, khoaHoc, maKhoa);
                    LOPTableAdapter.Fill(DS.LOP);

                    ActionClassroom action = new ActionClassroom(
                       STATE_ACTION.ADD,
                       maLop,
                       tenLop,
                       khoaHoc,
                       maKhoa
                   );
                    undo.Push(action);

                    CleanTextBox();
                    break;

                case STATE_ACTION.EDIT:
                    DS.LOPRow row = DS.LOP.FindByMALOP(txtMaLop.Text.Trim());
                    if (row == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }

                    row.TENLOP = txtTenLop.Text.Trim();
                    row.KHOAHOC = txtKhoaHoc.Text.Trim();
                    row.MAKHOA = txtMaKhoa.Text.Trim();

                    LOPTableAdapter.Update(DS.LOP);
                    break;
            }    
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanTextBox();
            if(currentAction == STATE_ACTION.EDIT)
            {
                undo.Pop();
            }    

            currentAction = STATE_ACTION.ADD;
            ActionForm();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (undo.Count < 0)
            {
                MessageBox.Show("Không có thao tác để hoàn tác");
                return;
            }

            ActionClassroom action = undo.Pop();
            if (action != null)
            {
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

                        rowEDIT.TENLOP = action.OldTenLop.Trim();
                        rowEDIT.KHOAHOC = action.OldKhoaHoc.Trim();
                        rowEDIT.MAKHOA = action.OldMaKhoa.Trim();

                        LOPTableAdapter.Update(DS.LOP);
                        break;

                    case STATE_ACTION.DELETE:

                        LOPTableAdapter.Insert(action.MaLop.Trim(), action.OldTenLop.Trim(), action.OldKhoaHoc.Trim(), action.OldMaKhoa.Trim());
                        LOPTableAdapter.Fill(DS.LOP);
                        break;
                }
            }
        }

        private void OnCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            switch (dgvLop.Columns[e.ColumnIndex].Name)
            {
                case "Edit":
                    MessageBox.Show("Edit");
                    DataGridViewRow row = dgvLop.Rows[e.RowIndex];
                    txtMaLop.Enabled = false;

                    txtMaLop.Text = row.Cells["MALOP"].Value?.ToString();
                    txtTenLop.Text = row.Cells["TENLOP"].Value?.ToString();
                    txtKhoaHoc.Text = row.Cells["KHOAHOC"].Value?.ToString();
                    currentAction = STATE_ACTION.EDIT;

                    DS.LOPRow checkMaLop = DS.LOP.FindByMALOP(txtMaLop.Text.Trim());
                    if (checkMaLop == null)
                    {
                        MessageBox.Show("Không tìm thấy lớp");
                        return;
                    }

                    ActionClassroom action = new ActionClassroom(
                        STATE_ACTION.EDIT,
                        row.Cells["MALOP"].Value?.ToString(),
                        row.Cells["TENLOP"].Value?.ToString(),
                        row.Cells["KHOAHOC"].Value?.ToString(),
                        row.Cells["MAKHOA"].Value?.ToString()
                    );
                    undo.Push(action);

                    ActionForm();

                    break;

                case "Delete":
                    DataGridViewRow rowDelete = dgvLop.Rows[e.RowIndex];
                    ActionClassroom actionDelete = new ActionClassroom(
                        STATE_ACTION.DELETE,
                        rowDelete.Cells["MALOP"].Value?.ToString(),
                        rowDelete.Cells["TENLOP"].Value?.ToString(),
                        rowDelete.Cells["KHOAHOC"].Value?.ToString(),
                        rowDelete.Cells["MAKHOA"].Value?.ToString()
                    );
                    undo.Push(actionDelete);

                    bdsLop.RemoveCurrent();
                    LOPTableAdapter.Update(DS.LOP);

                    
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
    }
}
