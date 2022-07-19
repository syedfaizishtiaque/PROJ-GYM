using GYM.Attributes;
using GYM.Models;
using GYM.Repository;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GYM.Controllers
{
    [SessionAuth]
    public class AssignmenttController : BaseController
    {
        // GET: Assignmentt
        public async Task<ActionResult> Index(string AdmissionId , string AssignmentId="")
        {
            package_assignment obj = new package_assignment();
            try
            {
                await LoadPackages();
                List<SelectListItem> gender = new List<SelectListItem>();
                gender.Add(new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                });
                gender.Add(new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                });
                ViewBag.gender = gender;
                if (!string.IsNullOrEmpty(AdmissionId))
                {
                    AdmissionId = Sanitizer.GetSafeHtmlFragment(AdmissionId);
                    int Identity = Decrypt(AdmissionId);
                    using (RepoAssignment _repo = new RepoAssignment(MvcApplication.ConnectionString))
                    {
                        obj = await _repo.SelectAdmissionForm(Identity);
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AssignmentController.Get.Index");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
            return View(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetPackage(int PackageId)
        {
            try
            {
                using (RepoPackage _repo = new RepoPackage(MvcApplication.ConnectionString))
                {
                    var Para = await _repo.SelectPackage(PackageId);
                    return Json(Para , JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AssignmenttController.Get.GetPackage");
                }
                throw ex;
            }
        }
        private async Task LoadPackages()
        {
            try
            {
                string query = "select Id as Value , Package_name as Text from package order by Package_name";
                using(RepoDropDown _repo = new RepoDropDown(MvcApplication.ConnectionString))
                {
                   ViewBag.Packages = await _repo.LoadDropDown(query);
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AssignmentController.LoadDropDown");
                }
               
                throw ex;
            }
        }
    }
}