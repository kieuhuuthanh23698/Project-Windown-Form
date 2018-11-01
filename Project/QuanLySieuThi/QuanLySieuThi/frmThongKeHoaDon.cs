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

        public frmThongKeHoaDon(KetNoiDuLieu kn)
        {
            this.kn = kn;
            InitializeComponent();
            TaidataGirdview();
        }

        public void TaidataGirdview()
        {
            dataGridView_PhieuBanHang.DataSource = this.kn.comManTable("select  MaHoaDon, NgayLapHoaDon, GioLapHoaDon, TenNVLapHoaDon, TenKhachHang, TienHang, PhanTramGiamGia, GiamGia, TongThanhTien, KhachDua, TraLai from HoaDon","HoaDon").Tables["HoaDon"];
            for (int i = 0; i < dataGridView_PhieuBanHang.RowCount; i++)
            {
                //if (i % 2 == 0)
                //    dataGridView_PBH.Rows[i].DefaultCellStyle.BackColor = Color.LightGreen;
                //else
                    //dataGridView_PBH.Rows[i].DefaultCellStyle.BackColor = Color.AliceBlue;
                    //dataGridView_PBH.Rows[i].DefaultCellStyle.ForeColor = Color.Aqua;
                
            }
            dataGridView_PhieuBanHang.DefaultCellStyle.BackColor = Color.LightCyan;
            dataGridView_PhieuBanHang.AlternatingRowsDefaultCellStyle.BackColor = Color.Moccasin;
        }

        private void dataGridView_PhieuBanHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_PhieuBanHang.SelectedRows.Count != 0)
            {
               dataGridViewChiTietHoaDon.DataSource = this.kn.comManTable("select MaHangHoa, TenHangHoa, GiaBan, Soluong,ThanhTien from ChiTietHoaDon where MaHoaDon = '" + dataGridView_PhieuBanHang.SelectedRows[0].Cells[0].Value.ToString() + "'","ChiTietHoaDon").Tables["ChiTietHoaDon"];
            }
        }
    }
}
