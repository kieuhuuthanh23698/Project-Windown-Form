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
    public partial class frmDanhMucKhachHang : Form
    {
        KetNoiDuLieu kn;

        public frmDanhMucKhachHang( KetNoiDuLieu kn)
        {
            this.kn = kn;
            InitializeComponent();
            TaiGridViewKhachHang();
            loadAutoCompleteTextTimKiemNhanVien();
            btnHuyThem.Hide();
        }

        public void loadAutoCompleteTextTimKiemNhanVien()
        {
            try
            {
                SqlDataReader dr = this.kn.comManReader("select TenKhachHang from KhachHang", "TenKhachHang");
                while (dr.Read())
                {
                    txtTimKiem.AutoCompleteCustomSource.Add(dr[0].ToString().Trim());
                }
                dr.Close();
                dr = this.kn.comManReader("select MaKhachHang from KhachHang", "MaKhangHang");
                while (dr.Read())
                {
                    txtTimKiem.AutoCompleteCustomSource.Add(dr[0].ToString().Trim());
                }
                dr.Close();
                dr = this.kn.comManReader("select SoDienThoai from KhachHang", "MaKhangHang");
                while (dr.Read())
                {
                    txtTimKiem.AutoCompleteCustomSource.Add(dr[0].ToString().Trim());
                }
                dr.Close();
                this.kn.closeConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void TaiGridViewKhachHang()
        {
            try
            {
                dataGridViewKhachHang.DataSource = this.kn.comManTable("select MaKhachHang,TenKhachHang,SoDienThoai from KhachHang", "Khach Hang").Tables["Khach Hang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool KtraKhoaChinh(string s)
        {
            try
            {
                bool kq = true;
                string i = this.kn.comMandScalar("select MaKhachHang from KhachHang where MaKhachHang='" + s + "'").Trim();
                if (i == "")
                {
                    return false;
                }
                return kq;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        private string taoMaKhachHang()
        {
            int dem = 0;
            string i = "";
            try
            {
                do
                {
                    try
                    {
                        i = this.kn.comMandScalar("select MaKhachHang from KhachHang where MaKhachHang='KHACHHANG" + dem + "'").Trim();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    if (i == "")
                        break;//mã khách hàng này chưa có trong data table
                    dem++;
                } while (i != "");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return "KHACHHANG" + dem;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMa.Text = taoMaKhachHang();
            txtSDT.Text = txtTen.Text = "";
            txtTen.Focus();

            btnLuu.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnChinhsua.Enabled = dataGridViewKhachHang.Enabled = false;

            btnHuyThem.Show();      
        }

        private void btnChinhsua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "" && txtTen.Text != "" && txtSDT.Text != "")
            {
                try
                {
                    string chuoisua = "update KhachHang set TenKhachHang=N'" + txtTen.Text + "',SoDienThoai='" + txtSDT.Text + "' where MaKhachHang='" + txtMa.Text + "'";
                    int kq = this.kn.query(chuoisua);
                    if (kq != 0)
                    {
                        MessageBox.Show("Đã sửa thành công!", "SỬA KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiGridViewKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!", "SỬA KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count!=0)
            {
                //xóa chi tiết hóa đơn có mã hóa đơn
                //xóa hóa đon có mã khách hàng
                //xóa khách hàng

                try
                {
                    string chuoixoacthd = "delete ChiTietHoaDon from ChiTietHoaDon,HoaDon, KhachHang where ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and HoaDon.MaKhachHang = KhachHang.MaKhachHang and KhachHang.MaKhachHang = '" + txtMa.Text + "'";
                    int kq = this.kn.query(chuoixoacthd);
                    string chuoixoahd = "delete HoaDon where HoaDon.MaKhachHang = '" + txtMa.Text + "'";
                    kq = this.kn.query(chuoixoahd);
                    string chuoixoakh = "delete KhachHang where MaKhachHang = '" + txtMa.Text + "'";
                    kq = this.kn.query(chuoixoakh);
                    if (kq != 0)
                    {
                        MessageBox.Show("Xóa thành công!", "XÓA KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMa.Text = txtSDT.Text = txtTen.Text = "";
                        TaiGridViewKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "XÓA KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Bạn chưa chọn khách hàng cần xóa!", "XÓA KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtTen.Text != "" && txtSDT.Text != "")
                {
                    int kq = this.kn.query("insert into KhachHang values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + txtSDT.Text + "')");
                    if (kq == 0)
                        MessageBox.Show("Thêm khách hàng thất bại !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        MessageBox.Show("Thêm thành công !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TaiGridViewKhachHang();
                        btnXoa.Enabled = btnChinhsua.Enabled = btnThem.Enabled = dataGridViewKhachHang.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuyThem.Hide();
                        txtMa.Text = txtSDT.Text = txtTen.Text = "";
                    }
                }
                else
                {
                    if (txtTen.Text == "")
                        MessageBox.Show("Bạn chưa nhập tên khách hàng !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (txtSDT.Text == "")
                        MessageBox.Show("Bạn chưa nhập số điện thoại khách hàng !", "THÊM KHÁCH HÀNG", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnHuyThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnChinhsua.Enabled = true;
            dataGridViewKhachHang.Enabled = true;
            txtMa.Text = txtSDT.Text = txtTen.Text = "";
            btnHuyThem.Hide();
        }

        private void dataGridViewKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewKhachHang.SelectedRows.Count != 0)
            {
                DataGridViewRow item_row = dataGridViewKhachHang.SelectedRows[0];
                txtMa.Text = item_row.Cells[0].Value.ToString().Trim();
                txtTen.Text = item_row.Cells[1].Value.ToString().Trim();
                txtSDT.Text = item_row.Cells[2].Value.ToString().Trim();
            }
        }

        private void dataGridViewKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    string chuoikh = " select MaKhachHang,TenKhachHang,SoDienThoai from KhachHang";
            //    dataGridViewKhachHang.DataSource = this.kn.comManTable(chuoikh, "KhachHang").Tables["KhachHang"];
            //    //txtMa.DataBindings.Clear();
            //    txtMa.DataBindings.Add("text", dataGridViewKhachHang.DataSource, "KhachHang.MaKhachHang");
            //    //txtTen.DataBindings.Clear();
            //    txtTen.DataBindings.Add("text", dataGridViewKhachHang.DataSource, "KhachHang.TenKhachHang");
            //    //txtSDT.DataBindings.Clear();
            //    txtMa.DataBindings.Add("text", dataGridViewKhachHang.DataSource, "KhachHang.SoDienThoai");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtTimKiem.Text == "")
                    TaiGridViewKhachHang();
                else
                    dataGridViewKhachHang.DataSource = this.kn.comManTable("select * from KhachHang where MaKhachHang = '" + txtTimKiem.Text + "' or TenKhachHang = N'" + txtTimKiem.Text + "' or SoDienThoai = '" + txtTimKiem.Text + "'", "KhachHang").Tables["KhachHang"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
