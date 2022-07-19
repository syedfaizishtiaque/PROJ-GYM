using GYM.Attributes;
using GYM.Repos;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GYM.Controllers
{
    [SessionAuth]
    public class HomeController : BaseController
    {
        private UniversalRepo uni = null;
        public HomeController()
        {
            //var appsession = new AppSessionRepo();
            uni = new UniversalRepo();
        }
       
        public async Task<ActionResult> Index()
        {
            ViewBag.RoleStatus = await uni.GetStatusRole();


            //Get dashboard notifications
           // await PopulateNotifications();

            return View();
        }

       

        //[HttpPost]
        //public async Task<ActionResult> UpdateMessages(int row_sk) {
        //    try
        //    {
        //        using (RepoMessages _repo = new RepoMessages(MvcApplication.ConnectionString))
        //        {
        //            int result = await _repo.UpdateMessage(row_sk, await uni.GetUserId());
        //            if (result > 0)
        //            {
        //                return Json("Notification Marked as read", JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                return Json("Error while Marked as read", JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        using (RepoLogWriter _repo = new RepoLogWriter())
        //        {
        //            _repo.WriteErrorLog("Error", ex, "RegulatoryAssessmentController.Post.SubRegulotoryById");
        //        }
        //        throw ex;
        //    }
        //}


      

        
    }
}