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
    public partial class HoaDonDichVu : Form
    {
        private string p_MaHDDV;
        private string p_MaPhieuThue;
        private string p_DichVu;
        private string p_SoLuong;
        private DateTime p_NgaySuDung;
        private string p_TongTien;
        public static string connect = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        public HoaDonDichVu()
        {
            InitializeComponent();
        }

        public HoaDonDichVu(string p_MaHDDV, string p_MaPhieuThue, string p_DichVu, string p_SoLuong, DateTime p_NgaySuDung, string p_TongTien):this()
        {
            this.p_MaHDDV = p_MaHDDV;
            this.p_MaPhieuThue = p_MaPhieuThue;
            this.p_DichVu = p_DichVu;
            this.p_SoLuong = p_SoLuong;
            this.p_NgaySuDung = p_NgaySuDung;
            this.p_TongTien = p_TongTien;
        }

        private void HoaDonDichVu_Load(object sender, EventArgs e)
        {
            rptHoaDonDV rpt = new rptHoaDonDV();
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("SEARCH_HD_SUDUNG_DICHVU", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MA_PHIEUTHUE", p_MaPhieuThue);
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            rpt.SetDataSource(tb);
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
