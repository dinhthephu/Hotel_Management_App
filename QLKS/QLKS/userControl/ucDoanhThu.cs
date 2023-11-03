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
using QLKS.rpt;

namespace QLKS.userControl
{
    public partial class ucDoanhThu : UserControl
    {
        public ucDoanhThu()
        {
            InitializeComponent();
        }
        #region Connect UC
        public static ucDoanhThu _instrance;
        public static ucDoanhThu Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucDoanhThu();
                return _instrance;
            }
        }
        #endregion

        #region Variables
        public static string connect = @"Data Source=LAPTOP-781RRL92\SQLEXPRESS;Initial Catalog=QL_KHACHSAN;Integrated Security=True";
        #endregion

        private void ucDoanhThu_Load(object sender, EventArgs e)
        {
            rptDoanhThu rpt = new rptDoanhThu();
            SqlConnection con = new SqlConnection(connect);
            con.Open();
            SqlCommand cmd = new SqlCommand("REPORT_DOANHTHU", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tb = new DataTable();
            da.Fill(tb);
            cmd.Dispose();
            con.Close();
            rpt.SetDataSource(tb);
            crystalReportViewer1.ReportSource = rpt;
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
