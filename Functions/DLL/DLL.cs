using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.Data_Link_Layer
{
    public class DLL
    {
        string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
        public string InsertMessage(string Name,string Email, string Subject,string Message)
        {
            string response="";
            using (SqlCommand cmd=new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertmessage";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = Name;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@subject", SqlDbType.VarChar).Value = Subject;
                    cmd.Parameters.Add("@message", SqlDbType.VarChar).Value = Message;
                    using(SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public string RegisterUser(string FName, string MName, string LName, string Email, string UName, string Password, int Ward)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RegisterUser";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@fname", SqlDbType.VarChar).Value = FName;
                    cmd.Parameters.Add("@mname", SqlDbType.VarChar).Value = MName;
                    cmd.Parameters.Add("@lname", SqlDbType.VarChar).Value = LName;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = Email;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UName;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
                    cmd.Parameters.Add("@ward", SqlDbType.VarChar).Value = Ward;
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public string LoginUser(string UName, string Password)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LoginUser";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = UName;
                    cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = Password;
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }
                }
            }
            return response;
        }
        public List<string> DatafromUserTable(string name) // tuple return type
        {
            List<string> s2=new List<string>();
            string fname="";
            string mname="";
            string lname="";
            string email="";
            string username="";
            string ward="";
            string phone = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select* from Users where Username=@name";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                fname = Convert.ToString(sd["FName"]);
                                mname = Convert.ToString(sd["MName"]);
                                lname = Convert.ToString(sd["LName"]);
                                email = Convert.ToString(sd["Email"]);
                                username = Convert.ToString(sd["Username"]);
                                ward = Convert.ToString(sd["Ward"]);
                                s2.Add(fname);
                                s2.Add(mname);
                                s2.Add(lname);
                                s2.Add(email);
                                s2.Add(username);
                                s2.Add(ward);
                            }
                        }
                    }
                }
            }
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select* from ExtraUserData where Username=@name";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                phone = Convert.ToString(sd["PhoneNo"]);
                                s2.Add(phone);
                            }
                        }
                    }
                }
            }
            return s2;
        }
        public DataTable GetData(SqlCommand cmd,string name)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conval);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select* from ExtraUserData where Username=@name";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@name", name);

            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }
        public string UpdateUsersTable(string fname, string mname, string lname, string phone, string ward, string name)
        {
            string response = "";
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateProfile";
                using (SqlConnection conn1 = new SqlConnection(conval))
                {
                    cmd.Connection = conn1;
                    conn1.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.AddWithValue("@fname", fname);
                    cmd.Parameters.AddWithValue("@mname", mname);
                    cmd.Parameters.AddWithValue("@lname", lname);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@ward", ward);
                    cmd.Parameters.AddWithValue("@name", name);
                    using (SqlDataReader sd = cmd.ExecuteReader())
                    {
                        if (sd.HasRows)
                        {
                            while (sd.Read())
                            {
                                response = sd.GetString(0);
                            }
                        }
                    }

                }
            }
            return response;
        }
        public void UpdateUserImage(byte[] pic,string name)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Update ExtraUserData set Image=@img where Username=@name";
                using (SqlConnection conn = new SqlConnection(conval))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@img", SqlDbType.Image).Value = pic;
                    cmd.Parameters.AddWithValue("@name", name);
                    int n = cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
