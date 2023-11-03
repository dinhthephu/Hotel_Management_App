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
using System.IO;

namespace QLKS.userControl
{
    public partial class ucDM_Phong : UserControl
    {
        public ucDM_Phong()
        {
            InitializeComponent();
            LoadCboLoaiPhong();
            LoadCboTrangThaiPhong();
            LoadGrd();
            SetControl("Reset");
        }

        #region Connect UC
        public static ucDM_Phong _instrance;
        public static ucDM_Phong Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDM_Phong();
                return _instrance;
            }
        }
        #endregion

        #region Variables
            public static string Status = "";
            public static string ConnectionString = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        SqlConnection conn;
            public static DataSet ds;
            byte[] arrImage;
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
                        btnXuatExcel.Enabled = false;
                        btnChonFileAnh.Enabled = false;

                        txtMaPhong.Enabled = false;
                        txtTenPhong.Enabled = false;
                        txtGiaPhong.Enabled = false;
                        txtViTri.Enabled = false;
                        txtDienTich.Enabled = false;
                        txtMoTa.Enabled = false;
                        txtGhiChu.Enabled = false;
                        cboLoaiPhong.Enabled = false;
                        cboTrangThaiPhong.Enabled = false;
                        txtDuongDanAnh.Enabled = false;
                    
                        txtNguoiTao.Enabled = false;
                        txtNguoiSua.Enabled = false;
                        dtpNgayTao.Enabled = false;
                        dtpNgaySua.Enabled = false;

                        txtMaPhong.Focus();

                        break;

                    case "Insert":

                        lblThongBao.Text = "";

                        btnThem.Enabled = false;
                        btnSua.Enabled = false;
                        btnXoa.Enabled = false;
                        btnGhi.Enabled = true;
                        btnHuyBo.Enabled = true;
                        btnTT_TimKiem.Enabled = false;
                        btnChonFileAnh.Enabled = true;
                        btnXuatExcel.Enabled = false;
                        btnTimKiem.Enabled = false;

                        txtMaPhong.Enabled = true;
                        txtTenPhong.Enabled = true;
                        txtGiaPhong.Enabled = true;
                        txtViTri.Enabled = true;
                        txtDienTich.Enabled = true;
                        txtMoTa.Enabled = true;
                        txtGhiChu.Enabled = true;
                        cboLoaiPhong.Enabled = true;
                        cboTrangThaiPhong.Enabled = true;
                        txtDuongDanAnh.Enabled = true;
                        picMain.Image = null;

                        txtNguoiTao.Enabled = true;
                        txtNguoiSua.Enabled = false;
                        dtpNgayTao.Enabled = false;
                        dtpNgaySua.Enabled = false;
                        picMain.Image = null;

                        dtpNgayTao.Value = DateTime.Now;
                        dtpNgaySua.Value = DateTime.Now;

                        txtMaPhong.Focus();

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
                        btnXuatExcel.Enabled = false;
                        btnTimKiem.Enabled = false;

                        txtMaPhong.Enabled = false;
                        txtTenPhong.Enabled = true;
                        txtGiaPhong.Enabled = true;
                        txtViTri.Enabled = true;
                        txtDienTich.Enabled = true;
                        txtMoTa.Enabled = true;
                        txtGhiChu.Enabled = true;
                        cboLoaiPhong.Enabled = true;
                        cboTrangThaiPhong.Enabled = true;
                        txtDuongDanAnh.Enabled = true;
                        btnChonFileAnh.Enabled = true;
                        txtNguoiTao.Enabled = false;
                        txtNguoiSua.Enabled = true;
                        dtpNgayTao.Enabled = false;
                        dtpNgaySua.Enabled = false;

                        dtpNgaySua.Value = DateTime.Now;

                        txtMaPhong.Focus();

                        break;
                    case "Delete":

                        lblThongBao.Text = "";

                        btnThem.Enabled = true;
                        btnSua.Enabled = true;
                        btnXoa.Enabled = true;
                        btnGhi.Enabled = true;
                        btnHuyBo.Enabled = true;
                        btnTT_TimKiem.Enabled = true;
                        btnXuatExcel.Enabled = false;
                        btnTimKiem.Enabled = true;


                        txtMaPhong.Enabled = true;
                        txtTenPhong.Enabled = true;
                        txtGiaPhong.Enabled = true;
                        txtViTri.Enabled = true;
                        txtDienTich.Enabled = true;
                        txtMoTa.Enabled = true;
                        txtGhiChu.Enabled = true;
                        cboLoaiPhong.Enabled = true;
                        cboTrangThaiPhong.Enabled = true;
                        txtDuongDanAnh.Enabled = true;
                    
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
                        btnXuatExcel.Enabled = true;
                        btnChonFileAnh.Enabled = true;
                        btnTimKiem.Enabled = true;


                        txtMaPhong.Enabled = true;
                        txtTenPhong.Enabled = true;
                        txtGiaPhong.Enabled = true;
                        txtViTri.Enabled = true;
                        txtDienTich.Enabled = true;
                        txtMoTa.Enabled = true;
                        txtGhiChu.Enabled = true;
                        cboLoaiPhong.Enabled = true;
                        cboTrangThaiPhong.Enabled = true;
                        txtDuongDanAnh.Enabled = true;

                        txtNguoiTao.Enabled = true;
                        txtNguoiSua.Enabled = true;
                        dtpNgayTao.Enabled = true;
                        dtpNgaySua.Enabled = true;
                        picMain.Image = null;

                        dtpNgayTao.Value = DateTime.Now.AddYears(-5);
                        dtpNgaySua.Value = DateTime.Now;

                        break;
                    default:
                        break;
                }
            }

            public void LoadGrd()
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "SELECT * FROM DM_PHONG WHERE TRANG_THAI = '1'  ";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    grdPhong.DataSource = ds.Tables[0];
                }
                else
                {
                    grdPhong.DataSource = null;
                    lblBanGhi.Text = "Tổng số: 0 bản ghi";
                }
                BanGhi();
                BindingData();
            }

            public void LoadCboLoaiPhong()
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string Insert_Cbo = "SELECT * FROM DM_LOAIPHONG WHERE TRANG_THAI = '1'  ";
                SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["MA_LOAI_PHONG"] = "";
                    dr["TEN_LOAI_PHONG"] = "---Chọn loại phòng---";
                    ds.Tables[0].Rows.InsertAt(dr, 0);

                    cboLoaiPhong.DataSource = ds.Tables[0];
                    cboLoaiPhong.DisplayMember = "TEN_LOAI_PHONG";
                    cboLoaiPhong.ValueMember = "MA_LOAI_PHONG";
                    cboLoaiPhong.SelectedItem = 0;
                }

                else
                {
                    cboLoaiPhong.DataSource = null;

                }
            }

            public void LoadCboTrangThaiPhong()
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string Insert_Cbo = "SELECT * FROM TRANG_THAI_PHONG WHERE TRANG_THAI = '1'  ";
                SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
                SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr;
                    dr = ds.Tables[0].NewRow();
                    dr["MA_TRANGTHAI"] = "";
                    dr["TEN_TRANGTHAI"] = "---Chọn trạng thái phòng---";
                    ds.Tables[0].Rows.InsertAt(dr, 0);

                    cboTrangThaiPhong.DataSource = ds.Tables[0];
                    cboTrangThaiPhong.DisplayMember = "TEN_TRANGTHAI";
                    cboTrangThaiPhong.ValueMember = "MA_TRANGTHAI";
                    cboTrangThaiPhong.SelectedItem = 0;
                }

                else
                {
                    cboTrangThaiPhong.DataSource = null;

                }
            }

            public void LoadImg()
            {
                if (txtDuongDanAnh.Text != null && txtDuongDanAnh.Text.Trim() != "")
                {
                    Image img = Image.FromFile(txtDuongDanAnh.Text.Trim());
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        arrImage = ms.ToArray();
                    }
                }
            }

            public void BanGhi()
            {
                lblBanGhi.Text = "Tổng số bản ghi: " + ds.Tables[0].Rows.Count.ToString() + " bản ghi";
            }

            public void BindingData()
            {
                txtMaPhong.DataBindings.Clear();
                txtTenPhong.DataBindings.Clear();
                txtGiaPhong.DataBindings.Clear();
                txtViTri.DataBindings.Clear();
                txtDienTich.DataBindings.Clear();
                txtDuongDanAnh.DataBindings.Clear();

                txtNguoiTao.DataBindings.Clear();
                txtNguoiSua.DataBindings.Clear();
                dtpNgayTao.DataBindings.Clear();
                dtpNgaySua.DataBindings.Clear();

                cboLoaiPhong.DataBindings.Clear();
                cboTrangThaiPhong.DataBindings.Clear();
                txtMoTa.DataBindings.Clear();
                txtGhiChu.DataBindings.Clear();
                picMain.DataBindings.Clear();

                txtMaPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHONG", false, DataSourceUpdateMode.Never));
                txtTenPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_PHONG", false, DataSourceUpdateMode.Never));
                txtGiaPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "GIA_PHONG", false, DataSourceUpdateMode.Never));
                txtViTri.DataBindings.Add(new Binding("Text", ds.Tables[0], "VI_TRI", false, DataSourceUpdateMode.Never));
                txtDienTich.DataBindings.Add(new Binding("Text", ds.Tables[0], "DIEN_TICH", false, DataSourceUpdateMode.Never));
                txtMoTa.DataBindings.Add(new Binding("Text", ds.Tables[0], "MO_TA", false, DataSourceUpdateMode.Never));
                txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
                cboLoaiPhong.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_LOAI_PHONG", false, DataSourceUpdateMode.Never));
                cboTrangThaiPhong.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_TRANG_THAI", false, DataSourceUpdateMode.Never));
                txtDuongDanAnh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
                txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
                txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
                dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
                dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
                picMain.DataBindings.Add(new Binding("ImageLocation", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
            }

            public void Clear()
            {
                txtMaPhong.Text = "";
                txtTenPhong.Text = "";
                txtGiaPhong.Text = "";
                txtViTri.Text = "";
                txtDienTich.Text = "";
                //cboLoaiPhong.SelectedItem = 0;
                //cboTrangThaiPhong.SelectedItem = 0;
                txtDuongDanAnh.Text = "";
                txtMoTa.Text = "";
                txtGhiChu.Text = "";
                txtNguoiTao.Text = "";
                txtNguoiSua.Text = "";
                dtpNgayTao.Value = DateTime.Now;
                dtpNgaySua.Value = DateTime.Now;
                picMain.Image = null;
            }

            public void InsertData()
            {
                try
                {
                    if (txtMaPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào mã  phòng";
                        txtMaPhong.Focus();
                    }
                    else if (txtTenPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào tên phòng";
                        txtTenPhong.Focus();
                    }
                    else if (cboLoaiPhong.SelectedValue == "")
                    {
                        lblThongBao.Text = "Nhập vào loại phòng";
                        cboLoaiPhong.Focus();
                    }
                    else if(cboTrangThaiPhong.SelectedValue == "")
                    {
                        lblThongBao.Text = "Nhập vào trạng thái phòng";
                        cboTrangThaiPhong.Focus();
                    }
                    else if (txtGiaPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào giá phòng";
                        txtGiaPhong.Focus();
                    }
                    else
                    {
                        LoadImg();
                        if (txtDuongDanAnh.Text != null && txtDuongDanAnh.Text.Trim() != "")
                        {
                            string sqlInsert = "INSERT_DM_PHONG";
                            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                            cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@GIA_PHONG", txtGiaPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@VI_TRI", txtViTri.Text.Trim());
                            cmd.Parameters.AddWithValue("@DIEN_TICH", txtDienTich.Text.Trim());
                            cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                            cmd.Parameters.AddWithValue("@ANH", arrImage);
                            cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                            cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                            cmd.Parameters.AddWithValue("@MA_LOAI_PHONG", cboLoaiPhong.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@MA_TRANG_THAI", cboTrangThaiPhong.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                            cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                            cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                            cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                            cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

                            cmd.CommandType = CommandType.StoredProcedure;
                            var result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadGrd();
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
                            string sqlInsert = "INSERT_DM_PHONG";
                            SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                            cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@GIA_PHONG", txtGiaPhong.Text.Trim());
                            cmd.Parameters.AddWithValue("@VI_TRI", txtViTri.Text.Trim());
                            cmd.Parameters.AddWithValue("@DIEN_TICH", txtDienTich.Text.Trim());
                            cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                            SqlParameter imageParameter = new SqlParameter("@ANH", SqlDbType.Image);
                            imageParameter.Value = DBNull.Value;
                            cmd.Parameters.Add(imageParameter);
                            cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                            cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                            cmd.Parameters.AddWithValue("@MA_LOAI_PHONG", cboLoaiPhong.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@MA_TRANG_THAI", cboTrangThaiPhong.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                            cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                            cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                            cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                            cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

                            cmd.CommandType = CommandType.StoredProcedure;
                            var result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                LoadGrd();
                                lblThongBao.Text = "Thêm thành công!";
                                Clear();
                            }
                            else
                            {
                                lblThongBao.Text = "Không thể thêm!";
                            }
                        }
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }

            public bool CheckExits(String MA_PHONG)
            {
                try
                {
                    conn = new SqlConnection(ConnectionString);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }

                    string sqlCheck = "CHECK_EXITS_PHONG";
                    SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@MA_PHONG", MA_PHONG);
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
                    if (txtTenPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào tên phòng";
                        txtTenPhong.Focus();
                    }
                    else if (cboLoaiPhong.SelectedValue == "")
                    {
                        lblThongBao.Text = "Nhập vào loại phòng";
                        cboLoaiPhong.Focus();
                    }
                    else if (cboTrangThaiPhong.SelectedValue == "")
                    {
                        lblThongBao.Text = "Nhập vào trạng thái phòng";
                        cboTrangThaiPhong.Focus();
                    }
                    else if (txtGiaPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào giá phòng";
                        txtGiaPhong.Focus();
                    }
                    else
                    {
                        LoadImg();
                        string sqlUpdate = "UPADTE_DM_PHONG";
                        SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                        cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
                        cmd.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text.Trim());
                        cmd.Parameters.AddWithValue("@GIA_PHONG", txtGiaPhong.Text.Trim());
                        cmd.Parameters.AddWithValue("@VI_TRI", txtViTri.Text.Trim());
                        cmd.Parameters.AddWithValue("@DIEN_TICH", txtDienTich.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ANH", arrImage);
                        cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@MA_LOAI_PHONG", cboLoaiPhong.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@MA_TRANG_THAI", cboTrangThaiPhong.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.CommandType = CommandType.StoredProcedure;
                        var result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            LoadGrd();
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
                    if (txtMaPhong.Text.Trim() == "")
                    {
                        lblThongBao.Text = "Nhập vào mã loại phòng";
                        txtMaPhong.Focus();
                    }
                    else
                    {
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string sqlDelete = "DELETE_DM_PHONG";
                            SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                            cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
                            cmd.CommandType = CommandType.StoredProcedure;
                            var result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                Clear();
                                LoadGrd();
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

                    string sqlSearch = "SEARCH_DM_PHONG";
                    SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                    cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text.Trim());

                    cmd.Parameters.AddWithValue("@GIA_PHONG", txtGiaPhong.Text.Trim());
                    //cmd.Parameters.AddWithValue("@GIA_PHONG", SqlDbType.Int).Value = Convert.ToInt32(txtGiaPhong.Text);

                    cmd.Parameters.AddWithValue("@VI_TRI", txtViTri.Text.Trim());
                    cmd.Parameters.AddWithValue("@DIEN_TICH", txtDienTich.Text.Trim());
                    cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                    cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_LOAI_PHONG", cboLoaiPhong.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MA_TRANG_THAI", cboTrangThaiPhong.SelectedValue.ToString());

                    //cmd.Parameters.AddWithValue("@TRANG_THAI", SqlDbType.Int).Value = Convert.ToInt32(txtTrangThai.Text);
                
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    grdPhong.DataSource = ds.Tables[0];
                    grdPhong.Refresh();
                    cmd.Dispose();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            }

            public void ExportExcel(DataTable tb, string sheetname)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks oBooks;
            Microsoft.Office.Interop.Excel.Sheets oSheets;
            Microsoft.Office.Interop.Excel.Workbook oBook;
            Microsoft.Office.Interop.Excel.Worksheet oSheet;
            //Tạo mới một Excel WorkBook 
            oExcel.Visible = true;
            oExcel.DisplayAlerts = false;
            oExcel.Application.SheetsInNewWorkbook = 1;
            oBooks = oExcel.Workbooks;
            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
            oSheets = oBook.Worksheets;
            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
            oSheet.Name = sheetname;
            // Tạo phần đầu nếu muốn
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "N1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH CÁC PHÒNG CỦA KHÁCH SẠN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "MÃ PHÒNG";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "TÊN PHÒNG";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "GIÁ PHÒNG";
            cl3.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "VỊ TRÍ";
            cl4.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "DIỆN TÍCH";
            cl5.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "LOẠI PHÒNG";
            cl6.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "TRẠNG THÁI";
            cl7.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "ĐƯỜNG DẪN ẢNH";
            cl8.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "MÔ TẢ";
            cl9.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "GHI CHÚ";
            cl10.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "NGƯỜI TẠO";
            cl11.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "NGÀY TẠO";
            cl12.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "NGƯỜI SỬA";
            cl13.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "NGÀY SỬA";
            cl14.ColumnWidth = 10.0;
           
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "N3");
            rowHead.Font.Bold = true;
            // Kẻ viền
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Thiết lập màu nền
            rowHead.Interior.ColorIndex = 15;
            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
            // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
            object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
            //Chuyển dữ liệu từ DataTable vào mảng đối tượng
            for (int r = 0; r < tb.Rows.Count; r++)
            {
                DataRow dr = tb.Rows[r];
                for (int c = 0; c < tb.Columns.Count; c++)

                {
                    arr[r, c] = dr[c];
                }
            }
            //Thiết lập vùng điền dữ liệu
            int rowStart = 4;
            int columnStart = 1;
            int rowEnd = rowStart + tb.Rows.Count - 1;
            int columnEnd = tb.Columns.Count;
            // Ô bắt đầu điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
            // Ô kết thúc điền dữ liệu
            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
            // Lấy về vùng điền dữ liệu
            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
            //Điền dữ liệu vào vùng đã thiết lập
            range.Value2 = arr;
            // Kẻ viền
            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
            // Căn giữa cột đầu tiên
            Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
            Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
            oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


        }
        #endregion

        #region Events
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadCboLoaiPhong();
                LoadCboTrangThaiPhong();
                Clear();
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
                LoadCboLoaiPhong();
                LoadCboTrangThaiPhong();
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
            if (Status == "Insert")
            {
                bool cExits = false;
                cExits = CheckExits(txtMaPhong.Text.Trim());
                if (cExits == false)
                {
                    lblThongBao.Text = "Đã tồn tại mã phòng: " + txtMaPhong.Text.Trim() + " trong hệ thống";
                    return;
                }
                InsertData();
            }
            else if (Status == "Update")
            {
                UpdateData();
            }
        }

        private void btnHuyBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
            LoadGrd();
            Status = "Reset";
            SetControl(Status);
        }

        private void btnTT_TimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                LoadCboLoaiPhong();
                LoadCboTrangThaiPhong();
                Status = "Search";
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
                //LoadCboLoaiPhong();
                //LoadCboTrangThaiPhong();
                SearchData();
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable tb = new DataTable();
            SqlConnection con = new SqlConnection(ConnectionString);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string sqlSearch = "EXCEL_DM_PHONG";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);

            cmd.Parameters.AddWithValue("@MA_PHONG", txtMaPhong.Text.Trim());
            cmd.Parameters.AddWithValue("@TEN_PHONG", txtTenPhong.Text.Trim());
            cmd.Parameters.AddWithValue("@GIA_PHONG", txtGiaPhong.Text.Trim());
            cmd.Parameters.AddWithValue("@VI_TRI", txtViTri.Text.Trim());
            cmd.Parameters.AddWithValue("@DIEN_TICH", txtDienTich.Text.Trim());
            cmd.Parameters.AddWithValue("@MA_LOAI_PHONG", cboLoaiPhong.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@MA_TRANG_THAI", cboTrangThaiPhong.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
            cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
            cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
            cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
            cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
            cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "DS các phòng khách sạn");
        }

        private void btnChonFileAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtDuongDanAnh.Text = dlg.FileName;
                picMain.ImageLocation = txtDuongDanAnh.Text.Trim();
                picMain.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        #endregion

        private void grdPhong_Click(object sender, EventArgs e)
        {

        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtDuongDanAnh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
