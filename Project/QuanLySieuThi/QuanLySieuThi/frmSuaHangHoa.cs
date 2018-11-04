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
    public partial class frmSuaHangHoa : Form
    {
        DataGridViewRow row;
        KetNoiDuLieu kn;
        String ten, giaban, donvi;

        public frmSuaHangHoa(KetNoiDuLieu kn, DataGridViewRow row)
        {
            this.row = row;
            this.kn = kn;
            InitializeComponent();

            txtTen.Text = row.Cells["TenHangHoa"].Value.ToString();
            txtGiaban.Text = row.Cells["GiaBan"].Value.ToString();
            txtDonvi.Text = row.Cells["DonVi"].Value.ToString();

            ten = txtTen.Text;
            giaban = txtGiaban.Text;
            donvi = txtDonvi.Text;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (ten != txtTen.Text || giaban != txtGiaban.Text || donvi != txtDonvi.Text)
            {
                //sửa đổi
                String maHang = this.row.Cells["MaHangHoa"].Value.ToString();
                int i = this.kn.query("update KhoHang set TenHangHoa = N'" + txtTen.Text.Trim() + "', GiaBan = '" + txtGiaban.Text.Trim() + "', DonVi = N'" + txtDonvi.Text.Trim() + "' where MaHangHoa = '" + maHang + "'");
                if (i != 0)
                    MessageBox.Show("Sửa thông tin hàng hóa thành công !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Sửa thông tin hàng hóa thất bại !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


    
    
