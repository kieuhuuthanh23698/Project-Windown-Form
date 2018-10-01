using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
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

        public DataSet comManTable(string chuoiComMand, string srcTable)
        {
            if (this.sql.State == ConnectionState.Closed)
                this.sql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(chuoiComMand, this.sql);
            sda.Fill(ds, srcTable);
            return ds;
        }
    }
}
