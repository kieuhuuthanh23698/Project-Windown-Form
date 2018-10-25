namespace QuanLySieuThi
{
    partial class frmReportHoaDon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.reportDocument1 = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btn_Show = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1065, 502);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelWidth = 267;
            // 
            // btn_Show
            // 
            this.btn_Show.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_Show.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_Show.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Show.Location = new System.Drawing.Point(13, 37);
            this.btn_Show.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Show.Name = "btn_Show";
            this.btn_Show.Size = new System.Drawing.Size(244, 28);
            this.btn_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_Show.TabIndex = 1;
            this.btn_Show.Text = "Show Report";
            this.btn_Show.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // frmReportHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 502);
            this.Controls.Add(this.btn_Show);
            this.Controls.Add(this.crystalReportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReportHoaDon";
            this.Text = "frmReportHoaDon";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private DevComponents.DotNetBar.ButtonX btn_Show;
    }
}