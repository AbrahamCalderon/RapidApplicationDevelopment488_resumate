using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class SQLConnection
    {
        private SqlConnection conn;


        // establish connection to the database
        public SQLConnection()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "server=sql.cs.luc.edu;uid=efallatah;pwd=p17242;Initial catalog=resumate";
            conn.Open();
        }


        // processes SELECT sql statements
        public DataTableCollection ExcuteSelect(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataSet toReturn = new DataSet();
            try
            {
                da.Fill(toReturn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling the DataSet with the SqlDataAdapter. " 
                    + "In addition, the following exception was thrown " + ex.ToString());
            }
            da.Dispose();

            return toReturn.Tables;
        }




        // processes SELECT sql statements
        public DataSet ExcuteSelectDS(string sql)
        {
            DataSet toReturn = new DataSet();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            try
            {
                da.Fill(toReturn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error filling the DataSet with the SqlDataAdapter. "
                    + "In addition, the following exception was thrown " + ex.ToString());
            }
            da.Dispose();

            return toReturn;
        }


        // processes INSERT, UPDATE and DELETE sql statements
        public int ExcuteAction(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            int result = 0;

            try
            {
                result = comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing sql statement. In addition, the following exception was thrown " + ex.ToString());
            }
                

            return result;
        }
    }
}