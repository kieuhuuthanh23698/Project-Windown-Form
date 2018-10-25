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
    public partial class frmReportHoaDon : Form
    {
        KetNoiDuLieu link;
        string maHoaDon;
        
        public frmReportHoaDon(KetNoiDuLieu link,string maHoaDon)
        {
            this.link = link;
            this.maHoaDon = maHoaDon;
            InitializeComponent();
            crystalReportViewer1.RefreshReport();

        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            Phieubaogia pbg = new Phieubaogia();
            string chuoiQuery = "select * from ChiTietHoaDon, HoaDon where HoaDon.MaHoaDon = '" + maHoaDon + "' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon";
            DataTable dt = this.link.comManTable(chuoiQuery,"ChiTietHoaDon").Tables["ChiTietHoaDon"];
            pbg.SetDataSource(dt);
            crystalReportViewer1.ReportSource = pbg;
            crystalReportViewer1.Refresh();
        }

    }
}
