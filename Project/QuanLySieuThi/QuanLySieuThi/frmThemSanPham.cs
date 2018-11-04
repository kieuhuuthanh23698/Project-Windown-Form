using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmThemSanPham : Form
    {
        KetNoiDuLieu link;

        public frmThemSanPham(KetNoiDuLieu link)
        {
            this.link = link;
            InitializeComponent();
            taiComBBNhomMathang();
            taoMaHangHoa();
        }

        public void taiComBBNhomMathang() // ok
        {
            SqlDataReader rd = this.link.comManReader("select TenLoaiHangHoa from LoaiHangHoa", "LoaiHangHoa");
            while (rd.Read())
            {
                cbbNhomMatHang.Items.Add(rd["TenLoaiHangHoa"].ToString());
            }
            rd.Close();
            if (this.link.state() == ConnectionState.Open)
                this.link.closeConnection();
            cbbNhomMatHang.SelectedIndex = 0;
        }

        public void taoMaHangHoa() // ok
        {
            string maLoaiHangHoa = this.link.comMandScalar("select MaLoaiHangHoa from LoaiHangHoa where TenLoaiHangHoa = N'" + cbbNhomMatHang.SelectedItem.ToString().Trim() + "'");
            txtMa.Text = maLoaiHangHoa + (int.Parse(this.link.comMandScalar("select count(*) from KhoHang where LoaiHangHoa = N'" + cbbNhomMatHang.SelectedItem.ToString().Trim() + "'")) + 1);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbNhomMatHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbNhomMatHang_SelectedValueChanged(object sender, EventArgs e)
        {
            taoMaHangHoa();
        }

        private void txtGiamua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTen.Text != "" && txtDonvi.Text != "" && txtGiaban.Text != "" && txtGiamua.Text != "")
            {
                string chuoiThem = "INSERT INTO KhoHang VALUES('" + txtMa.Text.Trim() + "',N'" + txtTen.Text.Trim() + "',N'" + cbbNhomMatHang.SelectedItem.ToString().Trim() + "'," + txtGiaban.Text.Trim() + "," + txtGiamua.Text.Trim() + ",N'" + txtDonvi.Text.Trim() + "',0)";
                int kqThem = this.link.query(chuoiThem);
                if (kqThem != 0)
                    MessageBox.Show("Thêm hàng hóa thành công !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Thêm hàng hóa thất bại !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
