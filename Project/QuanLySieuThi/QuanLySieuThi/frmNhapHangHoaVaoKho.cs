using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmNhapHangHoaVaoKho : Form
    {
        KetNoiDuLieu link;
        DataGridViewRow row;
        string tenMatHang;
        string maHangHoa;

        public frmNhapHangHoaVaoKho(KetNoiDuLieu link, DataGridViewRow row)
        {
            this.link = link;
            this.row = row;
            this.tenMatHang = row.Cells["TenHangHoa"].Value.ToString().Trim();
            this.maHangHoa = row.Cells["MaHangHoa"].Value.ToString().Trim();
            InitializeComponent();
            txtTen.Text = this.tenMatHang;
        }

        private void txtGiaban_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuongThem.Text.Length > 0)
            {
                int soLuongThem = int.Parse(txtSoLuongThem.Text);
                int soLuongTrongKho = int.Parse(row.Cells["SoluongTrongKho"].Value.ToString().Trim());
                string chuoiThem = "update KhoHang set SoluongTrongKho = '" + (soLuongThem + soLuongTrongKho) + "' where MaHangHoa = '" + this.maHangHoa + "'";
                int kqThem = this.link.insert(chuoiThem);
                if (kqThem != 0)
                    MessageBox.Show("Nhập hàng hóa thành công !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Nhập hàng hóa thất bại !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
