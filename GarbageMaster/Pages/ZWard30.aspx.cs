using Functions.Data_Link_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarbageMaster.Pages
{
    public partial class ZWard30 : System.Web.UI.Page
    {
        public DLL _dll;
        public ZWard30()
        {
            _dll = new DLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null || Session["Role"] == null)
            {
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                GetData();
                string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
                List<int> list = new List<int>();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "findaverage";
                    using (SqlConnection conn = new SqlConnection(conval))
                    {
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.CommandTimeout = 30;
                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (rd.HasRows)
                            {
                                while (rd.Read())
                                {
                                    list.Add(Convert.ToInt32(rd[0]));
                                }
                            }
                        }
                    }
                }
                Label30.Text = Convert.ToString(list[29]);
            }
        }
        private void GetData()
        {
            DataTable table = _dll.Extractwastewithwarddata(30);
            GridView1.DataSource = table;
            int a = table.Rows.Count;
            if (a != 0)
            {
                GridView1.DataBind();
            }

        }
        protected void TruckSent(object sender, EventArgs e)
        {
            string conval = ConfigurationManager.ConnectionStrings["myconnection"].ConnectionString;
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "settozero";
                using (SqlConnection conn = new SqlConnection(conval))
                {
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.CommandTimeout = 30;
                    cmd.Parameters.Add("@ward", SqlDbType.Int).Value = 30;
                    cmd.ExecuteNonQuery();
                    Response.Redirect("ZWard30.aspx");
                }
            }
        }
    }
}