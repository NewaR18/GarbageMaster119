using Functions.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarbageMaster
{
    public partial class HomePage : System.Web.UI.Page
    {
        public BLL _bll;
        public HomePage()
        {
            _bll= new BLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                string Username1 = Session["UserName"].ToString();
                
            }
        }
        
    }
}