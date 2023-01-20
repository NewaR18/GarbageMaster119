using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarbageMaster
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Profile01.Visible = true;
                Register01.Visible = false;
            }
        }
        protected void HomeLink_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/HomePage.aspx");
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Login.aspx");
        }
        protected void UpdateData_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Login.aspx");
        }
        protected void Team_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Login.aspx");
        }
        protected void Contact_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/HomePage.aspx#contact");
        }
        protected void Profile01_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/HomePage.aspx");
        }
        protected void Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Pages/Profile.aspx");
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session["UserName"] = null;
            Response.Redirect("../Pages/HomePage.aspx");
            
        }
    }
}