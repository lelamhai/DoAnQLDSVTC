using DoAnQLDSVTC.DSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DoAnQLDSVTC
{
    public partial class OpenCourse : Form, IBaseForm
    {
        private STATE_ACTION currentAction = STATE_ACTION.NONE;
        private Stack<ActionOpenCourse> undo = new Stack<ActionOpenCourse>();
        private List<ActionOpenCourse> oldData = new List<ActionOpenCourse>();
        private Dictionary<int, Stack<ActionOpenCourse>> sites = new Dictionary<int, Stack<ActionOpenCourse>>();
        private int currentKhoa;

        public OpenCourse()
        {
            InitializeComponent();
        }

        private void OpenCourse_Load(object sender, EventArgs e)
        {
            
            LoadDatasetApdapter();
            LoadCombox();
            LoadUndo();
            SetupBeigin();
            SetupEnd();
            LoadLabelKhoa();
            LoadActiveLeft();
            lblTitleKhoa.Focus();
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
                sites[i] = new Stack<ActionOpenCourse>();
            }


            string quyen = Program.mGroup;
            if (quyen == Program.quyen[1])
            {
                cmbKhoa.Enabled = false;
            }
        }

        private void LoadDatasetApdapter()
        {
            DS.EnforceConstraints = false;

            this.MONHOCTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            this.GIANGVIENTableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.GIANGVIENTableAdapter.Fill(this.DS.GIANGVIEN);

            this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.URL_Connect;
            this.LOPTINCHITableAdapter.Fill(this.DS.LOPTINCHI);


            if (dgvLTC.Columns["MAGV_TEXT"] == null)
            {
                DS.GIANGVIEN.Columns.Add("MAGV_TEXT", typeof(string), "HO + ' ' + TEN");

                dgvLTC.Columns.Add("MAGV_TEXT", "Giảng Viên");
                dgvLTC.Columns["MAGV"].Visible = false;


                cmbGV.DataSource = dbsGIANGVIEN;
                cmbGV.DisplayMember = "MAGV_TEXT";
                cmbGV.ValueMember = "MAGV";
                cmbGV.DataBindings.Add(
                    "SelectedValue", 
                    dbsLTC, 
                    "MAGV", 
                    true,
                    DataSourceUpdateMode.OnPropertyChanged);

            }

            if (dgvLTC.Columns["MAMH_TEXT"] == null)
            {
                dgvLTC.Columns.Add("MAMH_TEXT", "Môn Học");
                dgvLTC.Columns["MAMH"].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            currentAction = STATE_ACTION.ADD;
            dbsLTC.AddNew();
            txtMaKhoa.Text = ((DataRowView)dbsLTC[0])["MAKHOA"].ToString();
            dtpBeigin.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtpEnd.Value = new DateTime(DateTime.Now.Year + 1, 1, 1);
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
            cbHuyLop.Checked = false;
            nudHocKy.Value = 0;
            nudNhom.Value = 0;
            nudSOSVTT.Value = 0;
            cbHuyLop.Checked = false;
            lblTitleKhoa.Focus();
            LoadActiveRight();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            LoadActiveLeft();
            string maKhoa = txtMaKhoa.Text.Trim();
            string nienKhoa = txtNienKhoa.Text.Trim();
            int hocKy = int.Parse(nudHocKy.Text.Trim());
            string monHoc = cmbMaMH.SelectedValue.ToString().Trim();
            int nhom = int.Parse(nudNhom.Text.Trim());
            string maGV = cmbGV.SelectedValue.ToString().Trim();
            int ssvtt = int.Parse(nudSOSVTT.Text.Trim());
            bool huyLop = cbHuyLop.Checked;

            

            currentAction = STATE_ACTION.EDIT;
            ActionOpenCourse actionEdit = new ActionOpenCourse(STATE_ACTION.EDIT, nienKhoa, hocKy, monHoc, nhom, maGV, maKhoa, ssvtt, huyLop);
            oldData.Add(actionEdit);
            LoadActiveRight();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Bạn có chắc chắn muốn xóa lớp tín chỉ này không?";
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

        private void bntExit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Admin parent = this.TopLevelControl as Admin;
            Form form = btn.FindForm();
            parent.DeleteButtonInTabBar(form);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateOpenCourse()) return;
            switch (currentAction)
            {
                case STATE_ACTION.ADD:
                    AddData();
                    break;
                case STATE_ACTION.EDIT:
                    string message = "Bạn có muốn cập nhật lớp tín chỉ này không?";
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
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dbsLTC.CancelEdit();
            oldData.Clear();
            LoadActiveLeft();
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

        public void AddData()
        {
            try
            {
                string maKhoa = txtMaKhoa.Text.Trim();
                string nienKhoa = txtNienKhoa.Text.Trim();
                int hocKy = int.Parse(nudHocKy.Text.Trim());
                string monHoc = cmbMaMH.SelectedValue.ToString().Trim();
                int nhom = int.Parse(nudNhom.Text.Trim());
                string maGV = cmbGV.SelectedValue.ToString().Trim();
                int ssvtt = int.Parse(nudSOSVTT.Text.Trim());
                bool huyLop = cbHuyLop.Checked;

                string cmd = "EXEC SP_CHECK_LTC '" + nienKhoa + "', '" + monHoc + "', " + nhom + ", " + hocKy;
                int check = Program.CheckMa(cmd);

                if (check == -1)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!", "", MessageBoxButtons.OK); return;
                }

                if (check == 1)
                {
                    MessageBox.Show("Lớp tín chỉ này đã tồn tại trong khoa này!", "", MessageBoxButtons.OK); return;
                }

                if (check == 2)
                {
                    MessageBox.Show("Lớp tín chỉ này đã tồn tại trong khoa khác!", "", MessageBoxButtons.OK); return;
                }

                if(!huyLop)
                {
                    var current = (DataRowView)dbsLTC.Current;
                    current["HUYLOP"] = false;
                }    

                dbsLTC.EndEdit();
                LOPTINCHITableAdapter.Update(DS.LOPTINCHI);
                ActionOpenCourse action = new ActionOpenCourse(STATE_ACTION.ADD, nienKhoa, hocKy, monHoc, nhom, maGV, maKhoa, ssvtt, huyLop);
                undo.Push(action);
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
                MessageBox.Show("Tạo thông tin lớp tín chỉ thành công!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp tín chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateData()
        {
            try
            {
                string maKhoa = txtMaKhoa.Text.Trim();
                string nienKhoa = txtNienKhoa.Text.Trim();
                int hocKy = int.Parse(nudHocKy.Text.Trim());
                string monHoc = cmbMaMH.SelectedValue.ToString().Trim();
                int nhom = int.Parse(nudNhom.Text.Trim());
                string maGV = cmbGV.SelectedValue.ToString().Trim();
                int ssvtt = int.Parse(nudSOSVTT.Text.Trim());
                bool huyLop = cbHuyLop.Checked;

                string cmd = "EXEC SP_CHECK_LTC '" + nienKhoa + "', '" + monHoc + "', " + nhom + ", " + hocKy;
                int check = Program.CheckMa(cmd);

                if (check == -1)
                {
                    MessageBox.Show("Lỗi kết nối cơ sở dữ liệu!", "", MessageBoxButtons.OK); return;
                }

                if (check == 1)
                {
                    MessageBox.Show("Lớp tín chỉ này đã tồn tại trong khoa này!", "", MessageBoxButtons.OK); return;
                }

                if (check == 2)
                {
                    MessageBox.Show("Lớp tín chỉ này đã tồn tại trong khoa khác!", "", MessageBoxButtons.OK); return;
                }

                dbsLTC.EndEdit();
                LOPTINCHITableAdapter.Update(DS.LOPTINCHI);
                
                ActionOpenCourse action = new ActionOpenCourse(
                    STATE_ACTION.EDIT,
                    oldData[0].NienKhoa,
                    oldData[0].HocKy,
                    oldData[0].MaMH,
                    oldData[0].Nhom,
                    oldData[0].MaGV,
                    oldData[0].MaKhoa,
                    oldData[0].SSVTT,
                    oldData[0].HuyLop,
                    nienKhoa,
                    hocKy,
                    monHoc,
                    nhom);

                undo.Push(action);
                oldData.Clear();
                LoadActiveLeft();
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật lớp tín chỉ. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DeleteData()
        {
            try
            {
                string maKhoa = txtMaKhoa.Text.Trim();
                string nienKhoa = txtNienKhoa.Text.Trim();
                int hocKy = int.Parse(nudHocKy.Text.Trim());
                string monHoc = cmbMaMH.SelectedValue.ToString().Trim();
                int nhom = int.Parse(nudNhom.Text.Trim());
                string maGV = cmbGV.SelectedValue.ToString().Trim();
                int ssvtt = int.Parse(nudSOSVTT.Text.Trim());
                bool huyLop = cbHuyLop.Checked;

                dbsLTC.RemoveCurrent();
                LOPTINCHITableAdapter.Update(DS.LOPTINCHI);
                ActionOpenCourse action = new ActionOpenCourse(STATE_ACTION.DELETE, nienKhoa, hocKy, monHoc, nhom, maGV, maKhoa, ssvtt, huyLop);
                undo.Push(action);
                LoadUndo();
                currentAction = STATE_ACTION.NONE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp tín chỉ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UndoAction()
        {
            ActionOpenCourse action = undo.Pop();
            string nienKhoa = action.NienKhoa.Trim();
            int hocKy = action.HocKy;
            string maMH = action.MaMH.Trim();
            int nhom = action.Nhom;
            string maGV = action.MaGV.Trim();
            string maKhoa = action.MaKhoa.Trim();
            int ssvtt = action.SSVTT;
            bool huyLop = action.HuyLop;


            switch (action.Action)
            {
                case STATE_ACTION.ADD:
                    string cmd = string.Format("EXEC SP_XOA_LOPTINCHI N'{0}',N'{1}',N'{2}',N'{3}'",
                        nienKhoa, hocKy, maMH, nhom);
                    int result = Program.CheckMa(cmd);
                    if (result == 0)
                    {
                        MessageBox.Show("Hoàn tác thêm lớp tín chỉ không thành công!");
                    }
                    LoadDatasetApdapter();
                    break;

                case STATE_ACTION.EDIT:
                    string new_nienKhoa = action.newNienKhoa.Trim();
                    int new_hocKy = (int)action.newHocKy;
                    string new_maMH = action.newMaMH.Trim();
                    int new_nhom = (int)action.newNhom;

                    string spEdit = string.Format("EXEC SP_CAPNHAT_LOPTINCHI N'{0}','{1}',N'{2}','{3}', N'{4}','{5}',N'{6}','{7}', N'{8}', N'{9}', '{10}', {11}",
                       nienKhoa, hocKy, maMH, nhom, maGV, maKhoa, ssvtt, huyLop, new_nienKhoa, new_hocKy, new_maMH, new_nhom);
                    int resultEdit = Program.ExecSqlNonQuery(spEdit);
                    if (resultEdit != 0)
                    {
                        MessageBox.Show("Hoàn tác cập nhật lớp tín chỉ không thành công!");
                    }
                    LoadDatasetApdapter();
                    break;

                case STATE_ACTION.DELETE:
                    LOPTINCHITableAdapter.Insert(
                        action.NienKhoa,
                        action.HocKy,
                        action.MaMH,
                        action.Nhom,
                        action.MaGV,
                        action.MaKhoa,
                        action.SSVTT,
                        action.HuyLop
                        );
                    LOPTINCHITableAdapter.Fill(DS.LOPTINCHI);
                    break;
                default:
                    break;
            }
            currentAction = STATE_ACTION.NONE;
            LoadUndo();
        }

        private void dgvLTC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvLTC.Columns[e.ColumnIndex].Name == "MAGV_TEXT")
            {
                string maGV = dgvLTC.Rows[e.RowIndex].Cells["MAGV"].Value.ToString();
                DS.GIANGVIENRow gvRow = DS.GIANGVIEN.FindByMAGV(maGV);
                if (gvRow != null)
                {
                    e.Value = gvRow.HO + " " + gvRow.TEN;
                }
                else
                {
                    e.Value = "Chưa có giảng viên";
                }
            }

            if (dgvLTC.Columns[e.ColumnIndex].Name == "MAMH_TEXT")
            {
                string maMH = dgvLTC.Rows[e.RowIndex].Cells["MAMH"].Value.ToString();
                DS.MONHOCRow mhRow = DS.MONHOC.FindByMAMH(maMH);
                if (mhRow != null)
                {
                    e.Value = mhRow.TENMH;
                }
                else
                {
                    e.Value = "Chưa có môn học";
                }
            }
        }

        private bool ValidateOpenCourse()
        {
            if (string.IsNullOrWhiteSpace(txtNienKhoa.Text))
            {
                lblMessage.Text = "Vui lòng nhập Niên Khóa.";
                txtNienKhoa.Focus();
                return false;
            }


            
            // Học kỳ
            if (nudHocKy.Value < 1 || nudHocKy.Value > 4)
            {
                lblMessage.Text = "Học Kỳ phải từ 1 đến 4.";
                nudHocKy.Focus();
                return false;
            }

            // Môn học
            if (cmbMaMH.SelectedIndex < 0)
            {
                lblMessage.Text = "Vui lòng chọn Môn Học.";
                cmbMaMH.DroppedDown = true;
                return false;
            }

            // Nhóm
            if (nudNhom.Value < 1)
            {
                lblMessage.Text = "Nhóm phải lớn hơn hoặc bằng 1.";
                nudNhom.Focus();
                return false;
            }

            // Giáo viên
            if (cmbGV.SelectedIndex < 0)
            {
                lblMessage.Text = "Vui lòng chọn Giáo Viên.";
                cmbGV.DroppedDown = true;
                return false;
            }

            // Số sinh viên tối thiểu
            if (nudSOSVTT.Value < 1)
            {
                lblMessage.Text = "Số Sinh Viên Tối Thiểu phải lớn hơn hoặc bằng 1.";
                nudSOSVTT.Focus();
                return false;
            }

            // Nếu mọi thứ OK
            lblMessage.Text = "";
            return true;
        }

        private void dtpBeigin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBeigin.Value.Year >= dtpEnd.Value.Year)
            {
                dtpEnd.Value = new DateTime(dtpBeigin.Value.Year + 1, 1, 1);
            }
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Year <= dtpBeigin.Value.Year)
            {
                dtpBeigin.Value = new DateTime(dtpEnd.Value.Year - 1, 1, 1);
            }
            txtNienKhoa.Text = dtpBeigin.Value.Year + "-" + dtpEnd.Value.Year;
        }

        private void txtNienKhoa_TextChanged(object sender, EventArgs e)
        {
            if (txtNienKhoa.Text == "") return;

            string khoahoc = txtNienKhoa.Text;
            string[] arr = khoahoc.Split('-');
            int yBegin = int.Parse(arr[0].Trim());
            int yEnd = int.Parse(arr[1].Trim());

            dtpBeigin.Value = new DateTime(yBegin, 1, 1);
            dtpEnd.Value = new DateTime(yEnd, 1, 1);
        }
    }

    class ActionOpenCourse
    {
        public STATE_ACTION Action { get; set; }
        public string NienKhoa { get; set; }
        public int HocKy { get; set; }
        public string MaMH { get; set; }
        public int Nhom { get; set; }
        public string MaGV { get; set; }
        public string MaKhoa { get; set; }
        public int SSVTT { get; set; }
        public bool HuyLop { get; set; }
        public string newNienKhoa { get; set; }
        public int? newHocKy { get; set; }
        public string newMaMH { get; set; }
        public int? newNhom { get; set; }

        public ActionOpenCourse(STATE_ACTION action, string nienKhoa, int hocKy, string maMH, int nhom, string maGV, string maKhoa, int sSVTT, bool huyLop, string newNienKhoa=null, int? newHocKy=null, string newMaMH = null, int? newNhom = null)
        {
            this.Action = action;
            this.NienKhoa = nienKhoa;
            this.HocKy = hocKy;
            this.MaMH = maMH;
            this.Nhom = nhom;
            this.MaGV = maGV;
            this.MaKhoa = maKhoa;
            this.SSVTT = sSVTT;
            this.HuyLop = huyLop;
            this.newNienKhoa = newNienKhoa;
            this.newHocKy = newHocKy;
            this.newMaMH = newMaMH;
            this.newNhom = newNhom;
        }
    }
}
