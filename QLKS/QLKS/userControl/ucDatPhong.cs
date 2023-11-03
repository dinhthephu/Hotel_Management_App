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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;

namespace QLKS
{
    public partial class ucDatPhong : UserControl
    {
        public ucDatPhong()
        {
            InitializeComponent();
            LoadCboPhongThue();
            LoadGrd();
            SetControl("Reset");
        }
                
        #region Connect UC
        public static ucDatPhong _instrance;
        public static ucDatPhong Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDatPhong
();
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
            private object imageParameter;
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
                    btnDS_PhongTrong.Enabled = true;

                    txtID.Enabled = false;
                    txtMaKH.Enabled = false;
                    txtTenKH.Enabled = false;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;
                    txtSDT.Enabled = false;
                    dtpNgayDatPhong.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = false;
                    txtTongNguoi.Enabled = false;
                    cboPhongThue.Enabled = false;
                    txtDatCoc.Enabled = false;
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
                    btnTT_TimKiem.Enabled = false;
                    btnXuatExcel.Enabled = false;
                    btnTimKiem.Enabled = false;

                    txtID.Enabled = false;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    txtSDT.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    cboPhongThue.Enabled = true;
                    txtDatCoc.Enabled = true;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;
                    dtpNgayDatPhong.Value = DateTime.Now;

                    txtID.Focus();

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
                    btnDS_PhongTrong.Enabled = false;
                    txtID.Enabled = false;

                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    txtSDT.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    cboPhongThue.Enabled = true;
                    txtDatCoc.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = false;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgaySua.Value = DateTime.Now;

                    txtID.Focus();

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


                    txtID.Enabled = true;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    txtSDT.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    cboPhongThue.Enabled = true;
                    txtDatCoc.Enabled = true;
                    txtGhiChu.Enabled = true;
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
                    btnDS_PhongTrong.Enabled = false;
                    btnTimKiem.Enabled = true;


                    txtID.Enabled = true;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;
                    txtSDT.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    cboPhongThue.Enabled = true;
                    txtDatCoc.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;
                    dtpNgayDatPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayNhanPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayTraPhong.Value = DateTime.Now.AddYears(+2);
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
            string query = "SELECT * FROM DAT_PHONG WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdDatPhong.DataSource = ds.Tables[0];
            }
            else
            {
                grdDatPhong.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BanGhi();
            BindingData();
        }

