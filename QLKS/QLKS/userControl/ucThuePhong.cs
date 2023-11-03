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
using QLKS.Report;

namespace QLKS.userControl
{
    public partial class ucThuePhong : UserControl
    {
        public ucThuePhong()
        {
            InitializeComponent();
            LoadCboPhongThue();
            LoadCboLoaiThue();
            LoadCboTrangThaiThanhToan();
            LoadGrd();
            LoadGrdDatPhong();
            SetControl("Reset");

        }

        #region Connect UC
        public static ucThuePhong _instrance;
        public static ucThuePhong Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucThuePhong();
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
                    btnTimKiem.Enabled = false;
                    btnTimKiemThuePhong.Enabled = true;
                    btnTKDatPhongTruoc.Enabled = true;
                    btnXuatExcel.Enabled = false;

                    txtID.Enabled = false;
                    txtMaKH.Enabled = false;
                    txtTenKH.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtCMT.Enabled = false;
                    txtSDT.Enabled = false;
                    txtQuocTich.Enabled = false;
                    txtTreEm.Enabled = false;
                    txtTongNguoi.Enabled = false;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;

                    txtMaPhieuThue.Enabled = false;
                    cboPhongThue.Enabled = false;
                    dtpNgayDatPhong.Enabled = false;
                    dtpNgayNhanPhong.Enabled = false;
                    dtpNgayTraPhong.Enabled = false;
                    txtDatCoc.Enabled = false;
                    cboLoaiThue.Enabled = false;
                    cboThanhToan.Enabled = false;
                    txtTienPhong.Enabled = false;

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
                    btnTimKiem.Enabled = false;
                    btnXuatExcel.Enabled = false;
                    btnTimKiemThuePhong.Enabled = false;

                    txtID.Enabled = false;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = true;
                    txtTreEm.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;

                    txtMaPhieuThue.Enabled = true;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = true;
                    cboThanhToan.Enabled = true;
                    txtTienPhong.Enabled = false;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

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
                    btnTimKiem.Enabled = false;
                    btnTimKiemThuePhong.Enabled = false;
                    btnXuatExcel.Enabled = false;
                    btnTimKiemThuePhong.Enabled = true;

                    txtID.Enabled = false;

                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = true;
                    txtTreEm.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;

                    txtMaPhieuThue.Enabled = false;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = true;
                    cboThanhToan.Enabled = true;
                    txtTienPhong.Enabled = false;

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
                    btnTimKiem.Enabled = true;
                    btnXuatExcel.Enabled = false;
                    btnTimKiemThuePhong.Enabled = true;


                    txtID.Enabled = true;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = true;
                    txtTreEm.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;

                    txtMaPhieuThue.Enabled = true;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = true;
                    cboThanhToan.Enabled = true;
                    txtTienPhong.Enabled = false;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;

                    break;
                case "SearchThuePhong":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = true;
                    btnTimKiem.Enabled = true;
                    btnXuatExcel.Enabled = true;

                    btnTimKiemThuePhong.Enabled = true;
                    btnTKDatPhongTruoc.Enabled = false;

                    txtID.Enabled = true;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = true;
                    txtTreEm.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;

                    txtMaPhieuThue.Enabled = true;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = true;
                    cboThanhToan.Enabled = true;
                    txtTienPhong.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;

                    dtpNgaySinh.Value = DateTime.Now.AddYears(-80);
                    dtpNgayDatPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayNhanPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayTraPhong.Value = DateTime.Now.AddYears(+2);
                    dtpNgayTao.Value = DateTime.Now.AddYears(-5);
                    dtpNgaySua.Value = DateTime.Now;

                    break;
                case "SearchDatPhong":

                    lblThongBao.Text = "";

                    btnThem.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = false;
                    btnHuyBo.Enabled = true;
                    btnTimKiem.Enabled = true;
                    btnXuatExcel.Enabled = true;

                    btnTimKiemThuePhong.Enabled = false;
                    btnTKDatPhongTruoc.Enabled = true;

