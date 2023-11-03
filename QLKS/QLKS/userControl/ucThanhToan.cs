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
    public partial class ucThanhToan : UserControl
    {
        public ucThanhToan()
        {
            InitializeComponent();
            LoadGrdThuePhong();
            LoadGrdHoaDon();
            SetControl("Reset");
        }
        #region Connect UC
        public static ucThanhToan _instrance;
        public static ucThanhToan Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucThanhToan();
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

        public void LoadGrdThuePhong()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT MA_PHIEUTHUE, TEN_KHACHHANG, SDT, TONG_NGUOI, MA_PHONG_THUE, NGAY_NHAN_PHONG, NGAY_TRA_PHONG, TIEN_COC  FROM DM_THUEPHONG WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdThuePhong.DataSource = ds.Tables[0];
            }
            else
            {
                grdThuePhong.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BindingDataThuePhong();
        }
        public void BindingDataThuePhong()
        {
            txtMaPhieuThue.DataBindings.Clear();
            txtDatCoc.DataBindings.Clear();
            dtpNgayNhanPhong.DataBindings.Clear();
            dtpNgayTraPhong.DataBindings.Clear();

            txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
            txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_COC", false, DataSourceUpdateMode.Never));
            dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
            dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));
        }
        public void LoadGrdSDDV()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "THANHTOAN_SDDV";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
            cmd.CommandType = CommandType.StoredProcedure;
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
        }
        public void LoadGrdHoaDon()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT *  FROM HOA_DON WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdHoaDon.DataSource = ds.Tables[0];
            }
            else
            {
                grdHoaDon.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BanGhi();
            BindingDataHoaDon();
        }
        public void BindingDataHoaDon()
        {
            txtID.DataBindings.Clear();
            txtMaPhieuThue.DataBindings.Clear();
            txtDatCoc.DataBindings.Clear();
            dtpNgayNhanPhong.DataBindings.Clear();
            dtpNgayTraPhong.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();

            txtNgayThue.DataBindings.Clear();
            txtTienDV.DataBindings.Clear();
            txtTienPhong.DataBindings.Clear();
            txtTongTien.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID", false, DataSourceUpdateMode.Never));
            txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
            txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "DAT_COC", false, DataSourceUpdateMode.Never));
            dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
            dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));

            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));

            txtNgayThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_THUE", false, DataSourceUpdateMode.Never));
            txtTienDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_DV", false, DataSourceUpdateMode.Never));
            txtTienPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_PHONG", false, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_TIEN", false, DataSourceUpdateMode.Never));


        }
        public void BanGhi()
        {
            lblBanGhi.Text = "Tổng số bản ghi: " + ds.Tables[0].Rows.Count.ToString() + " bản ghi";
        }
        public void Clear()
        {
            txtID.Text = "";
            txtMaPhieuThue.Text = "";
            txtDatCoc.Text = "";
            dtpNgayNhanPhong.Value = DateTime.Now;
            dtpNgayTraPhong.Value = DateTime.Now;
            txtNgayThue.Text = "";
            txtTienDV.Text = "";
            txtTienPhong.Text = "";
            txtTongTien.Text = "";

            txtNguoiTao.Text = "";
            txtNguoiSua.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySua.Value = DateTime.Now;
            txtGhiChu.Text = "";
        }
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
                    btnTimKiemPhieuThue.Enabled = true;
                    btnTimKiemHoaDon.Enabled = true;
                    btnTimKiem.Enabled = false;
                    btnInHoaDon.Enabled = true;

                    txtID.Enabled = false;
                    txtMaPhieuThue.Enabled = false;
                    txtDatCoc.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = false;
                    txtNgayThue.Enabled = false;
                    txtTienDV.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtTongTien.Enabled = false;

                    txtGhiChu.Enabled = false;
                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    txtID.Focus();

                    break;

                case "Insert":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTimKiemPhieuThue.Enabled = false;
                    btnTimKiemHoaDon.Enabled = false;
                    btnTimKiem.Enabled = false;
                    btnInHoaDon.Enabled = false;

                    txtID.Enabled = false;
                    txtMaPhieuThue.Enabled = false;
                    txtDatCoc.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = true;
                    txtNgayThue.Enabled = false;
                    txtTienDV.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtTongTien.Enabled = false;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    //dtpNgayTraPhong.Value = DateTime.Now;
                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtID.Focus();

                    break;

                case "Update":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTimKiemPhieuThue.Enabled = false;
                    btnTimKiemHoaDon.Enabled = false;
                    btnTimKiem.Enabled = false;
                    btnInHoaDon.Enabled = false;

                    txtID.Enabled = false;
                    txtMaPhieuThue.Enabled = false;
                    txtDatCoc.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = true;
                    txtNgayThue.Enabled = false;
                    txtTienDV.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtTongTien.Enabled = false;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgayTraPhong.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtID.Focus();

                    break;
                case "Delete":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = false;
                    btnTimKiemPhieuThue.Enabled = false;
                    btnTimKiemHoaDon.Enabled = false;
                    btnTimKiem.Enabled = false;
                    btnInHoaDon.Enabled = false;

                    txtID.Enabled = false;
                    txtMaPhieuThue.Enabled = false;
                    txtDatCoc.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = false;
                    txtNgayThue.Enabled = false;
                    txtTienDV.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtTongTien.Enabled = false;

                    txtGhiChu.Enabled = false;
                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgayTraPhong.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtID.Focus();

                    break;
                case "SearchPhieuThue":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = true;
                    
                    btnTimKiemPhieuThue.Enabled = false;
                    btnTimKiemHoaDon.Enabled = false;
                    btnTimKiem.Enabled = true;
                    btnInHoaDon.Enabled = false;


                    txtID.Enabled = false;
                    txtMaPhieuThue.Enabled = true;
                    txtDatCoc.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = false;
                    txtNgayThue.Enabled = false;
                    txtTienDV.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtTongTien.Enabled = false;

                    txtGhiChu.Enabled = false;
                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    break;
                case "SearchHoaDon":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = true;

                    btnTimKiemPhieuThue.Enabled = false;
                    btnTimKiemHoaDon.Enabled = true;
                    btnTimKiem.Enabled = true;
                    btnInHoaDon.Enabled = true;


                    txtID.Enabled = true;
                    txtMaPhieuThue.Enabled = true;
                    txtDatCoc.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtNgayThue.Enabled = true;
                    txtTienDV.Enabled = true;
                    txtTienPhong.Enabled = true;
                    txtTongTien.Enabled = true;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;

                    break;
                default:
                    break;
            }
        }
        public bool CheckExits(String MA_PHIEUTHUE)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sqlCheck = "CHECK_EXITS_HOADON_DV";
                SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", MA_PHIEUTHUE);
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
        public void InsertData()
        {
            try
            {
                bool cExits = false;
                cExits = CheckExits(txtMaPhieuThue.Text.Trim());
                if (cExits == true ) //không sddv
                {
                    string sqlInsert = "INSERT_HOADON_SDDV_0";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                    //cmd.Parameters.Add("@DAT_COC", SqlDbType.Int).Value = Convert.ToInt32(txtDatCoc.Text);
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdHoaDon();
                        lblThongBao.Text = "Thêm thành công!";
                        Clear();
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể thêm!";
                    }
                }
                else
                {
                    string sqlInsert = "INSERT_HOADON";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                    //cmd.Parameters.Add("@DAT_COC", SqlDbType.Int).Value = Convert.ToInt32(txtDatCoc.Text);
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdHoaDon();
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
        public void UpdateData()
        {
            try
            {
                bool cExits = false;
                cExits = CheckExits(txtMaPhieuThue.Text.Trim());
                if (cExits == true)//không sddv 
                {
                    string sqlInsert = "UPADTE_HOADON_SDDV_0";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdHoaDon();
                        lblThongBao.Text = "Sửa thành công!";
                        Clear();
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể sửa!";
                    }

                }
                else
                {
                    string sqlInsert = "UPADTE_HOADON";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        LoadGrdHoaDon();
                        lblThongBao.Text = "Sửa thành công!";
                        Clear();
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể sửa!";
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
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string sqlDelete = "DELETE_HOADON";
                    SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                    cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        Clear();
                        LoadGrdHoaDon();
                        SetControl("Reset");
                        lblThongBao.Text = "Đã xóa";
                    }
                }
                else
                {
                    Clear();
                    SetControl("Reset");
                    BindingDataHoaDon();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void SearchThuePhongData()
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

                string sqlSearch = "[SEARCH_PHIEUTHUE]";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);
                cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdThuePhong.DataSource = ds.Tables[0];

                txtMaPhieuThue.DataBindings.Clear();
                txtDatCoc.DataBindings.Clear();
                dtpNgayNhanPhong.DataBindings.Clear();
                dtpNgayTraPhong.DataBindings.Clear();

                txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
                txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_COC", false, DataSourceUpdateMode.Never));
                dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
                dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));

                grdThuePhong.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        public void SearchHoaDonData()
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

                string sqlInsert = "SEARCH_HOADON_DATA";
                SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                cmd.Parameters.AddWithValue("@NGAY_THUE", txtNgayThue.Text.Trim());
                cmd.Parameters.AddWithValue("@TIEN_DV", txtTienDV.Text.Trim());
                cmd.Parameters.AddWithValue("@TIEN_PHONG", txtTienPhong.Text.Trim());
                cmd.Parameters.AddWithValue("@TONG_TIEN", txtTongTien.Text.Trim());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdHoaDon.DataSource = ds.Tables[0];

                txtID.DataBindings.Clear();
                txtMaPhieuThue.DataBindings.Clear();
                txtDatCoc.DataBindings.Clear();
                dtpNgayNhanPhong.DataBindings.Clear();
                dtpNgayTraPhong.DataBindings.Clear();
                txtGhiChu.DataBindings.Clear();

                txtNguoiTao.DataBindings.Clear();
                txtNguoiSua.DataBindings.Clear();
                dtpNgayTao.DataBindings.Clear();
                dtpNgaySua.DataBindings.Clear();

                txtNgayThue.DataBindings.Clear();
                txtTienDV.DataBindings.Clear();
                txtTienPhong.DataBindings.Clear();
                txtTongTien.DataBindings.Clear();




                txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID", false, DataSourceUpdateMode.Never));
                txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
                txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "DAT_COC", false, DataSourceUpdateMode.Never));
                dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
                dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));
                txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));

                txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
                txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
                dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
                dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));

                txtNgayThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_THUE", false, DataSourceUpdateMode.Never));
                txtTienDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_DV", false, DataSourceUpdateMode.Never));
                txtTienPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_PHONG", false, DataSourceUpdateMode.Never));
                txtTongTien.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_TIEN", false, DataSourceUpdateMode.Never));





                //Biding data
                grdHoaDon.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        private void grdThuePhong_MouseDown(object sender, MouseEventArgs e)
        {
            LoadGrdSDDV();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                txtNgayThue.Text = "";
                txtTienDV.Text = "";
                txtTienPhong.Text = "";
                txtTongTien.Text = "";

                Status = "Insert";
                SetControl(Status);
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
            if (Status == "Insert" )
            {
                InsertData();
                return;
            }
            else if (Status == "Update")
            {
                UpdateData();
            }
        }

        private void btnHuyBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
            LoadGrdHoaDon();
            LoadGrdThuePhong();
            Status = "Reset";
            SetControl(Status);
        }

        private void btnTimKiemPhieuThue_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                Status = "SearchPhieuThue";
                SetControl(Status);
                
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
                if (Status == "SearchPhieuThue")
                {
                    SearchThuePhongData();
                    Status = "Insert";
                    SetControl(Status);
                }
                else if (Status == "SearchHoaDon")
                {
                    SearchHoaDonData();
                }
                

            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnTimKiemHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                LoadGrdHoaDon();
                Status = "SearchHoaDon";
                SetControl(Status);

            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnInHoaDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String p_ID = txtID.Text;
            //string p_MaPhieuThue = txtMaPhieuThue.Text;
            //string p_DatCoc = txtDatCoc.Text;
            //DateTime p_NgayNhanPhong = Convert.ToDateTime(dtpNgayNhanPhong.Value);
            //DateTime p_NgayTraPhong = Convert.ToDateTime(dtpNgayTraPhong.Value);
            //string p_NgayThue = txtNgayThue.Text;
            //string p_TienDV = txtTienDV.Text;
            //string p_TienPhong = txtTienPhong.Text;
            //string p_TongTien = txtTongTien.Text;

            //HoaDonTong frm = new HoaDonTong(p_ID, p_MaPhieuThue, p_DatCoc, p_NgayNhanPhong, p_NgayTraPhong, p_NgayThue, p_TienDV, p_TienPhong, p_TongTien);
            //HoaDon frm = new HoaDon(p_ID, p_MaPhieuThue, p_DatCoc, p_NgayNhanPhong, p_NgayTraPhong, p_NgayThue, p_TienDV, p_TienPhong, p_TongTien);

            HoaDon frm = new HoaDon(p_ID);
            frm.Show();
        }

        private void groupControl4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grdThuePhong_Click(object sender, EventArgs e)
        {

        }
    }
}
