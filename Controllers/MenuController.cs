using GYM.Attributes;
using GYM.Models.Session;
using GYM.Repos;
using GYM.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace RRM.APP.Controllers
{
    [SessionAuth]
    public class MenuController : Controller
    {
       
        [HttpPost]
        public JsonResult GetMenu()
        {
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo != null)
                {
                    return Json(AppSession.Session.SessionRepo.Where(x => x.can_slct != false).ToList(), JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                using(RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "MenuController.GetMenu.Post");
                }
               
                throw ex;
            }

        }

        [HttpPost]
        public JsonResult GetNotifications()
        {
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo != null)
                {
                    var uni = new UniversalRepo();
                    var notifications = uni.GetMessages();

                    return Json(notifications,JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "MenuController.GetNotifications.Post");
                }

                throw ex;
            }

        }

    }
}