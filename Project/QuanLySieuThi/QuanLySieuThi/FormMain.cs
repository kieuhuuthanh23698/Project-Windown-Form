using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QuanLySieuThi
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            hoaDon f = new hoaDon();
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;
            dockContainerItem1.Control.Controls.Add(f);
            f.Show();
        }
    }
}
