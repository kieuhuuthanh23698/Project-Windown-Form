using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmDanhMucKhachHang : Form
    {
        KetNoiDuLieu kn;
        //String makh;

        public frmDanhMucKhachHang( KetNoiDuLieu kn,String makh)
        {
            this.kn = kn;
            //this.makh = makh;
            InitializeComponent();
            TaiGridViewKhachHang();
            btnHuyThem.Hide();
        }

        public void TaiGridViewKhachHang()
        {
            dataGridViewKhachHang.DataSource = this.kn.comManTable("select MaKhachHang,TenKhachHang,SoDienThoai from KhachHang","Khach Hang").Tables["Khach Hang"];
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.commandScalar("select MaKhachHang from KhachHang where MaKhachHang='" + s + "'").Trim();
            if (i == "")
            {
                return false;
            }
            return kq;
        }

        private string taoMaKhachHang()
        {
            int dem = 0;
            string i;
            do
            {
                i = this.kn.commandScalar("select MaKhachHang from KhachHang where MaKhachHang='KHACHHANG" + dem + "'").Trim();
                if (i == "")
                    break;//mã khách hàng này chưa có trong data table
                dem++;
            } while (i != "");
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
                string chuoisua = "update KhachHang set TenKhachHang=N'"+txtTen.Text+"',SoDienThoai='"+txtSDT.Text+"' where MaKhachHang='"+txtMa.Text+"'";
                int kq = this.kn.insert(chuoisua);
                if (kq != 0)
                {
                    MessageBox.Show("Đã sửa thành công!");
                    TaiGridViewKhachHang();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!");
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                //xóa chi tiết hóa đơn có mã hóa đơn
                //xóa hóa đon có mã khách hàng
                //xóa khách hàng
                
                //delete ChiTietHoaDon
                //from ChiTietHoaDon,HoaDon, KhachHang
                //where ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon and HoaDon.MaKhachHang = KhachHang.MaKhachHang and KhachHang.MaKhachHang = 'KHACHHANG4'

                //delete HoaDon
                //where HoaDon.MaKhachHang = 'KHACHHANG4'

                //delete KhachHang
                //where MaKhachHang = 'KHACHHANG4'

                string chuoixoahd = "delete HoaDon from HoaDon,KhachHang where HoaDon.MaKhachHang=KhachHang.MaKhachHang and HoaDon.MaKhachHang='"+txtMa.Text+"'";
                int kq = this.kn.insert(chuoixoahd);
                if (kq != 0)
                {
                    string chuoixoakh = "delete KhachHang from KhachHang where MaKhachHang='"+txtMa.Text+"'";
                    kq = this.kn.insert(chuoixoakh);
                    if (kq != 0)
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        TaiGridViewKhachHang();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
            }
            else
                MessageBox.Show("Xóa thất bại!");
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (txtTen.Text != "" && txtSDT.Text != "")
            {
                    int kq = this.kn.insert("insert into KhachHang values('" + txtMa.Text + "',N'" + txtTen.Text + "','" + txtSDT.Text + "')");
                    if (kq == 0)
                        MessageBox.Show("Khong them duoc");
                    else
                    {
                        MessageBox.Show("Thêm thành công");
                        TaiGridViewKhachHang();
                        btnXoa.Enabled = btnChinhsua.Enabled = btnThem.Enabled = true;
                        btnLuu.Enabled = false;
                        btnHuyThem.Hide();
                        txtMa.Text = txtSDT.Text = txtTen.Text = "";
                    }
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
                txtMa.Text = item_row.Cells[0].Value.ToString();
                txtTen.Text = item_row.Cells[1].Value.ToString();
                txtSDT.Text = item_row.Cells[2].Value.ToString();
            }
        }



 
    }
}
