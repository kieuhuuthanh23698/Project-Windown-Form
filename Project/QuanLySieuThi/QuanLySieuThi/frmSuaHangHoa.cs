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
        KetNoiDuLieu kn;
        string mahh;
        public frmSuaHangHoa()
        {
            InitializeComponent();
        }

        private bool KtraKhoaChinh(string s)
        {
            bool kq = true;
            string i = this.kn.commandScalar("select MaNhanVien from NhanVien where MaNhanVien='" + s + "'").Trim();
            if (i == "")
            {
                return false;
            }
            return kq;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMa.Text != "")
            {
                if (KtraKhoaChinh(txtMa.Text) == true)
                {
                    MessageBox.Show("Mã mặt hàng đã tồn tại!");
                }
                else
                {
                    frmDanhMucMatHang f = new frmDanhMucMatHang(this.kn,mahh);
                    
                }
            }
        }


    
    }
}