        public void LoadCboPhongThue()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_PHONG WHERE TRANG_THAI = '1'  ";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                //dr["MA_PHONG"] = "---Chọn phòng---";
                //dr["TEN_PHONG"] = "";
                dr["MA_PHONG"] = "";
                dr["TEN_PHONG"] = "---Chọn phòng---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboPhongThue.DataSource = ds.Tables[0];
                cboPhongThue.DisplayMember = "TEN_PHONG";
                //cboPhongThue.DisplayMember = "MA_PHONG";
                cboPhongThue.ValueMember = "MA_PHONG";
                cboPhongThue.SelectedItem = 0;
            }

            else
            {
                cboPhongThue.DataSource = null;

            }
        }

        public void BanGhi()
        {
            lblBanGhi.Text = "Tổng số bản ghi: " + ds.Tables[0].Rows.Count.ToString() + " bản ghi";
        }

        public void BindingData()
        {

            txtID.DataBindings.Clear();
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            dtpNgayDatPhong.DataBindings.Clear();
            dtpNgayNhanPhong.DataBindings.Clear();
            dtpNgayTraPhong.DataBindings.Clear();
            txtTongNguoi.DataBindings.Clear();
            cboPhongThue.DataBindings.Clear();
            txtDatCoc.DataBindings.Clear();
            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID", false, DataSourceUpdateMode.Never));
            txtMaKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_KHACH_HANG", false, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_KHACH_HANG", false, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", ds.Tables[0], "SDT", false, DataSourceUpdateMode.Never));
            dtpNgayDatPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_DAT_PHONG", false, DataSourceUpdateMode.Never));
            dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN", false, DataSourceUpdateMode.Never));
            dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA", false, DataSourceUpdateMode.Never));
            txtTongNguoi.DataBindings.Add(new Binding("Text", ds.Tables[0], "SL_NGUOI", false, DataSourceUpdateMode.Never));
            cboPhongThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "PHONG_THUE", false, DataSourceUpdateMode.Never));
            txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "DAT_COC", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
        }

        public int Gtinh()
        {
            if (rdoNu.Checked == true)
            {
                return 0;
            }
            else return 1;
        }

        public void Clear()
        {
            txtID.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtSDT.Text = "";
            dtpNgayDatPhong.Value = DateTime.Now;
            dtpNgayNhanPhong.Value = DateTime.Now;
            dtpNgayTraPhong.Value = DateTime.Now;
            txtTongNguoi.Text = "";
            cboPhongThue.SelectedItem = 0;
            txtDatCoc.Text = "";
            
            txtGhiChu.Text = "";
            txtNguoiTao.Text = "";
            txtNguoiSua.Text = "";
            dtpNgayTao.Value = DateTime.Now;
            dtpNgaySua.Value = DateTime.Now;
        }

        public void InsertData()
        {
            try
            {
                if (txtMaKH.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã khách hàng";
                    txtMaKH.Focus();
                }
                else if (txtTenKH.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên khách hàng";
                    txtTenKH.Focus();
                }
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    lblThongBao.Text = "Hãy chọn giới tính";
                    rdoNam.Focus();
                }
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại khách hàng";
                    txtSDT.Focus();
                }
                else if (dtpNgayNhanPhong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày nhận phòng";
                    dtpNgayNhanPhong.Focus();
                }
                else if (dtpNgayTraPhong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày trả phòng";
                    dtpNgayTraPhong.Focus();
                }
                else if (txtTongNguoi.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tổng số lượng người";
                    txtTongNguoi.Focus();
                }
                else if (cboPhongThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn phòng";
                    cboPhongThue.Focus();
                }
                else if (txtDatCoc.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số tiền khách đặt cọc ";
                    txtDatCoc.Focus();
                }
                else
                {
                        string sqlInsert = "INSERT_DATPHONG";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@MA_KHACH_HANG", txtMaKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@TEN_KHACH_HANG", txtTenKH.Text.Trim());
                        cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                        cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                        cmd.Parameters.AddWithValue("@NGAY_NHAN", dtpNgayNhanPhong.Value);
                        cmd.Parameters.AddWithValue("@NGAY_TRA", dtpNgayTraPhong.Value);
                        cmd.Parameters.AddWithValue("@SL_NGUOI", txtTongNguoi.Text.Trim());
                        cmd.Parameters.AddWithValue("@PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                        var iOut = Convert.ToInt32(cmd.Parameters["@ID_OUT"].Value);
                        cmd.Parameters.AddWithValue("@ID", iOut);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void UpdateTrangThaiPhong()
        {
            try
            {
                string sqlUpdate = "UPADTE_TRANGTHAI_PHONG";
                SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                cmd.Parameters.AddWithValue("@MA_PHONG", cboPhongThue.SelectedValue.ToString());
                cmd.CommandType = CommandType.StoredProcedure;
                var result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    lblThongBao.Text = "Đã cập nhật Phòng";
                }
                else
                {
                    lblThongBao.Text = "Không thể!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void UpdateKhachHang()
        {
            try
            {
                    string sqlUpdate = "[UPADTE_DM_KHACHHANG_GD]";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_KHACHHANG", txtMaKH.Text.Trim());
                    cmd.CommandType = CommandType.StoredProcedure;
                    var result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        lblThongBao.Text = "Đã cập nhật KH";
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể!";
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void InsertDataKhachHang()
        {
            try
            {
                    string sqlInsert = "[INSERT_DM_KHACHHANG_GD]";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_KHACHHANG", txtMaKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_KHACHHANG", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@SO_LAN_GD", "1");
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
                        lblThongBao.Text = "Thêm khách hàng thành công!";
                    }
                    else
                    {
                        lblThongBao.Text = "Không thể thêm!";
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public bool CheckExits(String MA_KHACHHANG)
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                string sqlCheck = "CHECK_EXITS_KHACHHANG";
                SqlCommand cmd = new SqlCommand(sqlCheck, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@MA_KHACHHANG", MA_KHACHHANG);
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
                if (txtMaKH.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã khách hàng";
                    txtMaKH.Focus();
                }
                else if (txtTenKH.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên khách hàng";
                    txtTenKH.Focus();
                }
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    lblThongBao.Text = "Hãy chọn giới tính";
                    rdoNam.Focus();
                }
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại khách hàng";
                    txtSDT.Focus();
                }
                else if (dtpNgayNhanPhong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày nhận phòng";
                    dtpNgayNhanPhong.Focus();
                }
                else if (dtpNgayTraPhong.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày trả phòng";
                    dtpNgayTraPhong.Focus();
                }
                else if (txtTongNguoi.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tổng số lượng người";
                    txtTongNguoi.Focus();
                }
                else if (cboPhongThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn phòng";
                    cboPhongThue.Focus();
                }
                else if (txtDatCoc.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số tiền khách đặt cọc ";
                    txtDatCoc.Focus();
                }
                else
                {
                    string sqlUpdate = "UPADTE_DATPHONG";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_KHACH_HANG", txtMaKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_KHACH_HANG", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_NHAN", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@SL_NGUOI", txtTongNguoi.Text.Trim());
                    cmd.Parameters.AddWithValue("@PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    //cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());

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
                if (txtID.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ID";
                    txtID.Focus();
                }
                else
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlDelete = "DELETE_DATPHONG";
                        SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                        cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());
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

                string sqlSearch = "SEARCH_DATPHONG";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                cmd.Parameters.AddWithValue("@MA_KHACH_HANG", txtMaKH.Text.Trim());
                cmd.Parameters.AddWithValue("@TEN_KHACH_HANG", txtTenKH.Text.Trim());
                //cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                cmd.Parameters.AddWithValue("@NGAY_NHAN", dtpNgayNhanPhong.Value);
                cmd.Parameters.AddWithValue("@NGAY_TRA", dtpNgayTraPhong.Value);
                cmd.Parameters.AddWithValue("@SL_NGUOI", txtTongNguoi.Text.Trim());
                cmd.Parameters.AddWithValue("@PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
                cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                //cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdDatPhong.DataSource = ds.Tables[0];
                grdDatPhong.Refresh();
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "Q1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH THÔNG TIN ĐẶT PHÒNG";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "ID";
            cl1.ColumnWidth = 5.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "MÃ KHÁCH HÀNG";
            cl2.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "TÊN KHÁCH HÀNG";
            cl3.ColumnWidth = 20.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "GIỚI TÍNH";
            cl4.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "SĐT";
            cl5.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "NGÀY ĐẶT PHÒNG";
            cl6.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "NGÀY NHẬN";
            cl7.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "NGÀY TRẢ";
            cl8.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "SL NGƯỜI";
            cl9.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "PHÒNG THUÊ";
            cl10.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "ĐẶT CỌC";
            cl11.ColumnWidth = 10;
            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "GHI CHÚ";
            cl12.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "TRẠNG THÁI";
            cl13.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "NGƯỜI TẠO";
            cl14.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O3", "O3");
            cl15.Value2 = "NGÀY TẠO";
            cl15.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P3", "P3");
            cl16.Value2 = "NGƯỜI SỬA";
            cl16.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("Q3", "Q3");
            cl17.Value2 = "NGÀY SỬA";
            cl17.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "Q3");
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
                LoadCboPhongThue();
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
                LoadCboPhongThue();
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
                cExits = CheckExits(txtMaKH.Text.Trim());
                if (cExits == false)
                {
                    UpdateKhachHang();
                    UpdateTrangThaiPhong();
                    InsertData();
                    return;
                }
                else {
                    InsertDataKhachHang();
                    UpdateTrangThaiPhong();
                    InsertData();
                    return;
                }
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
                LoadCboPhongThue();
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
            string sqlSearch = "SEARCH_DATPHONG";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);

            cmd.Parameters.AddWithValue("@MA_KHACH_HANG", txtMaKH.Text.Trim());
            cmd.Parameters.AddWithValue("@TEN_KHACH_HANG", txtTenKH.Text.Trim());
            //cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
            cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
            cmd.Parameters.AddWithValue("@NGAY_NHAN", dtpNgayNhanPhong.Value);
            cmd.Parameters.AddWithValue("@NGAY_TRA", dtpNgayTraPhong.Value);
            cmd.Parameters.AddWithValue("@SL_NGUOI", txtTongNguoi.Text.Trim());
            cmd.Parameters.AddWithValue("@PHONG_THUE", cboPhongThue.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@DAT_COC", txtDatCoc.Text.Trim());
            cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
            cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
            cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
            cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
            //cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());


            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "DS thông tin đặt phòng trước");
        }

        private void btnDS_PhongTrong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

                string sqlSearch = "SEARCH_DS_PHONGTRONG";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);
                cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdPhongTrong.DataSource = ds.Tables[0];
                grdPhongTrong.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }
        #endregion

        private void grdDatPhong_MouseDown(object sender, MouseEventArgs e)
        {
            GridHitInfo info = gridView1.CalcHitInfo(e.Location);
            if (info.InRowCell)
            {
                int row = info.RowHandle;
                GridColumn colum = info.Column;

                if (gridView1.GetRowCellValue(row, "GIOI_TINH").ToString().Equals("1"))
                {
                    rdoNam.Checked = true;
                }
                else
                {
                    rdoNu.Checked = true;
                }

            }
        }

        private void grdDatPhong_Click(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucDatPhong_Load(object sender, EventArgs e)
        {

        }
    }


}
