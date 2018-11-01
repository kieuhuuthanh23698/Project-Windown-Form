using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QuanLySieuThi
{
    public partial class frmReportHoaDon : Form
    {
        KetNoiDuLieu link;
        string maHoaDon;
        DataTable dt;
   
        public frmReportHoaDon(KetNoiDuLieu link,string maHoaDon)
        {
            this.link = link;
            this.maHoaDon = maHoaDon;
            InitializeComponent();
            crystalReportViewer1.RefreshReport();
            //
            Phieubaogia pbg = new Phieubaogia();
            string chuoiQuery = "select * from ChiTietHoaDon, HoaDon where HoaDon.MaHoaDon = '" + maHoaDon + "' and ChiTietHoaDon.MaHoaDon = HoaDon.MaHoaDon";
            dt = this.link.comManTable(chuoiQuery, "ChiTietHoaDon").Tables["ChiTietHoaDon"];
            pbg.SetDataSource(dt);
            crystalReportViewer1.ReportSource = pbg;
            crystalReportViewer1.Refresh();
            MessageBox.Show(Application.StartupPath);
        }

        private void btnExportFilePDF_Click(object sender, EventArgs e)
        {
            ///xuất report ra file pdf
            try
            {
                ReportDocument rd = new ReportDocument();
                //rd.Load(@"C:\Users\ACER-PC\Documents\GitHub\Project-Windown-Form-Phan-mem-quan-ly-sieu-thi\Project\QuanLySieuThi\QuanLySieuThi\Phieubaogia.rpt");
                rd.Load(Application.StartupPath + "\\Phieubaogia.rpt");
                rd.SetDataSource(dt);
                rd.ExportToDisk(ExportFormatType.PortableDocFormat, maHoaDon + ".pdf");
                MessageBox.Show("Đã export report ra file " + maHoaDon + ".pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
