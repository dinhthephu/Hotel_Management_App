using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            lblError.Text = "";
        }
        #region Variables
        public static string Status = "";
        public static string ConnectionString = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        SqlConnection conn;
        public static DataSet ds;
        #endregion
        public void dangnhap()
        {
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string taikhoan = txtTaiKhoan.Text.Trim();
                string matkhau = txtMatKhau.Text.Trim();
                string query = "SELECT * FROM dbo.QL_TAIKHOAN WHERE TEN_TAIKHOAN= '" + taikhoan + "' AND MAT_KHAU='" + matkhau + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    QuanLyKS frmMenu = new QuanLyKS();

                    //QuanLyKS frmMenu = new QuanLyKS(txtTaiKhoan.Text);
                    frmMenu.Show();
                    this.Hide();
                }

                else
                {
                    lblError.Text = "Thông tin chưa chính xác! ";
                }
            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }

        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtTaiKhoan.Text.Trim() != null) { }
            else
            {
                MessageBox.Show("Vui lòng nhập tài khoản", "Thông báo");
                txtTaiKhoan.Focus();
                return;
            }

            if (txtMatKhau.Text != "" && txtMatKhau.Text.Trim() != null) { }
            else
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo");
                txtMatKhau.Focus();
                return;
            }

            dangnhap();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void picMain_Click(object sender, EventArgs e)
        {

        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }
    }
}