                    txtID.Enabled = true;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = false;
                    txtDiaChi.Enabled = false;
                    txtCMT.Enabled = false;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = false;
                    txtTreEm.Enabled = false;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;

                    txtMaPhieuThue.Enabled = false;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = false;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = false;
                    cboThanhToan.Enabled = false;
                    txtTienPhong.Enabled = false;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;

                    dtpNgaySinh.Value = DateTime.Now.AddYears(-80);
                    dtpNgayDatPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayNhanPhong.Value = DateTime.Now.AddYears(-5);
                    dtpNgayTraPhong.Value = DateTime.Now.AddYears(+2);
                    dtpNgayTao.Value = DateTime.Now.AddYears(-5);
                    dtpNgaySua.Value = DateTime.Now;

                    break;
                case "ThuePhongDatTruoc":

                    lblThongBao.Text = "";

                    btnThem.Enabled = true;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                    btnGhi.Enabled = true;
                    btnHuyBo.Enabled = true;
                    btnTimKiem.Enabled = false;
                    btnXuatExcel.Enabled = false;
                    btnTimKiemThuePhong.Enabled = false;

                    txtID.Enabled = false;
                    txtMaKH.Enabled = true;
                    txtTenKH.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtDiaChi.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtQuocTich.Enabled = true;
                    txtTreEm.Enabled = true;
                    txtTongNguoi.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;

                    txtMaPhieuThue.Enabled = true;
                    cboPhongThue.Enabled = true;
                    dtpNgayDatPhong.Enabled = true;
                    dtpNgayNhanPhong.Enabled = true;
                    dtpNgayTraPhong.Enabled = true;
                    txtDatCoc.Enabled = true;
                    cboLoaiThue.Enabled = true;
                    cboThanhToan.Enabled = true;
                    txtTienPhong.Enabled = false;

                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

                    dtpNgayTao.Value = DateTime.Now;
                    dtpNgaySua.Value = DateTime.Now;

