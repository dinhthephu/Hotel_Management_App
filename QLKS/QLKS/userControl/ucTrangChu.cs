using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS.userControl
{
    public partial class ucTrangChu : UserControl
    {
        public ucTrangChu()
        {
            InitializeComponent();
        }
        public static ucTrangChu _instrance;
        public static ucTrangChu Instrance
        {

            get
            {
                if (_instrance == null)
                    _instrance = new ucTrangChu();
                return _instrance;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
