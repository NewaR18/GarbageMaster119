using Functions.Business_Logic_Layer;
using System.Web.Mvc;

namespace GarbageMaster.Controllers
{
    public class MainController : Controller
    {
        private readonly BLL _repo;

        public MainController()
        {
            _repo = new BLL();
        }

        [HttpPost]
        public JsonResult PostName(string Name, string Email, string Subject, string Message)
        {
            return Json(new { Name = _repo.QuickMessage(Name, Email, Subject, Message) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult RegisterUser(string FName, string MName, string LName, string Email, string UName, string Password, int Ward)
        {
            return Json(new { Name = _repo.Register(FName, MName, LName, Email, UName, Password, Ward) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CheckLogin(string UName, string Password)
        {
            return Json(new { Name = _repo.Login(UName, Password) }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult InsertWasteData(string SP, string BP, string DB, string sack)
        {
            string uname = Session["UserName"].ToString();
            return Json(new { Name = _repo.WasteData(SP, BP, DB, sack,uname) }, JsonRequestBehavior.AllowGet);
        }
    }
}