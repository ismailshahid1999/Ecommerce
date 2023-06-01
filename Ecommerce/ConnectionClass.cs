using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Ecommerce
{
    public class ConnectionClass
    {
        
            SqlConnection con;
            SqlCommand cmd;

            public ConnectionClass()
            {
                con = new SqlConnection(@"server=LAPTOP-RJOBUH67\SQLEXPRESS;database=ecommerce;integrated security=true");
            }

            public int fun_NonQuery(string sqlquery)  //insert,delete,update
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(sqlquery, con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                con.Close();
                return i;
            }

            public string fun_Scalar(string sqlquery)  //scalar functions
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(sqlquery, con);
                con.Open();
                string j = cmd.ExecuteScalar().ToString();
                con.Close();
                return j;
            }

            public SqlDataReader fun_reader(string sqlquery)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd = new SqlCommand(sqlquery, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }

            public DataSet fun_dataset(string sqlquery)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlquery, con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
        
    }
}