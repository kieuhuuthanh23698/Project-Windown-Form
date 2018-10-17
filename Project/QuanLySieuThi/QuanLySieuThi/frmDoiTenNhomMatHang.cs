using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class  frmDoiTenNhomMatHang : Form
    {
        KetNoiDuLieu link;
        string ten;

        public frmDoiTenNhomMatHang(string ten,KetNoiDuLieu link)
        {
            this.link = link;
            this.ten = ten;
            InitializeComponent();
            txtTenNhomMatHang.Text = ten;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenNhomMatHang.Text.Equals(ten) == false)
            {
                //cập nhật
                //update khohang set loaimathang = txtTenNhomMatHang where loaiMatHang = ten
                //update loaimathang set loaimathang = txtTenNhomMatHang where loaiMatHang = ten
                int kq = 0;
                kq = this.link.insert("INSERT INTO LoaiHangHoa VALUES((select MaLoaiHangHoa from LoaiHangHoa where TenLoaiHangHoa = N'" + ten + "'),N'" + txtTenNhomMatHang.Text + "') update KhoHang set LoaiHangHoa = N'" + txtTenNhomMatHang.Text + "' where LoaiHangHoa = N'" + ten + "' DELETE LoaiHangHoa WHERE TenLoaiHangHoa = N'" + ten + "'");
                if (kq == 0)
                    MessageBox.Show("Thay đổi thất bại !", "Thay đổi tên nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Thay đổi thành công !", "Thay đổi tên nhóm mặt hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                this.Close();
        }

    }
}
