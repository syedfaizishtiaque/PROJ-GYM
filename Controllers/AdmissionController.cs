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
    public class AdmissionController : BaseController
    {

        public async Task<ActionResult> Index()
        {
            List<AdmissionForm> list = new List<AdmissionForm>();
            try
            {
                using (RepoAdmission _repo = new RepoAdmission(MvcApplication.ConnectionString))
                {
                    
                    list = await _repo.SelectAdmissionForms();
                    if (list != null && list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            item.enc_id = Encrypt(item.Id.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AdmissionController.Get.Index");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
            return View(list);
        }
        public async Task<ActionResult> Create(string AdmissionId = "")
        {
            AdmissionForm obj = new AdmissionForm();
            try
            {
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
                if (!string.IsNullOrEmpty(AdmissionId))
                {
                    AdmissionId = Sanitizer.GetSafeHtmlFragment(AdmissionId);
                    int Identity = Decrypt(AdmissionId);
                    using (RepoAdmission _repo = new RepoAdmission(MvcApplication.ConnectionString))
                    {
                        obj = await _repo.SelectAdmissionForm(Identity);
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AdmissionController.Get.Create");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
           
            return View(obj);
        }
        [HttpPost]
        public async Task<ActionResult> Create(AdmissionForm model)
        {
            try
            {
                model.created_by = await GetUserId();
                model.created_on = DateTime.Now;
                model.updated_by = await GetUserId();
                model.updated_on = DateTime.Now;
                model.is_active = true;
                model.company_id = await GetAppId();
                model.is_deleted = false;
                using (RepoAdmission _repo = new RepoAdmission(MvcApplication.ConnectionString))
                {

                    if (model.Id > 0)
                    {
                        int res = await _repo.UpdateAdmissionForm(model);
                        if (res > 0)
                        {
                            SetMessage("Admission Form Updated Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while updating Admission Form. Please Contact IT");
                        }
                    }
                    else
                    {
                        model.Id = await _repo.InsertAdmissionForm(model);
                        if (model.Id > 0)
                        {
                            SetMessage("Admission Form Saved Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while saving Admission Form. Please Contact IT");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "AdmissionController.Post.Create");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
            return RedirectToAction("Create", new { AdmissionId = Encrypt(model.Id.ToString()) });


        }
    }
}