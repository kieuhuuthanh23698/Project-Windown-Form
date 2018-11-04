using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace QuanLySieuThi
{
    public class KetNoiDuLieu
    {
        private string chuoiKetNoi;
        private SqlConnection sql;

        public void openConnection()
        {
            if (this.sql.State == ConnectionState.Closed)
                sql.Open();
        }

        public void closeConnection()
        {
            if (this.sql.State == ConnectionState.Open)
                sql.Close();
        }

        public SqlConnection getSql()
        {
            return this.sql;
        }

        public KetNoiDuLieu(string chuoiKetNoi)
        {

            this.sql = new SqlConnection(chuoiKetNoi);
            this.chuoiKetNoi = chuoiKetNoi;
        }

        public bool Connec() // có thể kết nối vào sever
        {
            try
            {
                openConnection();
                closeConnection();
                return true; 
            }
            catch(Exception)
            {
                return false;
            }
        }

        public System.Data.ConnectionState state()
        {
            return this.sql.State;
        }

        public string comMandScalar(string chuoiCommand)
        {
            try
            {
                if (this.sql.State == ConnectionState.Closed)
                    this.sql.Open();
                SqlCommand com = new SqlCommand(chuoiCommand, this.sql);
                string kq = com.ExecuteScalar() + "";
                if (this.sql.State == ConnectionState.Open)
                    this.sql.Close();
                return kq.Trim();
            }
            catch(Exception)
            {
                return "";
            }
        }

        public DataSet comManTable(string chuoiComMand, string srcTable)
        {
            try
            {
                openConnection();

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(chuoiComMand, this.sql);
                sda.Fill(ds, srcTable);

                closeConnection();
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SqlDataReader comManReader(string chuoiComMand, string srcTable)
        {
            try
            {
                if (this.sql.State == ConnectionState.Closed)
                    this.sql.Open();

                SqlCommand com = new SqlCommand(chuoiComMand, this.sql);
                SqlDataReader kq = com.ExecuteReader();
                
                return kq;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int query(string chuoiComMand)
        {
            openConnection();
            
            SqlCommand com = new SqlCommand(chuoiComMand, this.sql);
            int kq = com.ExecuteNonQuery();

            closeConnection();
            return kq;
        }
        
    }
}
