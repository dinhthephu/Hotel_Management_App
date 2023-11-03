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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Columns;

namespace QLKS.userControl
{
    public partial class ucDM_NHANVIEN : UserControl
    {
        public ucDM_NHANVIEN()
        {
            InitializeComponent();
            LoadCboChucVu();
            LoadCboCaTruc();
            LoadGrd();
            SetControl("Reset");
        }
        #region Connect UC
        public static ucDM_NHANVIEN _instrance;
        public static ucDM_NHANVIEN Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDM_NHANVIEN();
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

                    txtID.Enabled = false;
                    txtID_TK.Enabled = false;
                    txtTenNhanVien.Enabled = false;
                    dtpNgaySinh.Enabled = false;
                    txtEmail.Enabled = false;
                    txtDiaChi.Enabled = false;
                    cboChucVu.Enabled = false;
                    txtCMT.Enabled = false;
                    txtSDT.Enabled = false;
                    txtDuongDanAnh.Enabled = false;
                    rdoNam.Enabled = false;
                    rdoNu.Enabled = false;
                    cboCaTruc.Enabled = false;
                    dtpNgayVaoLam.Enabled = false;

                    txtMoTa.Enabled = false;
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
                    btnChonFileAnh.Enabled = true;
                    btnXuatExcel.Enabled = false;
                    btnTimKiem.Enabled = false;

                    txtID.Enabled = false;
                    txtID_TK.Enabled = false;
                    txtTenNhanVien.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDiaChi.Enabled = true;
                    cboChucVu.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    cboCaTruc.Enabled = true;
                    dtpNgayVaoLam.Enabled = true;

                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = false;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;
                    picMain.Image = null;

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
                    btnTT_TimKiem.Enabled = false;
                    btnTimKiem.Enabled = false;
                    btnXuatExcel.Enabled = false;
                    btnChonFileAnh.Enabled = true;

                    txtID.Enabled = false;
                    txtID_TK.Enabled = false;
                    txtTenNhanVien.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDiaChi.Enabled = true;
                    cboChucVu.Enabled = true;
                    txtCMT.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    txtSDT.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    cboCaTruc.Enabled = true;
                    dtpNgayVaoLam.Enabled = true;

                    txtMoTa.Enabled = true;
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


                    txtID.Enabled = false;
                    txtID_TK.Enabled = false;
                    txtTenNhanVien.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDiaChi.Enabled = true;
                    cboChucVu.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    cboCaTruc.Enabled = true;
                    dtpNgayVaoLam.Enabled = true;

                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = false;
                    dtpNgaySua.Enabled = false;

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


                    txtID.Enabled = true;
                    txtID_TK.Enabled = true;
                    txtTenNhanVien.Enabled = true;
                    dtpNgaySinh.Enabled = true;
                    txtEmail.Enabled = true;
                    txtDiaChi.Enabled = true;
                    cboChucVu.Enabled = true;
                    txtCMT.Enabled = true;
                    txtSDT.Enabled = true;
                    txtDuongDanAnh.Enabled = true;
                    rdoNam.Enabled = true;
                    rdoNu.Enabled = true;
                    cboCaTruc.Enabled = true;
                    dtpNgayVaoLam.Enabled = true;

                    txtMoTa.Enabled = true;
                    txtGhiChu.Enabled = true;
                    txtNguoiTao.Enabled = true;
                    txtNguoiSua.Enabled = true;
                    dtpNgayTao.Enabled = true;
                    dtpNgaySua.Enabled = true;
                    picMain.Image = null;
                    
