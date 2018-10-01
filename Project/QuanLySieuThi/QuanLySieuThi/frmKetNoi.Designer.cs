namespace QuanLySieuThi
{
    partial class frmKetNoi
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
            this.components = new System.ComponentModel.Container();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.btnConn = new DevComponents.DotNetBar.ButtonX();
            this.txtDataSource = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtIni = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.AutoSize = true;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(132, 39);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(243, 25);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "KẾT NỐI CƠ SỞ DỮ LIỆU";
            // 
            // btnConn
            // 
            this.btnConn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnConn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnConn.FocusCuesEnabled = false;
            this.btnConn.Location = new System.Drawing.Point(204, 340);
            this.btnConn.Name = "btnConn";
            this.btnConn.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnConn.TabIndex = 1;
            this.btnConn.Text = "Connect";
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // txtDataSource
            // 
            // 
            // 
            // 
            this.txtDataSource.Border.Class = "TextBoxBorder";
            this.txtDataSource.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDataSource.Location = new System.Drawing.Point(186, 104);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(285, 22);
            this.txtDataSource.TabIndex = 2;
            this.txtDataSource.Text = "LAPTOP-CQ1BQQH5\\SQLEXPRESS";
            this.txtDataSource.Leave += new System.EventHandler(this.txtDataSource_Leave);
            // 
            // labelX2
            // 
            this.labelX2.AutoSize = true;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(60, 105);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(71, 17);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "Data Source";
            // 
            // labelX3
            // 
            this.labelX3.AutoSize = true;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(60, 153);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 17);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "Innitial Catalog";
            // 
            // txtIni
            // 
            // 
            // 
            // 
            this.txtIni.Border.Class = "TextBoxBorder";
            this.txtIni.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtIni.Location = new System.Drawing.Point(186, 152);
            this.txtIni.Name = "txtIni";
            this.txtIni.Size = new System.Drawing.Size(285, 22);
            this.txtIni.TabIndex = 4;
            this.txtIni.Text = "QL_SIEUTHI";
            this.txtIni.Leave += new System.EventHandler(this.txtIni_Leave);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.Location = new System.Drawing.Point(60, 199);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "User ID";
            // 
            // txtID
            // 
            // 
            // 
            // 
            this.txtID.Border.Class = "TextBoxBorder";
            this.txtID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtID.Location = new System.Drawing.Point(186, 201);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(285, 22);
            this.txtID.TabIndex = 6;
            this.txtID.Text = "sa";
            this.txtID.Leave += new System.EventHandler(this.txtID_Leave);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(60, 255);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Password";
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(186, 257);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '#';
            this.txtPass.Size = new System.Drawing.Size(285, 22);
            this.txtPass.TabIndex = 8;
            this.txtPass.Text = "23698";
            this.txtPass.Leave += new System.EventHandler(this.txtPass_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // KetNoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 392);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.txtIni);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtDataSource);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.labelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "KetNoi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DATABASE CONNECTION";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btnConn;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDataSource;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtIni;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtID;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}