                    txtID.Focus();

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
            string query = "SELECT * FROM DM_THUEPHONG WHERE TRANG_THAI = '1'  ";
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
            BanGhi();
            BindingData();
        }
        public void LoadGrdDatPhong()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT MA_KHACH_HANG, TEN_KHACH_HANG, GIOI_TINH, SDT, NGAY_DAT_PHONG, NGAY_NHAN, NGAY_TRA, SL_NGUOI, PHONG_THUE, DAT_COC FROM DAT_PHONG WHERE TRANG_THAI = '1'  ";
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
            }
           
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

        public void LoadCboLoaiThue()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM LOAI_THUE";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_LOAI_THUE"] = "";
                dr["TEN_LOAI_THUE"] = "---Chọn loại thuê---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboLoaiThue.DataSource = ds.Tables[0];
                //cboLoaiThue.DisplayMember = "MA_LOAI_THUE";
                cboLoaiThue.DisplayMember = "TEN_LOAI_THUE";
                cboLoaiThue.ValueMember = "MA_LOAI_THUE";
                cboLoaiThue.SelectedItem = 0;
            }

            else
            {
                cboLoaiThue.DataSource = null;

            }
        }

        public void LoadCboTrangThaiThanhToan()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM TRANGTHAI_THANHTOAN";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_HT_THANHTOAN"] = "";
                dr["TEN_HT_THANHTOAN"] = "---Chọn hình thức thanh toán---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboThanhToan.DataSource = ds.Tables[0];
                //cboThanhToan.DisplayMember = "MA_HT_THANHTOAN";
                cboThanhToan.DisplayMember = "TEN_HT_THANHTOAN";
                cboThanhToan.ValueMember = "MA_HT_THANHTOAN";
                cboThanhToan.SelectedItem = 0;
  
            }

            else
            {
                cboThanhToan.DataSource = null;

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
            dtpNgaySinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtCMT.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            txtTreEm.DataBindings.Clear();
            txtTongNguoi.DataBindings.Clear();

            txtMaPhieuThue.DataBindings.Clear();
            cboPhongThue.DataBindings.Clear();
            dtpNgayDatPhong.DataBindings.Clear();
            dtpNgayNhanPhong.DataBindings.Clear();
            dtpNgayTraPhong.DataBindings.Clear();
            txtDatCoc.DataBindings.Clear();
            cboLoaiThue.DataBindings.Clear();
            cboThanhToan.DataBindings.Clear();
            txtTienPhong.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID", false, DataSourceUpdateMode.Never));
            txtMaKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_KHACHHANG", false, DataSourceUpdateMode.Never));
            txtTenKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_KHACHHANG", false, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SINH", false, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", ds.Tables[0], "DIA_CHI", false, DataSourceUpdateMode.Never));
            txtCMT.DataBindings.Add(new Binding("Text", ds.Tables[0], "CMT", false, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", ds.Tables[0], "SDT", false, DataSourceUpdateMode.Never));
            txtQuocTich.DataBindings.Add(new Binding("Text", ds.Tables[0], "QUOC_TICH", false, DataSourceUpdateMode.Never));
            txtTreEm.DataBindings.Add(new Binding("Text", ds.Tables[0], "SL_TRE_EM", false, DataSourceUpdateMode.Never));
            txtTongNguoi.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_NGUOI", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
            txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
            cboPhongThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_PHONG_THUE", false, DataSourceUpdateMode.Never));
            dtpNgayDatPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_DAT_PHONG", false, DataSourceUpdateMode.Never));
            dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
            dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));
            txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_COC", false, DataSourceUpdateMode.Never));
            cboLoaiThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_LOAI_THUE", false, DataSourceUpdateMode.Never));
            cboThanhToan.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_HT_THANHTOAN", false, DataSourceUpdateMode.Never));
            txtTienPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_TIEN_PHONG", false, DataSourceUpdateMode.Never));
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
            txtDiaChi.Text = "";
            txtCMT.Text = "";
            txtSDT.Text = "";
            txtQuocTich.Text = "";
            txtTreEm.Text = "";
            txtTongNguoi.Text = "";

            txtMaPhieuThue.Text = "";
            cboPhongThue.SelectedItem = 0;
            txtDatCoc.Text = "";
            cboLoaiThue.SelectedItem = 0;
            cboThanhToan.SelectedItem = 0;
            txtTienPhong.Text = "";

            rdoNam.Checked = false;
            rdoNu.Checked = false;
            dtpNgayDatPhong.Value = DateTime.Now;
            dtpNgayNhanPhong.Value = DateTime.Now;
            dtpNgayTraPhong.Value = DateTime.Now;

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
                //else if (txtDiaChi.Text.Trim() == "")
                //{
                //    lblThongBao.Text = "Nhập vào địa chỉ của khách hàng";
                //    txtDiaChi.Focus();
                //}
                //else if (txtCMT.Text.Trim() == "")
                //{
                //    lblThongBao.Text = "Nhập vào CMT/ Hộ chiếu";
                //    txtCMT.Focus();
                //}
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại khách hàng";
                    txtSDT.Focus();
                }
                else if (txtMaPhieuThue.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã phiếu thuê";
                    txtMaPhieuThue.Focus();
                }
                else if (cboPhongThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn phòng";
                    cboPhongThue.Focus();
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
                else if (txtDatCoc.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số tiền khách đặt cọc ";
                    txtDatCoc.Focus();
                }
                else if (cboLoaiThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn hình thức thuê";
                    cboLoaiThue.Focus();
                }
                else if (cboThanhToan.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn hình thức thanh toán";
                    cboThanhToan.Focus();
                }
                else
                {
                    string sqlInsert = "INSERT_DM_THUEPHONG";
                    SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                    cmd.Parameters.AddWithValue("@MA_KHACHHANG", txtMaKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_KHACHHANG", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                    cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@CMT", txtCMT.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@QUOC_TICH", txtQuocTich.Text.Trim());
                    cmd.Parameters.AddWithValue("@SL_TRE_EM", txtTreEm.Text.Trim());
                    cmd.Parameters.AddWithValue("@TONG_NGUOI", txtTongNguoi.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@TIEN_COC", txtDatCoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_LOAI_THUE", cboLoaiThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MA_HT_THANHTOAN", cboThanhToan.SelectedValue.ToString());
                    //txtTienPhong.Text = 
                    //cmd.Parameters.AddWithValue("@TONG_TIEN_PHONG", txtTienPhong.Text.Trim());
                    //cmd.Parameters.Add("@TONG_TIEN_PHONG", SqlDbType.Int).Direction = ParameterDirection.Input;

                    cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //var iOut = Convert.ToInt32(cmd.Parameters["@ID_OUT"].Value);
                    //cmd.Parameters.AddWithValue("@ID", iOut);
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

        public void UpdateTrangThaiPhong()
        {
            string sqlUpdate = "UPADTE_TRANGTHAI_PHONG_DANGTHUE";
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
                //else if (txtDiaChi.Text.Trim() == "")
                //{
                //    lblThongBao.Text = "Nhập vào địa chỉ của khách hàng";
                //    txtDiaChi.Focus();
                //}
                //else if (txtCMT.Text.Trim() == "")
                //{
                //    lblThongBao.Text = "Nhập vào CMT/ Hộ chiếu";
                //    txtCMT.Focus();
                //}
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại khách hàng";
                    txtSDT.Focus();
                }
                else if (txtMaPhieuThue.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã phiếu thuê";
                    txtMaPhieuThue.Focus();
                }
                else if (cboPhongThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn phòng";
                    cboPhongThue.Focus();
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
                else if (txtDatCoc.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số tiền khách đặt cọc ";
                    txtDatCoc.Focus();
                }
                else if (cboLoaiThue.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn hình thức thuê";
                    cboLoaiThue.Focus();
                }
                else if (cboThanhToan.SelectedValue == "")
                {
                    lblThongBao.Text = "Vui lòng chọn hình thức thanh toán";
                    cboThanhToan.Focus();
                }
                else
                {
                    string sqlUpdate = "UPADTE_DM_THUEPHONG";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@MA_KHACHHANG", txtMaKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@TEN_KHACHHANG", txtTenKH.Text.Trim());
                    cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                    cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@CMT", txtCMT.Text.Trim());
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@QUOC_TICH", txtQuocTich.Text.Trim());
                    cmd.Parameters.AddWithValue("@SL_TRE_EM", txtTreEm.Text.Trim());
                    cmd.Parameters.AddWithValue("@TONG_NGUOI", txtTongNguoi.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                    cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                    cmd.Parameters.AddWithValue("@TIEN_COC", txtDatCoc.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_LOAI_THUE", cboLoaiThue.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@MA_HT_THANHTOAN", cboThanhToan.SelectedValue.ToString());
                    //cmd.Parameters.AddWithValue("@TONG_TIEN_PHONG", txtTienPhong.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
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
                        string sqlDelete = "DELETE_DM_THUEPHONG";
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

                string sqlSearch = "SEARCH_THUEPHONG";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                cmd.Parameters.AddWithValue("@MA_KHACHHANG", txtMaKH.Text.Trim());
                cmd.Parameters.AddWithValue("@TEN_KHACHHANG", txtTenKH.Text.Trim());
                //cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@CMT", txtCMT.Text.Trim());
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@QUOC_TICH", txtQuocTich.Text.Trim());
                cmd.Parameters.AddWithValue("@SL_TRE_EM", txtTreEm.Text.Trim());
                cmd.Parameters.AddWithValue("@TONG_NGUOI", txtTongNguoi.Text.Trim());
                cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", txtMaPhieuThue.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_PHONG_THUE", cboPhongThue.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", dtpNgayDatPhong.Value);
                cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", dtpNgayNhanPhong.Value);
                cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", dtpNgayTraPhong.Value);
                cmd.Parameters.AddWithValue("@TIEN_COC", txtDatCoc.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_LOAI_THUE", cboLoaiThue.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@MA_HT_THANHTOAN", cboThanhToan.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@TONG_TIEN_PHONG", txtTienPhong.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                //cmd.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdThuePhong.DataSource = ds.Tables[0];

                txtID.DataBindings.Clear();
                txtMaKH.DataBindings.Clear();
                txtTenKH.DataBindings.Clear();
                dtpNgaySinh.DataBindings.Clear();
                txtDiaChi.DataBindings.Clear();
                txtCMT.DataBindings.Clear();
                txtSDT.DataBindings.Clear();
                txtQuocTich.DataBindings.Clear();
                txtTreEm.DataBindings.Clear();
                txtTongNguoi.DataBindings.Clear();

                txtMaPhieuThue.DataBindings.Clear();
                cboPhongThue.DataBindings.Clear();
                dtpNgayDatPhong.DataBindings.Clear();
                dtpNgayNhanPhong.DataBindings.Clear();
                dtpNgayTraPhong.DataBindings.Clear();
                txtDatCoc.DataBindings.Clear();
                cboLoaiThue.DataBindings.Clear();
                cboThanhToan.DataBindings.Clear();
                txtTienPhong.DataBindings.Clear();

                txtNguoiTao.DataBindings.Clear();
                txtNguoiSua.DataBindings.Clear();
                dtpNgayTao.DataBindings.Clear();
                dtpNgaySua.DataBindings.Clear();
                txtGhiChu.DataBindings.Clear();

                txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID", false, DataSourceUpdateMode.Never));
                txtMaKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_KHACHHANG", false, DataSourceUpdateMode.Never));
                txtTenKH.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_KHACHHANG", false, DataSourceUpdateMode.Never));
                dtpNgaySinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SINH", false, DataSourceUpdateMode.Never));
                txtDiaChi.DataBindings.Add(new Binding("Text", ds.Tables[0], "DIA_CHI", false, DataSourceUpdateMode.Never));
                txtCMT.DataBindings.Add(new Binding("Text", ds.Tables[0], "CMT", false, DataSourceUpdateMode.Never));
                txtSDT.DataBindings.Add(new Binding("Text", ds.Tables[0], "SDT", false, DataSourceUpdateMode.Never));
                txtQuocTich.DataBindings.Add(new Binding("Text", ds.Tables[0], "QUOC_TICH", false, DataSourceUpdateMode.Never));
                txtTreEm.DataBindings.Add(new Binding("Text", ds.Tables[0], "SL_TRE_EM", false, DataSourceUpdateMode.Never));
                txtTongNguoi.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_NGUOI", false, DataSourceUpdateMode.Never));
                txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
                txtMaPhieuThue.DataBindings.Add(new Binding("Text", ds.Tables[0], "MA_PHIEUTHUE", false, DataSourceUpdateMode.Never));
                cboPhongThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_PHONG_THUE", false, DataSourceUpdateMode.Never));
                dtpNgayDatPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_DAT_PHONG", false, DataSourceUpdateMode.Never));
                dtpNgayNhanPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_NHAN_PHONG", false, DataSourceUpdateMode.Never));
                dtpNgayTraPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TRA_PHONG", false, DataSourceUpdateMode.Never));
                txtDatCoc.DataBindings.Add(new Binding("Text", ds.Tables[0], "TIEN_COC", false, DataSourceUpdateMode.Never));
                cboLoaiThue.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_LOAI_THUE", false, DataSourceUpdateMode.Never));
                cboThanhToan.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_HT_THANHTOAN", false, DataSourceUpdateMode.Never));
                txtTienPhong.DataBindings.Add(new Binding("Text", ds.Tables[0], "TONG_TIEN_PHONG", false, DataSourceUpdateMode.Never));
                txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
                txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
                dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
                dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));



                //BindingData();
                grdThuePhong.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        public void SearchDatPhongData()
        {
            try
            {
                LoadCboPhongThue();
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
                cmd.Parameters.AddWithValue("@ID_OUT", txtID.Text.Trim());

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                da.SelectCommand = cmd;
                da.Fill(ds);
                grdDatPhong.DataSource = ds.Tables[0];

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

                grdThuePhong.Refresh();
                cmd.Dispose();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        //public void ExportExcel(DataTable tb, string sheetname)
        //{
        //    //Tạo các đối tượng Excel

        //    Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel.Workbooks oBooks;
        //    Microsoft.Office.Interop.Excel.Sheets oSheets;
        //    Microsoft.Office.Interop.Excel.Workbook oBook;
        //    Microsoft.Office.Interop.Excel.Worksheet oSheet;
        //    //Tạo mới một Excel WorkBook 
        //    oExcel.Visible = true;
        //    oExcel.DisplayAlerts = false;
        //    oExcel.Application.SheetsInNewWorkbook = 1;
        //    oBooks = oExcel.Workbooks;
        //    oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));
        //    oSheets = oBook.Worksheets;
        //    oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);
        //    oSheet.Name = sheetname;
        //    // Tạo phần đầu nếu muốn
        //    Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");
        //    head.MergeCells = true;
        //    head.Value2 = "DANH SÁCH THÔNG TIN ĐẶT PHÒNG";
        //    head.Font.Bold = true;
        //    head.Font.Name = "Tahoma";
        //    head.Font.Size = "18";
        //    head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    // Tạo tiêu đề cột 
        //    Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
        //    cl1.Value2 = "ID";
        //    cl1.ColumnWidth = 5.0;
        //    Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
        //    cl2.Value2 = "MÃ KHÁCH HÀNG";
        //    cl2.ColumnWidth = 15.0;
        //    Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
        //    cl3.Value2 = "TÊN KHÁCH HÀNG";
        //    cl3.ColumnWidth = 20.0;
        //    Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
        //    cl4.Value2 = "GIỚI TÍNH";
        //    cl4.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
        //    cl5.Value2 = "SĐT";
        //    cl5.ColumnWidth = 15.0;
        //    Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
        //    cl6.Value2 = "NGÀY NHẬN";
        //    cl6.ColumnWidth = 15;
        //    Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
        //    cl7.Value2 = "NGÀY TRẢ";
        //    cl7.ColumnWidth = 15.0;
        //    Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
        //    cl8.Value2 = "SL NGƯỜI";
        //    cl8.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
        //    cl9.Value2 = "PHÒNG THUÊ";
        //    cl9.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
        //    cl10.Value2 = "ĐẶT CỌC";
        //    cl10.ColumnWidth = 10;
        //    Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
        //    cl11.Value2 = "GHI CHÚ";
        //    cl11.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
        //    cl12.Value2 = "NGƯỜI TẠO";
        //    cl12.ColumnWidth = 15;
        //    Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
        //    cl13.Value2 = "NGÀY TẠO";
        //    cl13.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
        //    cl14.Value2 = "NGƯỜI SỬA";
        //    cl14.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O3", "O3");
        //    cl15.Value2 = "NGÀY SỬA";
        //    cl15.ColumnWidth = 10.0;
        //    Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "O3");
        //    rowHead.Font.Bold = true;
        //    // Kẻ viền
        //    rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        //    // Thiết lập màu nền
        //    rowHead.Interior.ColorIndex = 15;
        //    rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    // Tạo mảng đối tượng để lưu dữ toàn bồ dữ liệu trong DataTable,
        //    // vì dữ liệu được được gán vào các Cell trong Excel phải thông qua object thuần.
        //    object[,] arr = new object[tb.Rows.Count, tb.Columns.Count];
        //    //Chuyển dữ liệu từ DataTable vào mảng đối tượng
        //    for (int r = 0; r < tb.Rows.Count; r++)
        //    {
        //        DataRow dr = tb.Rows[r];
        //        for (int c = 0; c < tb.Columns.Count; c++)

        //        {
        //            arr[r, c] = dr[c];
        //        }
        //    }
        //    //Thiết lập vùng điền dữ liệu
        //    int rowStart = 4;
        //    int columnStart = 1;
        //    int rowEnd = rowStart + tb.Rows.Count - 1;
        //    int columnEnd = tb.Columns.Count;
        //    // Ô bắt đầu điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];
        //    // Ô kết thúc điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];
        //    // Lấy về vùng điền dữ liệu
        //    Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);
        //    //Điền dữ liệu vào vùng đã thiết lập
        //    range.Value2 = arr;
        //    // Kẻ viền
        //    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        //    // Căn giữa cột đầu tiên
        //    Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];
        //    Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);
        //    oSheet.get_Range(c3, c4).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;


        //}

        #endregion

        #region Events
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadCboPhongThue();
                LoadCboLoaiThue();
                LoadCboTrangThaiThanhToan();
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
                //LoadCboPhongThue();
                //LoadCboLoaiThue();
                //LoadCboTrangThaiThanhToan();
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
            if(Status == "Insert")
            {
                bool cExits = false;
                cExits = CheckExits(txtMaKH.Text.Trim());
                if (cExits == false || Status == "ThuePhongDatTruoc")
                {
                    UpdateKhachHang();
                    UpdateTrangThaiPhong();
                    InsertData();
                    return;
                }
                else
                {
                    UpdateTrangThaiPhong();
                    InsertDataKhachHang();
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

        private void btnTimKiemThuePhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                LoadCboPhongThue();
                LoadCboLoaiThue();
                LoadCboTrangThaiThanhToan();
                Status = "SearchThuePhong";
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
                if (Status == "SearchThuePhong")
                {
                    SearchThuePhongData();
                    // BindingData();
                }
                else if (Status == "SearchDatPhong")
                {
                    SearchDatPhongData();
                }
                Status = "Insert";
                SetControl(Status);

            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;

            }
        }

        private void btnXuatExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void grdThuePhong_MouseDown(object sender, MouseEventArgs e)
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

        private void btnTKDatPhongTruoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                LoadCboPhongThue();
                LoadCboLoaiThue();
                LoadCboTrangThaiThanhToan();
                LoadGrdDatPhong();
                Status = "SearchDatPhong";
                SetControl(Status);
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

        private void btnThuePhongDatTruoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadCboPhongThue();
                LoadCboLoaiThue();
                LoadCboTrangThaiThanhToan();
                Status = "ThuePhongDatTruoc";
                SetControl(Status);
            }
            catch (Exception ex)
            {
                lblThongBao.Text = ex.Message;
            }
        }

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

        private void btnInPT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            String p_ID = txtID.Text;
            string p_MA_KH = txtMaKH.Text;
            string p_TEN_KH = txtTenKH.Text;
            String p_SDT = txtSDT.Text;
            String p_TONGNGUOI = txtTongNguoi.Text;
            String p_MAPHIEUTHUE = txtMaPhieuThue.Text;
            String p_PHONGTHUE = cboPhongThue.SelectedValue.ToString();
            DateTime p_NGAYDATPHONG = Convert.ToDateTime(dtpNgayDatPhong.Value);
            DateTime p_NGAYNHANPHONG = Convert.ToDateTime(dtpNgayNhanPhong.Value);
            DateTime p_NGAYTRAPHONG = Convert.ToDateTime(dtpNgayTraPhong.Value);
            String p_DATCOC = txtDatCoc.Text;
            String p_TONGTIENPHONG = txtTienPhong.Text;

            PhieuThuePhong frm = new PhieuThuePhong(p_ID, p_MA_KH, p_TEN_KH, p_SDT, p_TONGNGUOI, p_MAPHIEUTHUE, p_PHONGTHUE, p_NGAYDATPHONG, p_NGAYNHANPHONG, p_NGAYTRAPHONG, p_DATCOC, p_TONGTIENPHONG);
            //PhieuThuePhong frm = new PhieuThuePhong(p_ID);

            frm.Show();

        }

        #endregion

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboLoaiThue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
