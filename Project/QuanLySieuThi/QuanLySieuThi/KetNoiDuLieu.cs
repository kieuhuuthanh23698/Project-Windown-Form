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

            this.sql = new SqlConnection(chuoiKetNoi);
            this.chuoiKetNoi = chuoiKetNoi;
        }

        public bool Connec() 
        {
            try
            {
                if(this.sql.State == ConnectionState.Closed)
                    sql.Open();
                if(this.sql.State == ConnectionState.Open)
                    sql.Close();
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

        public string commandScalar(string chuoiCommand)
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
                if (this.sql.State == ConnectionState.Closed)
                    this.sql.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(chuoiComMand, this.sql);
                sda.Fill(ds, srcTable);
                
                if (this.sql.State == ConnectionState.Open)
                    this.sql.Close();
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

        public int insert(string chuoiComMand)
        {
            if (this.sql.State == ConnectionState.Closed)
                this.sql.Open();
            
            SqlCommand com = new SqlCommand(chuoiComMand, this.sql);
            int kq = com.ExecuteNonQuery();
            
            if (this.sql.State == ConnectionState.Open)
                this.sql.Close();
            return kq;
        }
        
    }
}
