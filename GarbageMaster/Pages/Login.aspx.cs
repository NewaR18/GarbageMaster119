using Functions.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarbageMaster.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        public BLL _bll;
        public Login()
        {
            _bll=new BLL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}