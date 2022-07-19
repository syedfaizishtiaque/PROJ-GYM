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
    public class PackageController : BaseController
    {
        // GET: Package
        public async Task<ActionResult> Index()
        {
            List<Package> list = new List<Package>();
            using(RepoPackage _repo = new RepoPackage(MvcApplication.ConnectionString))
            {
                list =await _repo.SelectPackages();
                if (list != null && list.Count > 0)
                {

                    foreach (var item in list)
                    {
                        item.enc_id = Encrypt(item.Id.ToString());
                    }
                }
            }
            return View(list);
        }
        public async Task<ActionResult> Create(string PackageId = "")
        {
            Package obj = new Package();
            string ErrorMessage = await GetErrorMessage();
            string Message = await GetMessage();
            if (!string.IsNullOrEmpty(Message))
            {
                ViewBag.Message = Message;
            }
            else if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ViewBag.ErrorMessage = ErrorMessage;
            }
            if (!string.IsNullOrEmpty(PackageId))
            {
                PackageId = Sanitizer.GetSafeHtmlFragment(PackageId);
                int Identity = Decrypt(PackageId);
                using (RepoPackage _repo = new RepoPackage(MvcApplication.ConnectionString))
                {
                    obj = await _repo.SelectPackage(Identity);
                }
            }
            return View(obj);
        }
        [HttpPost]
        public async Task<ActionResult> Create(Package model)
        {
            try
            {
                model.created_by = await GetUserId();
                model.created_on = DateTime.Now;
                model.updated_by = await GetUserId();
                model.updated_on= DateTime.Now;
                model.is_active = true;
                model.company_id = await GetAppId();
                model.is_deleted = false;
                using (RepoPackage _repo = new RepoPackage(MvcApplication.ConnectionString))
                {
                    if (model.Id > 0)
                    {
                        int res = await _repo.UpdatePackage(model);
                        if (res > 0)
                        {
                            SetMessage("Package Updated Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while updating Package. Please Contact IT");
                        }
                    }
                    else
                    {
                        model.Id = await _repo.InsertPackage(model);
                        if (model.Id > 0)
                        {
                            SetMessage("Package Saved Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while saving Package. Please Contact IT");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "PackageController.Post.Create");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
            return RedirectToAction("Create", new { PackageId = Encrypt(model.Id.ToString()) });


        }
    }
}