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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtSoLuongThem.Text.Length > 0)
            {
                try
                {
                    int soLuongThem = int.Parse(txtSoLuongThem.Text);
                    int soLuongTrongKho = int.Parse(row.Cells["SoluongTrongKho"].Value.ToString().Trim());

                    SqlConnection sql = this.link.getSql();
                    string queryKhohang = "select * from KhoHang";
                    SqlDataAdapter daKhoHang = new SqlDataAdapter(queryKhohang, sql);
                    DataTable tbKhoHang = new DataTable("KhoHang");
                    daKhoHang.Fill(tbKhoHang);

                    int n = tbKhoHang.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (tbKhoHang.Rows[i]["MaHangHoa"].ToString().Trim() == maHangHoa.Trim())
                        {
                            tbKhoHang.Rows[i]["SoLuongTrongKho"] = (soLuongThem + soLuongTrongKho).ToString();
                            SqlCommandBuilder scb = new SqlCommandBuilder(daKhoHang);
                            scb.GetUpdateCommand();
                            daKhoHang.Update(tbKhoHang);
                            MessageBox.Show("Nhập hàng hóa thành công !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    }
                    MessageBox.Show("Nhập hàng hóa thất bại !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                catch(Exception ex)
                {

                    MessageBox.Show("Nhập hàng hóa thất bại !", "NHẬP HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show(ex.ToString(), "EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
        }

        private void txtSoLuongThem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) == false && Char.IsControl(e.KeyChar) == false)
                e.Handled = true;
        }
    }
}
