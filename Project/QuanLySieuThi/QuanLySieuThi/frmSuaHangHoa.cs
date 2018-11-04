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
            if ((ten != txtTen.Text || giaban != txtGiaban.Text || donvi != txtDonvi.Text) && txtTen.Text != "" && txtGiaban.Text != "" && txtDonvi.Text != "")
            {
                try
                {
                    //sửa đổi
                    String maHang = this.row.Cells["MaHangHoa"].Value.ToString();

                    SqlConnection sql = this.kn.getSql();
                    string queryKhohang = "select * from KhoHang";
                    SqlDataAdapter daKhoHang = new SqlDataAdapter(queryKhohang, sql);
                    DataTable tbKhoHang = new DataTable("KhoHang");
                    daKhoHang.Fill(tbKhoHang);

                    int n = tbKhoHang.Rows.Count;
                    for (int i = 0; i < n; i++)
                    {
                        if (maHang.Trim() == tbKhoHang.Rows[i]["MaHangHoa"].ToString().Trim())
                        {
                            tbKhoHang.Rows[i]["TenHangHoa"] = txtTen.Text;
                            tbKhoHang.Rows[i]["GiaBan"] = txtGiaban.Text;
                            tbKhoHang.Rows[i]["DonVi"] = txtDonvi.Text;

                            SqlCommandBuilder scb = new SqlCommandBuilder(daKhoHang);
                            scb.GetUpdateCommand();
                            daKhoHang.Update(tbKhoHang);
                            MessageBox.Show("Sửa thông tin hàng hóa thành công !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            return;
                        }
                    }
                    MessageBox.Show("Sửa thông tin hàng hóa thất bại !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),"EXCEPTION",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    MessageBox.Show("Sửa thông tin hàng hóa thất bại !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            else
            {
                if(txtTen.Text == "")
                    MessageBox.Show("Bạn chưa nhập tên hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if(txtDonvi.Text == "")
                    MessageBox.Show("Bạn chưa nhập đơn vị hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (txtGiaban.Text == "")
                    MessageBox.Show("Bạn chưa nhập giá bán của hàng hóa !", "SỬA THÔNG TIN HÀNG HÓA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


    
    
