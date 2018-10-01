using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmHoaDon : Form
    {
        KetNoiDuLieu link;
        String manv;

        public frmHoaDon(KetNoiDuLieu link, String manv)
        {
            this.link = link;
            this.manv = manv;
            InitializeComponent();
            taiGridViewHangHoa();
        }

        public void taiGridViewHangHoa()
        {
            dataGridViewHangHoa.DataSource = this.link.comManTable("select MaHangHoa as N'Mã hàng hóa', TenHangHoa as N'Tên hàng hóa', GiaBan as N'Giá bán', DonVi as N'Đơn vị', SoluongTrongKho as N'Tồn kho' from KhoHang","Hang hoa").Tables["Hang hoa"];
        }
    }
}
