using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using QLKS.userControl;

namespace QLKS
{
    public partial class QuanLyKS : DevExpress.XtraEditors.XtraForm
    {
        public QuanLyKS()
        {
            InitializeComponent();
            if (!pnlMain.Controls.Contains(ucTrangChu._instrance))
            {
                pnlMain.Controls.Add(ucTrangChu.Instrance);
                ucTrangChu.Instrance.Dock = DockStyle.Fill;
                ucTrangChu.Instrance.BringToFront();
            }
            else
            {
                ucTrangChu.Instrance.BringToFront();
            }
        }

        public QuanLyKS(string text)
        {
            Text = text;
        }

        private void btnLoaiPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_LoaiPhong._instrance))
            {
                pnlMain.Controls.Add(ucDM_LoaiPhong.Instrance);
                ucDM_LoaiPhong.Instrance.Dock = DockStyle.Fill;
                ucDM_LoaiPhong.Instrance.BringToFront();
            }
            else
            {
                ucDM_LoaiPhong.Instrance.BringToFront();
            }
        }

        private void btnPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_Phong._instrance))
            {
                pnlMain.Controls.Add(ucDM_Phong.Instrance);
                ucDM_Phong.Instrance.Dock = DockStyle.Fill;
                ucDM_Phong.Instrance.BringToFront();
            }
            else
            {
                ucDM_Phong.Instrance.BringToFront();
            }
        }

        private void btnDatPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDatPhong._instrance))
            {
                pnlMain.Controls.Add(ucDatPhong.Instrance);
                ucDatPhong.Instrance.Dock = DockStyle.Fill;
                ucDatPhong.Instrance.BringToFront();
            }
            else
            {
                ucDatPhong.Instrance.BringToFront();
            }
        }

        private void btnThuePhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucThuePhong._instrance))
            {
                pnlMain.Controls.Add(ucThuePhong.Instrance);
                ucThuePhong.Instrance.Dock = DockStyle.Fill;
                ucThuePhong.Instrance.BringToFront();
            }
            else
            {
                ucThuePhong.Instrance.BringToFront();
            }
        }

        private void btnLoaiDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_LoaiDV._instrance))
            {
                pnlMain.Controls.Add(ucDM_LoaiDV.Instrance);
                ucDM_LoaiDV.Instrance.Dock = DockStyle.Fill;
                ucDM_LoaiDV.Instrance.BringToFront();
            }
            else
            {
                ucDM_LoaiDV.Instrance.BringToFront();
            }
        }

        private void btnDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_DichVu._instrance))
            {
                pnlMain.Controls.Add(ucDM_DichVu.Instrance);
                ucDM_DichVu.Instrance.Dock = DockStyle.Fill;
                ucDM_DichVu.Instrance.BringToFront();
            }
            else
            {
                ucDM_DichVu.Instrance.BringToFront();
            }
        }

        private void btnCSVC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucCSVC._instrance))
            {
                pnlMain.Controls.Add(ucCSVC.Instrance);
                ucCSVC.Instrance.Dock = DockStyle.Fill;
                ucCSVC.Instrance.BringToFront();
            }
            else
            {
                ucCSVC.Instrance.BringToFront();
            }
        }

        private void btnSDDV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucSDDV._instrance))
            {
                pnlMain.Controls.Add(ucSDDV.Instrance);
                ucSDDV.Instrance.Dock = DockStyle.Fill;
                ucSDDV.Instrance.BringToFront();
            }
            else
            {
                ucSDDV.Instrance.BringToFront();
            }
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucThanhToan._instrance))
            {
                pnlMain.Controls.Add(ucThanhToan.Instrance);
                ucThanhToan.Instrance.Dock = DockStyle.Fill;
                ucThanhToan.Instrance.BringToFront();
            }
            else
            {
                ucThanhToan.Instrance.BringToFront();
            }
        }

        private void btnDSKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_KHACH_HANG._instrance))
            {
                pnlMain.Controls.Add(ucDM_KHACH_HANG.Instrance);
                ucDM_KHACH_HANG.Instrance.Dock = DockStyle.Fill;
                ucDM_KHACH_HANG.Instrance.BringToFront();
            }
            else
            {
                ucDM_KHACH_HANG.Instrance.BringToFront();
            }
        }

        private void btnDSNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDM_NHANVIEN._instrance))
            {
                pnlMain.Controls.Add(ucDM_NHANVIEN.Instrance);
                ucDM_NHANVIEN.Instrance.Dock = DockStyle.Fill;
                ucDM_NHANVIEN.Instrance.BringToFront();
            }
            else
            {
                ucDM_NHANVIEN.Instrance.BringToFront();
            }
        }

        private void btnDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucDoanhThu._instrance))
            {
                pnlMain.Controls.Add(ucDoanhThu.Instrance);
                ucDoanhThu.Instrance.Dock = DockStyle.Fill;
                ucDoanhThu.Instrance.BringToFront();
            }
            else
            {
                ucDoanhThu.Instrance.BringToFront();
            }
        }

        private void btnBangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnGiaoDich_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucGiaoDich._instrance))
            {
                pnlMain.Controls.Add(ucGiaoDich.Instrance);
                ucGiaoDich.Instrance.Dock = DockStyle.Fill;
                ucGiaoDich.Instrance.BringToFront();
            }
            else
            {
                ucGiaoDich.Instrance.BringToFront();
            }
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
            
        }

        private void btnTrangChu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucTrangChu._instrance))
            {
                pnlMain.Controls.Add(ucTrangChu.Instrance);
                ucTrangChu.Instrance.Dock = DockStyle.Fill;
                ucTrangChu.Instrance.BringToFront();
            }
            else
            {
                ucTrangChu.Instrance.BringToFront();
            }
        }

        private void btnLương_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucLuong._instrance))
            {
                pnlMain.Controls.Add(ucLuong.Instrance);
                ucLuong.Instrance.Dock = DockStyle.Fill;
                ucLuong.Instrance.BringToFront();
            }
            else
            {
                ucLuong.Instrance.BringToFront();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!pnlMain.Controls.Contains(ucLuongNV._instrance))
            {
                pnlMain.Controls.Add(ucLuongNV.Instrance);
                ucLuongNV.Instrance.Dock = DockStyle.Fill;
                ucLuongNV.Instrance.BringToFront();
            }
            else
            {
                ucLuongNV.Instrance.BringToFront();
            }
        }

        private void QuanLyKS_Load(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}