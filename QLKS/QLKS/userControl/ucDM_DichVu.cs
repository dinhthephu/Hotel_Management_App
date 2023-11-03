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
    public partial class ucDM_DichVu : UserControl
    {
        public ucDM_DichVu()
        {
            InitializeComponent();
            LoadCboLoaiDV();
            LoadGrd();
            SetControl("Reset");
        }

        #region Connect UC
        public static ucDM_DichVu _instrance;
        public static ucDM_DichVu Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDM_DichVu();
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

                    txtMaDV.Enabled = false;
                    txtTenDV.Enabled = false;
                    txtGiaDV.Enabled = false;
                    txtDonViTinh.Enabled = false;
                    txtSoLuongKho.Enabled = false;
                    txtMoTa.Enabled = false;
                    txtGhiChu.Enabled = false;
                    cboLoaiDV.Enabled = false;
                    txtDuongDanAnh.Enabled = false;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    txtMaDV.Focus();

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

                    txtMaDV.Enabled = true;
                    txtTenDV.Enabled = true;
                    txtGiaDV.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuongKho.Enabled = true;
                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiDV.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    picMain.Image = null;

                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;
                    picMain.Image = null;

                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtMaDV.Focus();

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
                    btnChonFileAnh.Enabled = true;

                    txtMaDV.Enabled = false;
                    txtTenDV.Enabled = true;
                    txtGiaDV.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuongKho.Enabled = true;
                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiDV.Enabled = true;
                    txtDuongDanAnh.Enabled = true;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySua.Value = DateTime.Now;

                    txtMaDV.Focus();

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


                    txtMaDV.Enabled = true;
                    txtTenDV.Enabled = true;
                    txtGiaDV.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuongKho.Enabled = true;
                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiDV.Enabled = true;
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


                    txtMaDV.Enabled = true;
                    txtTenDV.Enabled = true;
                    txtGiaDV.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuongKho.Enabled = true;
                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiDV.Enabled = true;
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
            string query = "SELECT * FROM DM_DICHVU WHERE TRANG_THAI = '1'  ";
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
            BindingData();
        }
        public void LoadCboLoaiDV()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_LOAIDV WHERE TRANG_THAI = '1'  ";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_LOAI_DV"] = "";
                dr["TEN_LOAI_DV"] = "---Chọn loại dịch vụ---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboLoaiDV.DataSource = ds.Tables[0];
                cboLoaiDV.DisplayMember = "TEN_LOAI_DV";
                cboLoaiDV.ValueMember = "MA_LOAI_DV";
                cboLoaiDV.SelectedItem = 0;
            }

            else
            {
                cboLoaiDV.DataSource = null;

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
            txtMaDV.DataBindings.Clear();
            txtTenDV.DataBindings.Clear();
            txtGiaDV.DataBindings.Clear();
            txtDonViTinh.DataBindings.Clear();
            txtSoLuongKho.DataBindings.Clear();
            txtDuongDanAnh.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();

            cboLoaiDV.DataBindings.Clear();
            txtMoTa.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            picMain.DataBindings.Clear();

            txtMaDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_DV", false, DataSourceUpdateMode.Never));
            txtTenDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_DV", false, DataSourceUpdateMode.Never));
            txtGiaDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "GIA_DV", false, DataSourceUpdateMode.Never));
            txtDonViTinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DON_VI_TINH", false, DataSourceUpdateMode.Never));
            txtSoLuongKho.DataBindings.Add(new Binding("Text", ds.Tables[0], "SO_LUONG_KHO", false, DataSourceUpdateMode.Never));
            txtMoTa.DataBindings.Add(new Binding("Text", ds.Tables[0], "MO_TA", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
            //cboLoaiDV.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_LOAI_DV", false, DataSourceUpdateMode.Never));
            cboLoaiDV.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_LOAI_DV", false, DataSourceUpdateMode.Never));
            txtDuongDanAnh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
            picMain.DataBindings.Add(new Binding("ImageLocation", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
        }
        public void Clear()
        {
            txtMaDV.Text = "";
            txtTenDV.Text = "";
            txtGiaDV.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuongKho.Text = "";
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
                if (txtMaDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã  dịch vụ";
                    txtMaDV.Focus();
                }
                else if (txtTenDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên dịch vụ";
                    txtTenDV.Focus();
                }
                else if(cboLoaiDV.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào loại dịch vụ";
                    cboLoaiDV.Focus();
                }
                else if (txtGiaDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào giá dịch vụ";
                    txtGiaDV.Focus();
                }
                else if (txtSoLuongKho.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng kho";
                    txtSoLuongKho.Focus();
                }
                else
                {
                    LoadImg();
                    if (txtDuongDanAnh.Text != null && txtDuongDanAnh.Text.Trim() != "")
                    {
                        string sqlInsert = "[INSERT_DM_DICHVU]";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@TEN_DV", txtTenDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiDV.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@GIA_DV", txtGiaDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_LUONG_KHO", txtSoLuongKho.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ANH", arrImage);
                        cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
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
                        string sqlInsert = "INSERT_DM_DICHVU";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@TEN_DV", txtTenDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiDV.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@GIA_DV", txtGiaDV.Text.Trim());
                        cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_LUONG_KHO", txtSoLuongKho.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        SqlParameter imageParameter = new SqlParameter("@ANH", SqlDbType.Image);
                        imageParameter.Value = DBNull.Value;
                        cmd.Parameters.Add(imageParameter);
                        cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
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
        public bool CheckExits(String MA_DV)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sqlCheck = "CHECK_EXITS_DV";
                SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MA_DV", MA_DV);
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
                if (txtTenDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên dịch vụ";
                    txtTenDV.Focus();
                }
                else if (txtGiaDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào giá dịch vụ";
                    txtGiaDV.Focus();
                }
                else if (cboLoaiDV.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào loại dịch vụ";
                    cboLoaiDV.Focus();
                }
                else if (txtGiaDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào giá dịch vụ";
                    txtGiaDV.Focus();
                }
                else if (txtSoLuongKho.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng kho";
                    txtSoLuongKho.Focus();
                }
                else
                {
                    LoadImg();
                    string sqlUpdate = "UPADTE_DICH_VU";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_DV", txtTenDV.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiDV.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@GIA_DV", txtGiaDV.Text.Trim());
                    cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                    cmd.Parameters.AddWithValue("@SO_LUONG_KHO", txtSoLuongKho.Text.Trim());
                    cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                    cmd.Parameters.AddWithValue("@ANH", arrImage);
                    cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
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
                if (txtMaDV.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã loại dịch vụ";
                    txtMaDV.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlDelete = "DELETE_DM_DICHVU";
                        SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                        cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
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

                string sqlSearch = "SEARCH_DM_DICHVU";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
                cmd.Parameters.AddWithValue("@TEN_DV", txtTenDV.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiDV.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@GIA_DV", txtGiaDV.Text.Trim());
                cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                cmd.Parameters.AddWithValue("@SO_LUONG_KHO", txtSoLuongKho.Text.Trim());
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
                da.Fill(ds);
                grdDV.DataSource = ds.Tables[0];
                grdDV.Refresh();
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "O1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH CÁC DỊCH VỤ CỦA KHÁCH SẠN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "MÃ DỊCH VỤ";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "TÊN DỊCH VỤ";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "LOẠI DỊCH VỤ";
            cl3.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "E3");
            cl4.MergeCells = true;
            cl4.Value2 = "ĐƯỜNG DẪN ẢNH";
            cl4.ColumnWidth = 35.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("F3", "F3");
            cl5.Value2 = "GIÁ DỊCH VỤ";
            cl5.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("G3", "G3");
            cl6.Value2 = "ĐƠN VỊ TÍNH";
            cl6.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "SỐ LƯỢNG KHO";
            cl8.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "MÔ TẢ";
            cl9.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "GHI CHÚ";
            cl10.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "TRẠNG THÁI";
            cl11.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "NGƯỜI TẠO";
            cl12.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "NGÀY TẠO";
            cl13.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "NGƯỜI SỬA";
            cl14.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O3", "O3");
            cl15.Value2 = "NGÀY SỬA";
            cl15.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "O3");
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


        #endregion

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                Status = "Insert";
                SetControl(Status);
                LoadCboLoaiDV();
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
                LoadCboLoaiDV();
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
                cExits = CheckExits(txtMaDV.Text.Trim());
                if (cExits == false)
                {
                    lblThongBao.Text = "Đã tồn tại mã dịch vụ: " + txtMaDV.Text.Trim() + " trong hệ thống";
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
                Status = "Search";
                SetControl(Status);
                LoadCboLoaiDV();
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
                LoadCboLoaiDV();
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
            string sqlSearch = "SEARCH_DM_DICHVU";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);

            cmd.Parameters.AddWithValue("@MA_DV", txtMaDV.Text.Trim());
            cmd.Parameters.AddWithValue("@TEN_DV", txtTenDV.Text.Trim());
            cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiDV.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@GIA_DV", txtGiaDV.Text.Trim());
            cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
            cmd.Parameters.AddWithValue("@SO_LUONG_KHO", txtSoLuongKho.Text.Trim());
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
            ExportExcel(tb, "DS các dịch vụ khách sạn");
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

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucDM_DichVu_Load(object sender, EventArgs e)
        {

        }
    }
}
