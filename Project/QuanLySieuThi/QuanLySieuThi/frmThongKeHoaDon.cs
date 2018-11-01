using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLySieuThi
{
    public partial class frmThongKeHoaDon : Form
    {
        KetNoiDuLieu kn;
        string hoadon;
        public frmThongKeHoaDon(KetNoiDuLieu kn, string hoadon)
        {
            this.kn = kn;
            this.hoadon = hoadon;
            InitializeComponent();
            TaidataGirdview();
        }

        public void TaidataGirdview()
        {
            dataGridView_PBH.DataSource = this.kn.comManTable("select  MaHoaDon,NgayLapHoaDon,TenNVLapHoaDon,KhoHang.MaHangHoa,KhoHang.TenHangHoa,KhoHang.GiaBan,GiamGia,TongThanhTien from HoaDon,KhoHang","HoaDon").Tables["HoaDon"];
        }
    }
}
