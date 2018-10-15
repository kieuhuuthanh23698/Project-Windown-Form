using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class frmReportHoaDon : Form
    {
        public frmReportHoaDon()
        {
            InitializeComponent();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            Phieubaogia pbg = new Phieubaogia();
            crystalReportViewer1.ReportSource = pbg;
            pbg.SetDatabaseLogon("sa", "sa2012", "GMK1KUGNFEEWJKV\\SQLEXPRESS", "QL_SIEUTHI");
            crystalReportViewer1.Refresh();
        }

    }
}
