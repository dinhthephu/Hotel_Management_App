using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLKS.Report;

namespace QLKS.userControl
{
    public partial class ucSDDV : UserControl
    {
        public ucSDDV()
        {
            InitializeComponent();
            LoadCboDichVu();
            LoadCboPhieuThue();
            LoadGrdDV();
            LoadGrdSDDV();
            SetControl("Reset");
        }

        #region Connect UC
        public static ucSDDV _instrance;
        public static ucSDDV Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucSDDV();
                return _instrance;
            }
        }
        #endregion

        #region Variables
        public static string Status = "";
        public static string ConnectionString = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        SqlConnection conn;
        public static DataSet ds;
        #endregion

        #region Public Function
        public void SetControl(string Status)
        {
            switch (Status)
            {
                case "Reset":

                    lblThongBao.Text = "";

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = false;
                    btnTT_TimKiem.Enabled = true;
                    btnTimKiem.Enabled = false;

                    txtMaHDDV.Enabled = false;
                    cboMaPhieuThue.Enabled = false;
                    txtSoLuong.Enabled = false;
                    dtpNgaySuDung.Enabled = false;
                    txtTongTien.Enabled = false;
                    cboDV.Enabled = false;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    txtMaHDDV.Focus();

                    break;

                case "Insert":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTT_TimKiem.Enabled = false;
                    btnTimKiem.Enabled = false;

                    txtMaHDDV.Enabled = true;
                    cboMaPhieuThue.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtTongTien.Enabled = false;
                    dtpNgaySuDung.Enabled = true;
                    cboDV.Enabled = true;

                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySuDung.Value = DateTime.Now;
                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtMaHDDV.Focus();

                    break;

                case "Update":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTT_TimKiem.Enabled = false;
                    btnTimKiem.Enabled = false;
                    btnTimKiem.Enabled = true;

                    txtMaHDDV.Enabled = false;
                    cboMaPhieuThue.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtTongTien.Enabled = false;
                    dtpNgaySuDung.Enabled = true;
                    cboDV.Enabled = true;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySua.Value = DateTime.Now;

                    txtMaHDDV.Focus();

                    break;
                case "Delete":

                    lblThongBao.Text = "";

                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTT_TimKiem.Enabled = true;
                    btnTimKiem.Enabled = true;


                    txtMaHDDV.Enabled = true;
                    cboMaPhieuThue.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtTongTien.Enabled = true;
                    dtpNgaySuDung.Enabled = true;
                    cboDV.Enabled = true;

                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;

                    break;
                case "Search":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = true;
                    btnTT_TimKiem.Enabled = true;
                    btnTimKiem.Enabled = true;


                    txtMaHDDV.Enabled = false;
                    cboMaPhieuThue.Enabled = true;
                    txtSoLuong.Enabled = false;
                    txtTongTien.Enabled = false;
                    dtpNgaySuDung.Enabled = false;
                    cboDV.Enabled = false;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySuDung.Value = DateTime.Now.AddYears(-5);
                    dtpNgayTao.Value = DateTime.Now.AddYears(-5);
                    dtpNgaySua.Value = DateTime.Now;

                    break;
                default:
                    break;
            }
        }
        public void LoadGrdDV()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT MA_DV, TEN_DV, MA_LOAI_DV, ANH, GIA_DV, DON_VI_TINH,SO_LUONG_KHO   FROM DM_DICHVU WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDV.DataSource = ds.Tables[0];
            }
            else
            {
                grdDV.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BanGhi();
            //BindingData();
        }
        public void LoadGrdSDDV()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT * FROM QL_SUDUNG_DICHVU WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdSDDV.DataSource = ds.Tables[0];
            }
            else
            {
                grdSDDV.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BanGhi();
            BindingData();
        }
        public void LoadCboDichVu()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_DICHVU WHERE TRANG_THAI = '1'  ";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_DV"] = "";
                dr["TEN_DV"] = "---Chọn dịch vụ---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboDV.DataSource = ds.Tables[0];
                cboDV.DisplayMember = "TEN_DV";
                cboDV.ValueMember = "MA_DV";
                cboDV.SelectedItem = 0;
            }

            else
            {
                cboDV.DataSource = null;

            }
        }
        public void LoadCboPhieuThue()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_THUEPHONG WHERE TRANG_THAI = '1'  ";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_PHIEUTHUE"] = "---Chọn mã phiếu thuê---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboMaPhieuThue.DataSource = ds.Tables[0];
                cboMaPhieuThue.DisplayMember = "MA_PHIEUTHUE";
                cboMaPhieuThue.ValueMember = "MA_PHIEUTHUE";
                cboMaPhieuThue.SelectedItem = 0;
            }

            else
            {
                cboMaPhieuThue.DataSource = null;

            }
        }
        public void BanGhi()
        {
            lblBanGhi.Text = "Tổng số bản ghi: " + ds.Tables[0].Rows.Count.ToString() + " bản ghi";
        }
        public void BindingData()
        {
            txtMaHDDV.DataBindings.Clear();
            cboMaPhieuThue.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();

            cboDV.DataBindings.Clear();
            txtTongTien.DataBindings.Clear();
            dtpNgaySuDung.DataBindings.Clear();

            txtMaHDDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_HDDV", false, DataSourceUpdateMode.Never));
            cboMaPhieuThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", ds.Tables[0], "SO_LUONG", false, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_TIEN", false, DataSourceUpdateMode.Never));
            dtpNgaySuDung.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SD", false, DataSourceUpdateMode.Never));
            //cboLoaiDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_LOAI_DV", false, DataSourceUpdateMode.Never));
            cboDV.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_DICHVU", false, DataSourceUpdateMode.Never));
            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
        }
        public void Clear()
        {
            txtMaHDDV.Text = "";
            cboMaPhieuThue.Text = "";
            txtSoLuong.Text = "";
            txtTongTien.Text = "";
            dtpNgaySuDung.Value = DateTime.Now;
            txtNguoiTao.Text = "";
            txtNguoiSua.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySua.Value = DateTime.Now;
        }
        public void InsertData()
        {
            try
            {
                if (txtMaHDDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã hóa đơn dịch vụ";
                    txtMaHDDV.Focus();
                }
                else if (cboMaPhieuThue.SelectedValue == "---Chọn mã phiếu thuê---")
                {
                    lblThongBao.Text = "Nhập vào mã phiếu thuê";
                    cboMaPhieuThue.Focus();
                }
                else if (cboDV.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào dịch vụ";
                    cboDV.Focus();
                }
                else if (txtSoLuong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng";
                    txtSoLuong.Focus();
                }
                else
                {
                    string sqlInsert = "INSERT_QL_SUDUNG_DICHVU";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_HDDV", txtMaHDDV.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", cboMaPhieuThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MA_DICHVU", cboDV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SD", dtpNgaySuDung.Value);
                    cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdSDDV();
                        lblThongBao.Text = "Thêm thành công!";
                        Clear();
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể thêm!";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void UpdateSLDV()
        {
            try
            {
                    string sqlUpdate = "UPADTE_SOLUONG_DICH_VU";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_DICHVU", cboDV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdDV();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public bool CheckExits(String MA_HDDV)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sqlCheck = "[CHECK_EXITS_SDDV]";
                SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MA_HDDV", MA_HDDV);
                DataSet dsCheck = new DataSet();
                da.Fill(dsCheck);
                if (dsCheck != null && dsCheck.Tables.Count > 0 && dsCheck.Tables[0].Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
                return true;
            }
        }
        public void UpdateData()
        {
            try
            {
                if (txtMaHDDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã hóa đơn dịch vụ";
                    txtMaHDDV.Focus();
                }
                else if (cboMaPhieuThue.SelectedValue == "---Chọn mã phiếu thuê---")
                {
                    lblThongBao.Text = "Nhập vào mã phiếu thuê";
                    cboMaPhieuThue.Focus();
                }
                else if (cboDV.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào dịch vụ";
                    cboDV.Focus();
                }
                else if (txtSoLuong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng";
                    txtSoLuong.Focus();
                }
                else
                {
                    string sqlUpdate = "UPADTE_QL_SUDUNG_DICHVU";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_HDDV", txtMaHDDV.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", cboMaPhieuThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MA_DICHVU", cboDV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SD", dtpNgaySuDung.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    //cmd.Parameters.AddWithValue("@TONG_TIEN_DV", txtTongTien.Text.Trim());

                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdSDDV();
                        lblThongBao.Text = "Sửa thành công!";
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể Sửa!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void DeleteData()
        {
            try
            {
                if (txtMaHDDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã loại dịch vụ";
                    txtMaHDDV.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlDelete = "DELETE_QL_SUDUNG_DICHVU";
                        SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                        cmd.Parameters.AddWithValue("@MA_HDDV", txtMaHDDV.Text.Trim());
                        cmd.CommandType = CommandType.StoredProcedure;
                        var result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Clear();
                            LoadGrdSDDV();
                            SetControl("Reset");
                            lblThongBao.Text = "Đã xóa";
                        }
                    }
                    else
                    {
                        Clear();
                        SetControl("Reset");
                        BindingData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void SearchData()
        {
            try
            {

                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();
                SqlConnection con = new SqlConnection(ConnectionString);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string sqlSearch = "SEARCH_HD_SUDUNG_DICHVU";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);
                cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", cboMaPhieuThue.SelectedValue.ToString());
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                grdSDDV.DataSource = ds.Tables[0];
                grdSDDV.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        #endregion
        #region Events
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                Status = "Insert";
                SetControl(Status);
                LoadCboDichVu();
                LoadCboPhieuThue();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Status = "Update";
                SetControl(Status);
                //LoadCboDichVu();
                //LoadCboPhieuThue();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Status = "Delete";
                SetControl(Status);
                DeleteData();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Status == "Insert")
            {
                bool cExits = false;
                cExits = CheckExits(txtMaHDDV.Text.Trim());
                if (cExits == false)
                {
                    lblThongBao.Text = "Đã tồn tại mã hóa đơn dịch vụ: " + txtMaHDDV.Text.Trim() + " trong hệ thống";
                    return;
                }
                UpdateSLDV();
                InsertData();
            }
            else if (Status == "Update")
            {
                UpdateSLDV();
                UpdateData();
            }
        }

        private void btnHuyBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
            LoadGrdSDDV();
            Status = "Reset";
            SetControl(Status);
        }

        private void btnTT_TimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                Status = "Search";
                SetControl(Status);
                LoadCboDichVu();
                LoadCboPhieuThue();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

        private void btnTimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                SearchData();
                LoadCboDichVu();
                LoadCboPhieuThue();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnInHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String p_MaHDDV = txtMaHDDV.Text;
            string p_MaPhieuThue = cboMaPhieuThue.SelectedValue.ToString();
            string p_DichVu = cboDV.SelectedValue.ToString();
            String p_SoLuong = txtSoLuong.Text;
            DateTime p_NgaySuDung = Convert.ToDateTime(dtpNgaySuDung.Value);
            String p_TongTien = txtTongTien.Text;

            HoaDonDichVu frm = new HoaDonDichVu(p_MaHDDV, p_MaPhieuThue, p_DichVu, p_SoLuong, p_NgaySuDung, p_TongTien);

            frm.Show();
        }
        #endregion

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
