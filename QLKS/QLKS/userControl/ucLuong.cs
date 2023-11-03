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
    public partial class ucLuong : UserControl
    {
        public ucLuong()
        {
            InitializeComponent();
            LoadCboChucVu();
            LoadCboCaTruc();
            LoadGrd();
            SetControl("Reset");
        }
        #region Connect UC
        public static ucLuong _instrance;
        public static ucLuong Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucLuong();
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

        public void SetControl(string Status)
        {
            switch (Status)
            {
                case "Reset":

                    lblThongBao.Text = "";

                    btnSua.Enabled = true;
                    btnGhi.Enabled = false;
                    btnChonFileAnh.Enabled = false;

                    txtID.Enabled = false;
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
                    txtLuongCoBan.Enabled = false;
                    txtPhuCap.Enabled = false;
                    txtTongLuong.Enabled = false;
                    btnHuy.Enabled = false;
                    txtID.Focus();

                    break;

                case "Update":

                    lblThongBao.Text = "";

                    btnSua.Enabled = false;
                    btnGhi.Enabled = true;
                    btnChonFileAnh.Enabled = false;

                    txtID.Enabled = false;
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
                    txtLuongCoBan.Enabled = true;
                    txtPhuCap.Enabled = true;
                    txtTongLuong.Enabled = false;
                    btnHuy.Enabled = true;

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

            txtLuongCoBan.DataBindings.Clear();
            txtPhuCap.DataBindings.Clear();
            txtTongLuong.DataBindings.Clear();

            picMain.DataBindings.Clear();

            txtID.DataBindings.Add(new Binding("Text", ds.Tables[0], "ID_NHANVIEN", false, DataSourceUpdateMode.Never));
            txtTenNhanVien.DataBindings.Add(new Binding("Text", ds.Tables[0], "TEN_NHANVIEN", false, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_SINH", false, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", ds.Tables[0], "SDT", false, DataSourceUpdateMode.Never));
            txtCMT.DataBindings.Add(new Binding("Text", ds.Tables[0], "CMT", false, DataSourceUpdateMode.Never));
            txtEmail.DataBindings.Add(new Binding("Text", ds.Tables[0], "EMAIL", false, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", ds.Tables[0], "DIA_CHI", false, DataSourceUpdateMode.Never));
            dtpNgayVaoLam.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGAY_VAO_LAM", false, DataSourceUpdateMode.Never));
            txtLuongCoBan.DataBindings.Add(new Binding("Text", ds.Tables[0], "LUONG_CO_BAN", false, DataSourceUpdateMode.Never));
            txtPhuCap.DataBindings.Add(new Binding("Text", ds.Tables[0], "PHU_CAP", false, DataSourceUpdateMode.Never));
            cboChucVu.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "MA_CHUCVU", false, DataSourceUpdateMode.Never));
            cboCaTruc.DataBindings.Add(new Binding("SelectedValue", ds.Tables[0], "CA_TRUC", false, DataSourceUpdateMode.Never));
            txtDuongDanAnh.DataBindings.Add(new Binding("Text", ds.Tables[0], "DUONG_DAN_ANH", false, DataSourceUpdateMode.Never));
            txtTongLuong.DataBindings.Add(new Binding("Text", ds.Tables[0], "NGUOI_TAO", false, DataSourceUpdateMode.Never));
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
            txtLuongCoBan.Text = "";
            txtPhuCap.Text = "";
          
        }


        public void UpdateData()
        {
            try
            {
                if (cboChucVu.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào mã chức vụ";
                    cboChucVu.Focus();
                }
                else if (txtTenNhanVien.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào tên nhân viên";
                    txtTenNhanVien.Focus();
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
                else if (cboCaTruc.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ca trực";
                    cboCaTruc.Focus();
                }
                else if (dtpNgayVaoLam.Text.Trim() == "")
                {
                    lblThongBao.Text = "Nhập vào ngày vào làm";//LoadCboCaTruc(), 
                    dtpNgayVaoLam.Focus();
                }

                else
                {
                    LoadImg();
                    string sqlUpdate = "[UPDATE_NHANVIEN_LUONG]";
                    SqlCommand cmd = new SqlCommand(sqlUpdate, conn);
                    cmd.Parameters.AddWithValue("@ID_NDUNG", txtID.Text.Trim());
                    cmd.Parameters.AddWithValue("@LUONG_CO_BAN", txtLuongCoBan.Text.Trim());
                    cmd.Parameters.AddWithValue("@PHU_CAP", txtPhuCap.Text.Trim());
                    
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

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Status == "Update")
            {
                LoadCboCaTruc();
                LoadCboChucVu();
                UpdateData();
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

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Clear();
            LoadGrd();
            Status = "Reset";
            SetControl(Status);
        }
    }
}
