using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace EvolveHealth
{
    public class dbHelper
    {
        

        string ConnectionString = "Data Source=xxx; database=xxx; uid=xx; pwd=xxxxxx; connection timeout = 30";

       
        public DataTable GetResultList()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "GetResultList";
                cmd.CommandType = CommandType.StoredProcedure;
                
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    using (DataSet ds = new DataSet())
                    {
                        da.Fill(ds);
                        return ds.Tables[0];
                    }
                }
            }
        }

        public bool DeleteData(int ID)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {               
                bool result = false;
                conn.Open();
                cmd.CommandText = "DeleteData";
                cmd.CommandType = CommandType.StoredProcedure;
                //'Parameters'
                cmd.Parameters.Add(new SqlParameter("@id", ID));
                
                int rowsDeletedCount = cmd.ExecuteNonQuery();
                if (rowsDeletedCount != 0)
                    result = true;
                //HttpContext.Current.Session[" result"] = result;
                return result;             
            }

        }


        public int UpdateData(int ID, string FName, string LName, string PhoneNumber, string EmailId, Boolean blnstatus)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                int savedID = 0;
                try
                {

                    conn.Open();
                    cmd.CommandText = "UpdateData";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //'Parameters'
                    cmd.Parameters.Add(new SqlParameter("@id", ID));
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LName;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = blnstatus;
                    //int rowsDeletedCount = cmd.ExecuteNonQuery();
                    
                    var commandResult = cmd.ExecuteNonQuery();
                    if (commandResult != 0)
                    {
                        savedID = Convert.ToInt32(commandResult);
                    }
                    
                }
                catch (Exception e)
                {
                }

               return savedID;
            }
        }



         public int InsertData(string FName, string LName, string PhoneNumber, string EmailId, Boolean blnstatus)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                int savedID = 0;
                try
                {

                    conn.Open();
                    cmd.CommandText = "InsertData";
                    cmd.CommandType = CommandType.StoredProcedure;
                    //'Parameters'
                   
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LName;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = PhoneNumber;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailId;
                    cmd.Parameters.Add("@Status", SqlDbType.Bit).Value = blnstatus;
                    //int rowsDeletedCount = cmd.ExecuteNonQuery();
                    var commandResult = cmd.ExecuteNonQuery();
                    if (commandResult != 0)
                    {
                        savedID = Convert.ToInt32(commandResult);
                    }

                }
                catch (Exception e)
                {

                }

                return savedID;
            }
        }












    }
}