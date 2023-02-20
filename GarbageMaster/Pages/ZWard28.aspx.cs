﻿using Functions.Business_Logic_Layer;
using Functions.Data_Link_Layer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarbageMaster.Pages
{
    public partial class ZWard28 : System.Web.UI.Page
    {
        public DLL _dll;
        public BLL _bll;
        public ZWard28()
        {
            _dll = new DLL();
            _bll = new BLL();
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
                List<int> list = _dll.getaverage();
                Label28.Text = Convert.ToString(list[27]);
            }
        }
        private void GetData()
        {
            DataTable table = _dll.Extractwastewithwarddata(28);
            GridView1.DataSource = table;
            int a = table.Rows.Count;
            if (a != 0)
            {
                GridView1.DataBind();
            }

        }
        protected void TruckSent(object sender, EventArgs e)
        {
            _bll.mailsend(Label28.Text, 28);
        }
        protected void Checkedout(object sender, EventArgs e)
        {
            _dll.setonfire(28);
            Response.Redirect("ZWard28.aspx");
        }
    }
}