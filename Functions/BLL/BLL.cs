using Functions.Data_Link_Layer;
using System;
using System.Web;

namespace Functions.Business_Logic_Layer
{
    public class BLL
    {
        public string Uname = null;

        private readonly DLL _dll;

        public BLL()
        {
            _dll = new DLL();
        }

        public string QuickMessage(string Name, string Email, string Subject, string Message)
        {
            return _dll.InsertMessage(Name, Email, Subject, Message);
        }

        public string Register(string FName, string MName, string LName, string Email, string UName, string Password, int Ward)
        {
            return _dll.RegisterUser(FName, MName, LName, Email, UName, Password, Ward);
        }

        public string Login(string UName, string Password)
        {
            string value = _dll.LoginUser(UName, Password);
            if (value == "ValidUser")
            {
                HttpContext.Current.Session["UserName"] = UName;
            }
            return value;
        }

        public string GetUName()
        {
            return Uname;
        }

        public string WasteData(string SP, string BP, string DB, string sack,string uname)
        {
            int n;
            int smallP;
            if (SP == "")
            {
                smallP = 0;
            }
            else
            {
                smallP = Convert.ToInt32(SP);
            }
            int bigP;
            if (BP == "")
            {
                bigP = 0;
            }
            else
            {
                bigP = Convert.ToInt32(BP);
            }
            int dustB;
            if (DB == "")
            {
                dustB = 0;
            }
            else
            {
                dustB = Convert.ToInt32(DB);
            }
            int sackB;
            if (sack == "")
            {
                sackB = 0;
            }
            else
            {
                sackB = Convert.ToInt32(sack);
            }
            n = smallP * 1 + bigP * 4 + dustB * 6 + sackB * 12;
            if (n < 1000)
            {
                return _dll.InsertWasteData(n, uname);
            }
            else
            {
                return "spam";
            }
        }
    }
}