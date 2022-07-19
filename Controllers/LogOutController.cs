using GYM.Models.Organization;
using GYM.Models.Session;
using GYM.Repos;
using GYM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RRM.APP.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Loggedout()
        {
            try
            {

                SaveLogOut();
                //THIS METHOD CALLING THROUGH AJAX REMOVING AND CLOSING THE SESSION
                Session.Abandon();
                Session.RemoveAll();


                string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority +
                 Request.ApplicationPath.TrimEnd('/') + "/LogOut";
                return Json(baseUrl, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "LogOutController.Loggedout.Get");
                }
                throw ex;
            }
        }

        private void SaveLogOut()
        {
            var uni = new UniversalRepo();
            if (AppSession.Session != null)
            {
                if (AppSession.Session.SessionRepo != null)
                {
                   uni.SaveLogin(new login_history
                    {
                        usr_ip = uni.GetIpAddress(Request.UserHostAddress),
                        usr_sk = AppSession.Session.SessionRepo[0].usr_sk,
                        app_sk = 9,
                        type_sk = 0,
                        created_on = DateTime.Now
                    });
                }
            }
          
        }
    }
}