using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;


namespace QuanLySieuThi
{
    public class KetNoiDuLieu
    {
        public string chuoiKetNoi;
        public SqlConnection sql;

        public KetNoiDuLieu(string chuoiKetNoi)
        {
            this.chuoiKetNoi = chuoiKetNoi;
            Connec();
        }

        public void Connec() 
        {
            this.sql = new SqlConnection(this.chuoiKetNoi);
            if (sql.State == System.Data.ConnectionState.Closed)
                sql.Open();
        }

        public System.Data.ConnectionState state()
        {
            return this.sql.State;
        }

        public string commandScalar(string chuoiCommand)
        {
            SqlCommand com = new SqlCommand(chuoiCommand, this.sql);
            return com.ExecuteScalar() + "";
        }
    }
}
