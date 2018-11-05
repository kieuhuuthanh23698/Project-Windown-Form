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

        public void taiComBBNhomMathang()
        {
            try
            {
                SqlDataReader rd = this.link.comManReader("select TenLoaiHangHoa from LoaiHangHoa", "LoaiHangHoa");
                while (rd.Read())
                {
                    cbbNhomMatHang.Items.Add(rd["TenLoaiHangHoa"].ToString());
                }
                rd.Close();
                this.link.closeConnection();
                cbbNhomMatHang.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void taoMaHangHoa()
        {
            try
            {
                string maLoaiHangHoa = this.link.comMandScalar("select MaLoaiHangHoa from LoaiHangHoa where TenLoaiHangHoa = N'" + cbbNhomMatHang.SelectedItem.ToString().Trim() + "'");
                txtMaNhomMatHang.Text = maLoaiHangHoa;
                int count;
                int i = 0;
                do
                {
                    count = int.Parse(this.link.comMandScalar("select count(*) from KhoHang where MaHangHoa = '" + maLoaiHangHoa + i + "'"));
                    if (count == 0)
                    {
                        txtMa.Text = maLoaiHangHoa + i;
                        break;
                    }
                    i++;
                }
                while (count != 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
                try
                {
                    SqlConnection sql = this.link.getSql();
                    string queryKhoHang = "select * from KhoHang";
                    SqlDataAdapter daKhoHang = new SqlDataAdapter(queryKhoHang, sql);
                    DataTable tbKhoHang = new DataTable("KhoHang");
                    daKhoHang.Fill(tbKhoHang);

                    DataRow newRow = tbKhoHang.NewRow();
                    newRow[0] = txtMa.Text;
                    newRow[1] = txtTen.Text;
                    newRow[2] = txtMaNhomMatHang.Text;
                    newRow[3] = txtGiaban.Text;
                    newRow[4] = txtGiamua.Text;
                    newRow[5] = txtDonvi.Text;
                    newRow[6] = 0;

                    tbKhoHang.Rows.Add(newRow);

                    SqlCommandBuilder scb = new SqlCommandBuilder(daKhoHang);
                    scb.GetInsertCommand();
                    daKhoHang.Update(tbKhoHang);
                    MessageBox.Show("Thêm hàng hóa thành công !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm hàng hóa thất bại !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                if (txtTen.Text == "")
                    MessageBox.Show("Bạn chưa nhập tên hàng hóa !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtDonvi.Text == "")
                    MessageBox.Show("Bạn chưa nhập đơn vị của hàng hóa !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtGiaban.Text == "")
                    MessageBox.Show("Bạn chưa nhập giá bán !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtGiamua.Text == "")
                    MessageBox.Show("Bạn chưa nhập giá mua !", "THÊM HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
