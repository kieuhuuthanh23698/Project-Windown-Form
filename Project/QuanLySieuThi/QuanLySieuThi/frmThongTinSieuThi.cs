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
    public partial class frmThongTinSieuThi : Form
    {
        KetNoiDuLieu kn;
        string ttst;
        public frmThongTinSieuThi(KetNoiDuLieu kn, string ttst)
        {
            this.kn = kn;
            this.ttst = ttst;
            InitializeComponent();
            TaiLenTextbox();
        }

        public void TaiLenTextbox()
        {
            SqlDataReader rd  = this.kn.comManReader("select TenSieuThi,DiaChiSieuThi,SoDT,TenChuSieuThi,CongQuy from ThongTinSieuThi","ThongTinSieuThi");
            while (rd.Read())
            {
                txtTenst.Text = rd[0].ToString();
                txtDiachi.Text = rd[1].ToString();
                txtSdt.Text = rd[2].ToString();
                txtTenchu.Text = rd[3].ToString();
                txtThunhap.Text = rd[4].ToString();
            }
            rd.Close();
            if (this.kn.state() == ConnectionState.Open)
                this.kn.sql.Close();
        }

        private int KtraTTST(string tenst, string dchi, string sdt, string tenchu, float cq)
        {
            int cmd = this.kn.insert("update ThongTinSieuThi set TenSieuThi=N'"+tenst+"', DiaChiSieuThi=N'"+dchi+"',SoDT='"+sdt+"',TenChuSieuThi=N'"+tenchu+"',CongQuy="+cq+"");
            if (cmd != 0)
                return 1;
            else
                return 0;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            string tenst = txtTenst.Text;
            string dchi = txtDiachi.Text;
            string sdt = txtSdt.Text;
            string tenchu = txtTenchu.Text;
            float cq = float.Parse(txtThunhap.Text);
            int kq = KtraTTST(tenst, dchi, sdt, tenchu, cq);
            if (kq == 1)
            {
                MessageBox.Show("Lưu thông tin thành công!");
            }
            else
            {
                MessageBox.Show("Thông tin này như lúc ban đầu!");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
