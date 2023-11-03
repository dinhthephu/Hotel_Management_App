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
    public partial class ucCSVC : UserControl
    {
        public ucCSVC()
        {
            InitializeComponent();
            LoadCboLoaiPhong();
            LoadGrd();
            SetControl("Reset");
        }
        #region Connect UC
        public static ucCSVC _instrance;
        public static ucCSVC Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucCSVC();
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

                    txtMaVatTu.Enabled = false;
                    txtTenVatTu.Enabled = false;
                    txtGiaVatTu.Enabled = false;
                    txtDonViTinh.Enabled = false;
                    txtSoLuong.Enabled = false;
                    txtGhiChu.Enabled = false;
                    cboLoaiPhong.Enabled = false;
                    txtDuongDanAnh.Enabled = false;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    txtMaVatTu.Focus();

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

                    txtMaVatTu.Enabled = false;
                    txtTenVatTu.Enabled = true;
                    txtGiaVatTu.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiPhong.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    picMain.Image = null;

                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;
                    picMain.Image = null;

                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtMaVatTu.Focus();

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
                    btnChonFileAnh.Enabled = true;

                    txtMaVatTu.Enabled = false;
                    txtTenVatTu.Enabled = true;
                    txtGiaVatTu.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiPhong.Enabled = true;
                    txtDuongDanAnh.Enabled = true;

                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySua.Value = DateTime.Now;

                    txtMaVatTu.Focus();

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


                    txtMaVatTu.Enabled = true;
                    txtTenVatTu.Enabled = true;
                    txtGiaVatTu.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiPhong.Enabled = true;
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


                    txtMaVatTu.Enabled = true;
                    txtTenVatTu.Enabled = true;
                    txtGiaVatTu.Enabled = true;
                    txtDonViTinh.Enabled = true;
                    txtSoLuong.Enabled = true;
                    txtGhiChu.Enabled = true;
                    cboLoaiPhong.Enabled = true;
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
            string query = "SELECT * FROM DM_VATTUPHONG WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdVatTu.DataSource = ds.Tables[0];
            }
            else
            {
                grdVatTu.DataSource = null;
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
            txtMaVatTu.DataBindings.Clear();
            txtTenVatTu.DataBindings.Clear();
            txtGiaVatTu.DataBindings.Clear();
            txtDonViTinh.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtDuongDanAnh.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();

            cboLoaiPhong.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            picMain.DataBindings.Clear();

            txtMaVatTu.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_VAT_TU", false, DataSourceUpdateMode.Never));
            txtTenVatTu.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_VAT_TU", false, DataSourceUpdateMode.Never));
            txtGiaVatTu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GIA", false, DataSourceUpdateMode.Never));
            txtDonViTinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DON_VI_TINH", false, DataSourceUpdateMode.Never));
            txtSoLuong.DataBindings.Add(new Binding("Text", ds.Tables[0], "SO_LUONG", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
            txtDuongDanAnh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
            picMain.DataBindings.Add(new Binding("ImageLocation", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
        }

        public void Clear()
        {
            txtMaVatTu.Text = "";
            txtTenVatTu.Text = "";
            txtGiaVatTu.Text = "";
            txtDonViTinh.Text = "";
            txtSoLuong.Text = "";
            txtDuongDanAnh.Text = "";
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
                //if (txtMaVatTu.Text.Trim() == "")
                //{
                //    lblThongBao.Text = "Nhập vào mã  vật tư";
                //    txtMaVatTu.Focus();
                //}
                if (txtTenVatTu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên vật tư";
                    txtTenVatTu.Focus();
                }
                else if (txtGiaVatTu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào giá vật tư";
                    txtGiaVatTu.Focus();
                }
                else if (txtSoLuong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng";
                    txtSoLuong.Focus();
                }
                else
                {
                    LoadImg();
                    if (txtDuongDanAnh.Text != null && txtDuongDanAnh.Text.Trim() != "")
                    {
                        string sqlInsert = "[INSERT_DM_VATTUPHONG]";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@TEN_VAT_TU", txtTenVatTu.Text.Trim());
                        cmd.Parameters.AddWithValue("@GIA", txtGiaVatTu.Text.Trim());
                        cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ANH", arrImage);
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                        string sqlInsert = "INSERT_DM_VATTUPHONG";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@TEN_VAT_TU", txtTenVatTu.Text.Trim());
                        cmd.Parameters.AddWithValue("@GIA", txtGiaVatTu.Text.Trim());
                        cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        SqlParameter imageParameter = new SqlParameter("@ANH", SqlDbType.Image);
                        imageParameter.Value = DBNull.Value;
                        cmd.Parameters.Add(imageParameter);
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;

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

        public void UpdateData()
        {
            try
            {
                if (txtTenVatTu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên vật tư";
                    txtTenVatTu.Focus();
                }
                else if (txtGiaVatTu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào giá vật tư";
                    txtGiaVatTu.Focus();
                }
                else if (txtSoLuong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số lượng";
                    txtSoLuong.Focus();
                }
                else
                {
                    LoadImg();
                    string sqlUpdate = "[UPADTE_DM_VATTUPHONG]";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@ID_OUT", txtMaVatTu.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_VAT_TU", txtTenVatTu.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIA", txtGiaVatTu.Text.Trim());
                    cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                    cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                    cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                    cmd.Parameters.AddWithValue("@ANH", arrImage);
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
                if (txtMaVatTu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã loại vật tư";
                    txtMaVatTu.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlDelete = "[DELETE_DM_VATTUPHONG]";
                        SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                        cmd.Parameters.AddWithValue("@ID_OUT", txtMaVatTu.Text.Trim());
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

                string sqlSearch = "SEARCH_DM_VATTUPHONG";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                cmd.Parameters.AddWithValue("@ID_OUT", txtMaVatTu.Text.Trim());
                cmd.Parameters.AddWithValue("@TEN_VAT_TU", txtTenVatTu.Text.Trim());
                //cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiPhong.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@GIA", txtGiaVatTu.Text.Trim());
                cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
                cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
                cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                //cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                grdVatTu.DataSource = ds.Tables[0];
                grdVatTu.Refresh();
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "M1");
            head.MergeCells = true;
            head.Value2 = "Danh sách các vật tư CỦA KHÁCH SẠN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "Mã vật tư";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "Tên vật tư";
            cl2.ColumnWidth = 25.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("C3", "C3");
            cl4.Value2 = "Giá vật tư";
            cl4.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("D3", "D3");
            cl5.Value2 = "ĐƠN VỊ TÍNH";
            cl5.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("E3", "E3");
            cl6.Value2 = "SỐ LƯỢNG KHO";
            cl6.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("F3", "G3");
            cl8.MergeCells = true;
            cl8.Value2 = "ĐƯỜNG DẪN ẢNH";
            cl8.ColumnWidth = 40.0;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("I3", "I3");
            cl7.Value2 = "TRẠNG THÁI";
            cl7.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("H3", "H3");
            cl10.Value2 = "GHI CHÚ";
            cl10.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("J3", "J3");
            cl11.Value2 = "NGƯỜI TẠO";
            cl11.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("K3", "K3");
            cl12.Value2 = "NGÀY TẠO";
            cl12.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("L3", "L3");
            cl13.Value2 = "NGƯỜI SỬA";
            cl13.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("M3", "M3");
            cl14.Value2 = "NGÀY SỬA";
            cl14.ColumnWidth = 10.0;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "M3");
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
                Clear();
                Status = "Insert";
                SetControl(Status);
                LoadCboLoaiPhong();
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
                LoadCboLoaiPhong();
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
                LoadCboLoaiPhong();
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
                LoadCboLoaiPhong();
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
            string sqlSearch = "SEARCH_DM_VATTUPHONG";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);

            cmd.Parameters.AddWithValue("@ID_OUT", txtMaVatTu.Text.Trim());
            cmd.Parameters.AddWithValue("@TEN_VAT_TU", txtTenVatTu.Text.Trim());
            //cmd.Parameters.AddWithValue("@MA_LOAI_DV", cboLoaiPhong.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@GIA", txtGiaVatTu.Text.Trim());
            cmd.Parameters.AddWithValue("@DON_VI_TINH", txtDonViTinh.Text.Trim());
            cmd.Parameters.AddWithValue("@SO_LUONG", txtSoLuong.Text.Trim());
            cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
            //cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
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
            ExportExcel(tb, "DS các vật tư của Khách sạn");

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

        private void grdVatTu_Click(object sender, EventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtMoTa_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