                    dtpNgayVaoLam.Value = DateTime.Now.AddYears(-10);
                    dtpNgaySinh.Value = DateTime.Now.AddYears(-80);
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
            string query = "SELECT * FROM DM_NHANVIEN WHERE TRANG_THAI = '1'  ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                grdNhanVien.DataSource = ds.Tables[0];
            }
            else
            {
                grdNhanVien.DataSource = null;
                lblBanGhi.Text = "Tổng số: 0 bản ghi";
            }
            BanGhi();
            BindingData();
        }

        public void LoadCboChucVu()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_CHUCVU";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_CHUCVU"] = "";
                dr["TEN_CHUCVU"] = "---Chọn chức vụ---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboChucVu.DataSource = ds.Tables[0];
                cboChucVu.DisplayMember = "TEN_CHUCVU";
                cboChucVu.ValueMember = "MA_CHUCVU";
                cboChucVu.SelectedItem = 0;
            }

            else
            {
                cboChucVu.DataSource = null;

            }
        }

        public void LoadCboCaTruc()
        {
            conn = new SqlConnection(ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string Insert_Cbo = "SELECT * FROM DM_CATRUC";
            SqlCommand sqlCommand = new SqlCommand(Insert_Cbo, conn);
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            ds = new DataSet();
            da.Fill(ds);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr;
                dr = ds.Tables[0].NewRow();
                dr["MA_CATRUC"] = "";
                dr["TEN_CATRUC"] = "---Chọn ca trực---";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cboCaTruc.DataSource = ds.Tables[0];
                cboCaTruc.DisplayMember = "TEN_CATRUC";
                cboCaTruc.ValueMember = "MA_CATRUC";
                cboCaTruc.SelectedItem = 0;
            }

            else
            {
                cboCaTruc.DataSource = null;

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
            txtID.DataBindings.Clear();
            txtID_TK.DataBindings.Clear();
            txtTenNhanVien.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            cboChucVu.DataBindings.Clear();
            txtCMT.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            cboCaTruc.DataBindings.Clear();
            dtpNgayVaoLam.DataBindings.Clear();
            txtDuongDanAnh.DataBindings.Clear();

            txtNguoiTao.DataBindings.Clear();
            txtNguoiSua.DataBindings.Clear();
            dtpNgayTao.DataBindings.Clear();
            dtpNgaySua.DataBindings.Clear();
            txtMoTa.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            picMain.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID_NHANVIEN", false, DataSourceUpdateMode.Never));
            txtID_TK.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID_TAIKHOAN", false, DataSourceUpdateMode.Never));
            txtTenNhanVien.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_NHANVIEN", false, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SINH", false, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", ds.Tables[0], "SDT", false, DataSourceUpdateMode.Never));
            txtCMT.DataBindings.Add(new Binding("Text", ds.Tables[0], "CMT", false, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", ds.Tables[0], "EMAIL", false, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", ds.Tables[0], "DIA_CHI", false, DataSourceUpdateMode.Never));
            dtpNgayVaoLam.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_VAO_LAM", false, DataSourceUpdateMode.Never));
            txtMoTa.DataBindings.Add(new Binding("Text", ds.Tables[0], "MO_TA", false, DataSourceUpdateMode.Never));
            txtGhiChu.DataBindings.Add(new Binding("Text", ds.Tables[0], "GHI_CHU", false, DataSourceUpdateMode.Never));
            cboChucVu.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_CHUCVU", false, DataSourceUpdateMode.Never));
            cboCaTruc.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "CA_TRUC", false, DataSourceUpdateMode.Never));
            txtDuongDanAnh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
            txtNguoiTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
            txtNguoiSua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_SUA", false, DataSourceUpdateMode.Never));
            dtpNgayTao.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_TAO", false, DataSourceUpdateMode.Never));
            dtpNgaySua.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SUA", false, DataSourceUpdateMode.Never));
            picMain.DataBindings.Add(new Binding("ImageLocation", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
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
            txtID_TK.Text = "";
            txtTenNhanVien.Text = "";
            dtpNgaySinh.Value = DateTime.Now.AddYears(-50);
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            cboChucVu.SelectedItem = 0;
            txtCMT.Text = "";
            txtSDT.Text = "";
            cboCaTruc.SelectedItem = 0;
            dtpNgayVaoLam.Value = DateTime.Now.AddYears(-2);
            rdoNam.Checked = false;
            rdoNu.Checked = false;
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
                if (cboChucVu.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào mã chức vụ";
                    cboChucVu.Focus();
                }
                else if (txtTenNhanVien.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên nhân viên";
                    txtTenNhanVien.Focus();
                }
                else if (cboCaTruc.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào ca trực";
                    cboCaTruc.Focus();
                }
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    lblThongBao.Text = "Hãy chọn giới tính";
                    rdoNam.Focus();
                }
                else if (txtDiaChi.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào địa chỉ";
                    txtDiaChi.Focus();
                }
                else if (txtCMT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào CMT/Hộ chiếu";
                    txtCMT.Focus();
                }
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại nhân viên";
                    txtSDT.Focus();
                }
                else if (txtEmail.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào email";
                    txtEmail.Focus();
                }
                else if (dtpNgayVaoLam.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày vào làm";
                    dtpNgayVaoLam.Focus();
                }  
                else
                {
                    LoadImg();
                    if (txtDuongDanAnh.Text != null && txtDuongDanAnh.Text.Trim() != "")
                    {
                        string sqlInsert_tk = "INSERT_TK";
                        SqlCommand sqlCommand = new SqlCommand(sqlInsert_tk, conn);
                        sqlCommand.Parameters.AddWithValue("@TEN_TKHOAN", txtTenNhanVien.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@MAT_KHAU", "1");
                        sqlCommand.Parameters.AddWithValue("@NGAY_HLUC", dtpNgayVaoLam.Value);
                        sqlCommand.Parameters.AddWithValue("@TGIAN_HLUC", 90);
                        sqlCommand.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@TRANG_THAI","1");
                        sqlCommand.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        sqlCommand.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        sqlCommand.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteNonQuery();
                        var iOut = Convert.ToInt32(sqlCommand.Parameters["@ID_OUT"].Value);
                        sqlCommand.Parameters.Clear();

                        string sqlInsert = "INSERT_NHANVIEN";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@ID_TAIKHOAN", iOut);
                        cmd.Parameters.AddWithValue("@MA_CHUCVU", cboChucVu.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TEN_NDUNG", txtTenNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                        cmd.Parameters.AddWithValue("@SO_DTHOAI", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_CMT", txtCMT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        cmd.Parameters.AddWithValue("@ANH", arrImage);
                        cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.Parameters.AddWithValue("@CA_TRUC", cboCaTruc.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@NGAY_VAO_LAM", dtpNgayVaoLam.Value);
                        //sqlCommand.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
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
                        string sqlInsert_tk = "INSERT_TK";
                        SqlCommand sqlCommand = new SqlCommand(sqlInsert_tk, conn);
                        sqlCommand.Parameters.AddWithValue("@TEN_TKHOAN", txtTenNhanVien.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@MAT_KHAU", "1");
                        sqlCommand.Parameters.AddWithValue("@NGAY_HLUC", dtpNgayTao.Value);
                        sqlCommand.Parameters.AddWithValue("@TGIAN_HLUC", 90);
                        sqlCommand.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@TRANG_THAI", "1");
                        sqlCommand.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        sqlCommand.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        sqlCommand.Parameters.AddWithValue("@NGAY_SUA", dtpNgayTao.Value);
                        sqlCommand.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.ExecuteNonQuery();
                        var iOut = Convert.ToInt32(sqlCommand.Parameters["@ID_OUT"].Value);
                        sqlCommand.Parameters.Clear();

                        string sqlInsert = "INSERT_NHANVIEN";
                        SqlCommand cmd = new SqlCommand(sqlInsert, conn);
                        cmd.Parameters.AddWithValue("@ID_TAIKHOAN", iOut);
                        cmd.Parameters.AddWithValue("@MA_CHUCVU", cboChucVu.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@TEN_NDUNG", txtTenNhanVien.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                        cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                        cmd.Parameters.AddWithValue("@SO_DTHOAI", txtSDT.Text.Trim());
                        cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                        cmd.Parameters.AddWithValue("@SO_CMT", txtCMT.Text.Trim());
                        cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                        SqlParameter imageParameter = new SqlParameter("@ANH", SqlDbType.Image);
                        imageParameter.Value = DBNull.Value;
                        cmd.Parameters.Add(imageParameter);
                        cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                        cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                        cmd.Parameters.AddWithValue("@TRANG_THAI", "1");
                        cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                        cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                        cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                        cmd.Parameters.AddWithValue("@CA_TRUC", cboCaTruc.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@NGAY_VAO_LAM", dtpNgayVaoLam.Value);
                        //sqlCommand.Parameters.Add("@ID_OUT", SqlDbType.Int).Direction = ParameterDirection.Output;
                        cmd.CommandType = CommandType.StoredProcedure;

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
                if (cboChucVu.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào mã chức vụ";
                    cboChucVu.Focus();
                }
                else if (txtTenNhanVien.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên nhân viên";
                    txtTenNhanVien.Focus();
                }
                else if (cboCaTruc.SelectedValue == "")
                {
                    lblThongBao.Text = "Nhập vào ca trực";
                    cboCaTruc.Focus();
                }
                else if (rdoNam.Checked == false && rdoNu.Checked == false)
                {
                    lblThongBao.Text = "Hãy chọn giới tính";
                    rdoNam.Focus();
                }
                else if (txtDiaChi.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào địa chỉ";
                    txtDiaChi.Focus();
                }
                else if (txtCMT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào CMT/Hộ chiếu";
                    txtCMT.Focus();
                }
                else if (txtSDT.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào số điện thoại nhân viên";
                    txtSDT.Focus();
                }
                else if (txtEmail.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào email";
                    txtEmail.Focus();
                }
                else if (dtpNgayVaoLam.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày vào làm";
                    dtpNgayVaoLam.Focus();
                }
                else
                {
                    LoadImg();
                    string sqlUpdate = "[UPDATE_NHANVIEN]";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@ID_NDUNG", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@MA_CHUCVU", cboChucVu.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TEN_NDUNG", txtTenNhanVien.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                    cmd.Parameters.AddWithValue("@SO_DTHOAI", txtSDT.Text.Trim());
                    cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                    cmd.Parameters.AddWithValue("@SO_CMT", txtCMT.Text.Trim());
                    cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                    cmd.Parameters.AddWithValue("@ANH", arrImage);
                    cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                    cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                    cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                    cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                    cmd.Parameters.AddWithValue("@CA_TRUC", cboCaTruc.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@NGAY_VAO_LAM", dtpNgayVaoLam.Value);
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
                    if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string sqlDelete = "DELETE_DM_NHANVIEN";
                        SqlCommand cmd = new SqlCommand(sqlDelete, conn);
                        cmd.Parameters.AddWithValue("@ID_NHANVIEN", txtID.Text.Trim());
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

                string sqlSearch = "SEARCH_NHANVIEN";
                SqlCommand cmd = new SqlCommand(sqlSearch, conn);

                cmd.Parameters.AddWithValue("@ID_NDUNG", txtID.Text.Trim());
                cmd.Parameters.AddWithValue("@ID_TAIKHOAN", txtID_TK.Text.Trim());
                cmd.Parameters.AddWithValue("@MA_CHUCVU", cboChucVu.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@TEN_NDUNG", txtTenNhanVien.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
                //cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
                cmd.Parameters.AddWithValue("@SO_DTHOAI", txtSDT.Text.Trim());
                cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
                cmd.Parameters.AddWithValue("@SO_CMT", txtCMT.Text.Trim());
                cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
                //cmd.Parameters.AddWithValue("@ANH", arrImage);
                cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
                cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
                cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
                cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
                cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
                cmd.Parameters.AddWithValue("@CA_TRUC", cboCaTruc.SelectedValue.ToString());
                cmd.Parameters.AddWithValue("@NGAY_VAO_LAM", dtpNgayVaoLam.Value);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();

                da.SelectCommand = cmd;
                da.Fill(ds);
                grdNhanVien.DataSource = ds.Tables[0];
                grdNhanVien.Refresh();
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "X1");
            head.MergeCells = true;
            head.Value2 = "DANH SÁCH NHÂN VIÊN CỦA KHÁCH SẠN";
            head.Font.Bold = true;
            head.Font.Name = "Tahoma";
            head.Font.Size = "18";
            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            // Tạo tiêu đề cột 
            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");
            cl1.Value2 = "ID NHÂN VIÊN";
            cl1.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");
            cl2.Value2 = "ID TÀI KHOẢN";
            cl2.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");
            cl3.Value2 = "MÃ CHỨC VỤ";
            cl3.ColumnWidth = 15.0;
            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");
            cl4.Value2 = "TÊN NHÂN VIÊN";
            cl4.ColumnWidth = 30.0;
            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");
            cl5.Value2 = "NGÀY SINH";
            cl5.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");
            cl6.Value2 = "GIỚI TÍNH";
            cl6.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");
            cl7.Value2 = "SĐT";
            cl7.ColumnWidth = 15;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");
            cl8.Value2 = "EMAIL";
            cl8.ColumnWidth = 20.0;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");
            cl9.Value2 = "ĐỊA CHỈ";
            cl9.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl10 = oSheet.get_Range("J3", "J3");
            cl10.Value2 = "CMT";
            cl10.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl11 = oSheet.get_Range("K3", "K3");
            cl11.Value2 = "NGÀY VÀO LÀM";
            cl11.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl12 = oSheet.get_Range("L3", "L3");
            cl12.Value2 = "CA TRỰC";
            cl12.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl13 = oSheet.get_Range("M3", "M3");
            cl13.Value2 = "LƯƠNG CƠ BẢN";
            cl13.ColumnWidth = 25;
            Microsoft.Office.Interop.Excel.Range cl14 = oSheet.get_Range("N3", "N3");
            cl14.Value2 = "PHỤ CẤP";
            cl14.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl15 = oSheet.get_Range("O3", "O3");
            cl15.Value2 = "TIỀN LƯƠNG";
            cl15.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl16 = oSheet.get_Range("P3", "Q3");
            cl16.MergeCells = true;
            cl16.Value2 = "ĐƯỜNG DẪN ẢNH";
            cl16.ColumnWidth = 35.0;
            Microsoft.Office.Interop.Excel.Range cl22 = oSheet.get_Range("R3", "R3");
            cl22.Value2 = "MÔ TẢ";
            cl22.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl23 = oSheet.get_Range("S3", "S3");
            cl23.Value2 = "GHI CHÚ";
            cl23.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl17 = oSheet.get_Range("T3", "T3");
            cl17.Value2 = "TRẠNG THÁI";
            cl17.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl18 = oSheet.get_Range("U3", "U3");
            cl18.Value2 = "NGƯỜI TẠO";
            cl18.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl19 = oSheet.get_Range("V3", "V3");
            cl19.Value2 = "NGÀY TẠO";
            cl19.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl20 = oSheet.get_Range("W3", "W3");
            cl20.Value2 = "NGƯỜI SỬA";
            cl20.ColumnWidth = 10.0;
            Microsoft.Office.Interop.Excel.Range cl21 = oSheet.get_Range("X3", "X3");
            cl21.Value2 = "NGÀY SỬA";
            cl21.ColumnWidth = 10.0;


            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "X3");
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

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                LoadCboCaTruc();
                LoadCboChucVu();
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
                LoadCboCaTruc();
                LoadCboChucVu();
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

        private void grdNhanVien_MouseDown(object sender, MouseEventArgs e)
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

        private void btnTT_TimKiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Clear();
                LoadCboCaTruc();
                LoadCboChucVu();
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
            string sqlSearch = "[SEARCH_NHANVIEN]";
            SqlCommand cmd = new SqlCommand(sqlSearch, conn);

            cmd.Parameters.AddWithValue("@ID_NDUNG", txtID.Text.Trim());
            cmd.Parameters.AddWithValue("@ID_TAIKHOAN", txtID_TK.Text.Trim());
            cmd.Parameters.AddWithValue("@MA_CHUCVU", cboChucVu.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@TEN_NDUNG", txtTenNhanVien.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_SINH", dtpNgaySinh.Value);
            //cmd.Parameters.AddWithValue("@GIOI_TINH", Gtinh());
            cmd.Parameters.AddWithValue("@SO_DTHOAI", txtSDT.Text.Trim());
            cmd.Parameters.AddWithValue("@EMAIL", txtEmail.Text.Trim());
            cmd.Parameters.AddWithValue("@DIA_CHI", txtDiaChi.Text.Trim());
            cmd.Parameters.AddWithValue("@SO_CMT", txtCMT.Text.Trim());
            cmd.Parameters.AddWithValue("@DUONG_DAN_ANH", txtDuongDanAnh.Text.Trim());
            //cmd.Parameters.AddWithValue("@ANH", arrImage);
            cmd.Parameters.AddWithValue("@MO_TA", txtMoTa.Text.Trim());
            cmd.Parameters.AddWithValue("@GHI_CHU", txtGhiChu.Text.Trim());
            cmd.Parameters.AddWithValue("@NGUOI_TAO", txtNguoiTao.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_TAO", dtpNgayTao.Value);
            cmd.Parameters.AddWithValue("@NGUOI_SUA", txtNguoiSua.Text.Trim());
            cmd.Parameters.AddWithValue("@NGAY_SUA", dtpNgaySua.Value);
            cmd.Parameters.AddWithValue("@CA_TRUC", cboCaTruc.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@NGAY_VAO_LAM", dtpNgayVaoLam.Value);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            da.SelectCommand = cmd;
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            ExportExcel(tb, "DS Nhân viên khách sạn");
        }

        private void groupControl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
