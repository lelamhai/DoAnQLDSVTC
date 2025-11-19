using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class Classroom : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.ADD;
        private Stack<ActionClassroom> undo = new Stack<ActionClassroom>();
        private List<ActionClassroom> oldData = new List<ActionClassroom>();
        private int currentKhoa;
        public Classroom()
        {
            InitializeComponent();
        }

        private void Classroom_Load(object sender, System.EventArgs e)
        {
            LoadDatasetApdapter();
            LoadCombox();
            LoadLabelKhoa();
            LoadActiveLeft();
            CleanTextBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentAction = STATE_ACTION.ADD;
            dbsLOP.AddNew();
            txtMaKhoa.Text = ((DataRowView)dbsLOP[0])["MAKHOA"].ToString(); ;
            txtMaLop.Focus();
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();

            currentAction = STATE_ACTION.EDIT;
            ActionClassroom actionEdit = new ActionClassroom(STATE_ACTION.EDIT, maLop, tenLop, khoaHoc, maKhoa);
            oldData.Add(actionEdit);
            LoadActiveRight();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string maLop = txtMaLop.Text.Trim();
            string tenLop = txtTenLop.Text.Trim();
            string khoaHoc = txtKhoaHoc.Text.Trim();
            string maKhoa = txtMaKhoa.Text.Trim();
            
            currentAction = STATE_ACTION.DELETE;
            DeleteData();
            ActionClassroom action = new ActionClassroom(STATE_ACTION.DELETE, maLop, tenLop, khoaHoc, maKhoa);
            undo.Push(action);
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
                    AddData();
                    ActionClassroom action = new ActionClassroom(STATE_ACTION.ADD, maLop, tenLop, khoaHoc, maKhoa);
                    undo.Push(action);
                    break;

                case STATE_ACTION.EDIT:
                    UpdateData();
                    undo.Push(oldData[0]);
                    oldData.Clear();
                    break;
            }
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

        private void cmbKhoa_SelectedIndexChanged(object sender, System.EventArgs e)
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

        private void LoadLabelKhoa()
        {
            lblTitleKhoa.Text = cmbKhoa.Text;
        }

        void CleanTextBox()
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            txtKhoaHoc.Text = "";
        }

        public void AddData()
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
            LoadActiveLeft();
        }

        public void UpdateData()
        {
            dbsLOP.EndEdit();
            LOPTableAdapter.Update(DS.LOP);
        }

        public void DeleteData()
        {
            dbsLOP.RemoveCurrent();
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
                    DS.LOPRow row = DS.LOP.FindByMALOP(action.MaLop.Trim());
                    row.TENLOP = action.TenLop.Trim();
                    row.KHOAHOC = action.KhoaHoc.Trim();
                    row.MAKHOA = action.MaKhoa.Trim();
                    LOPTableAdapter.Update(DS.LOP);
                    break;

                case STATE_ACTION.DELETE:
                    LOPTableAdapter.Insert(action.MaLop.Trim(), action.TenLop.Trim(), action.KhoaHoc.Trim(), action.MaKhoa.Trim());
                    LOPTableAdapter.Fill(DS.LOP);

                    break;

            }
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dbsLOP.CancelEdit();
            oldData.Clear();
            pLeft.Enabled = true;
            pRight.Enabled = false;
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
