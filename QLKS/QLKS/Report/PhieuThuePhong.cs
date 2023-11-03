using QLKS.rpt;
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

namespace QLKS.Report
{
    public partial class PhieuThuePhong : Form
    {
        private string p_ID;
        private string p_MA_KH;
        private string p_TEN_KH;
        private string p_SDT;
        private string p_TONGNGUOI;
        private string p_MAPHIEUTHUE;
        private string p_PHONGTHUE;
        private DateTime p_NGAYDATPHONG;
        private DateTime p_NGAYNHANPHONG;
        private DateTime p_NGAYTRAPHONG;
        private string p_DATCOC;
        private string p_TONGTIENPHONG;
        public static string connect = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";

        public PhieuThuePhong()
        {
            InitializeComponent();
        }

        public PhieuThuePhong(string p_ID, string p_MA_KH, string p_TEN_KH, string p_SDT, string p_TONGNGUOI, string p_MAPHIEUTHUE, string p_PHONGTHUE, DateTime p_NGAYDATPHONG, DateTime p_NGAYNHANPHONG, DateTime p_NGAYTRAPHONG, string p_DATCOC, string p_TONGTIENPHONG): this()
        //public PhieuThuePhong(string p_ID) : this()

        {
            this.p_ID = p_ID;
            this.p_MA_KH = p_MA_KH;
            this.p_TEN_KH = p_TEN_KH;
            this.p_SDT = p_SDT;
            this.p_TONGNGUOI = p_TONGNGUOI;
            this.p_MAPHIEUTHUE = p_MAPHIEUTHUE;
            this.p_PHONGTHUE = p_PHONGTHUE;
            this.p_NGAYDATPHONG = p_NGAYDATPHONG;
            this.p_NGAYNHANPHONG = p_NGAYNHANPHONG;
            this.p_NGAYTRAPHONG = p_NGAYTRAPHONG;
            this.p_DATCOC = p_DATCOC;
            this.p_TONGTIENPHONG = p_TONGTIENPHONG;
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void PhieuThuePhong_Load(object sender, EventArgs e)
        {
            rptThuePhong rpt = new rptThuePhong();
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("REPORT_THUEPHONG", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MA_KHACHHANG", p_MA_KH);
            cmd.Parameters.AddWithValue("@TEN_KHACHHANG", p_TEN_KH);
            cmd.Parameters.AddWithValue("@SDT", p_SDT);
            cmd.Parameters.AddWithValue("@TONG_NGUOI", p_TONGNGUOI);
            cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", p_MAPHIEUTHUE);
            cmd.Parameters.AddWithValue("@MA_PHONG_THUE", p_PHONGTHUE);
            cmd.Parameters.AddWithValue("@NGAY_DAT_PHONG", p_NGAYDATPHONG);
            cmd.Parameters.AddWithValue("@NGAY_NHAN_PHONG", p_NGAYNHANPHONG);
            cmd.Parameters.AddWithValue("@NGAY_TRA_PHONG", p_NGAYTRAPHONG);
            cmd.Parameters.AddWithValue("@TIEN_COC", p_DATCOC);
            cmd.Parameters.AddWithValue("@TONG_TIEN_PHONG", p_TONGTIENPHONG);
            cmd.Parameters.AddWithValue("@ID_OUT", p_ID);

            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            rpt.SetDataSource(tb);
            crystalReportViewer2.ReportSource = rpt;
        }
    }
}
