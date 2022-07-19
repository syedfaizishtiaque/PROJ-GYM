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
    public class EmployeeController : BaseController
    {
        // GET: Package
        public async Task<ActionResult> Index()
        {
            List<employee> list = new List<employee>();
            using (RepoEmployee _repo = new RepoEmployee(MvcApplication.ConnectionString))
            {
                list = await _repo.SelectEmployees();
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
        public async Task<ActionResult> Create(string EmployeeId = "")
        {
            employee obj = new employee();
            try
            {
                await LoadReportingto();
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
                if (!string.IsNullOrEmpty(EmployeeId))
                {
                    EmployeeId = Sanitizer.GetSafeHtmlFragment(EmployeeId);
                    int Identity = Decrypt(EmployeeId);
                    using (RepoEmployee _repo = new RepoEmployee(MvcApplication.ConnectionString))
                    {
                        obj = await _repo.SelectEmployee(Identity);
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "EmployeeController.Get.Create");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
           
           
            return View(obj);
        }
        [HttpPost]
        public async Task<ActionResult> Create(employee model)
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
                using (RepoEmployee _repo = new RepoEmployee(MvcApplication.ConnectionString))
                {
                    if (model.Id > 0)
                    {
                        int res = await _repo.UpdateEmployee(model);
                        if (res > 0)
                        {
                            SetMessage("Employee Updated Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while updating Employee. Please Contact IT");
                        }
                    }
                    else
                    {
                        model.Id = await _repo.InsertEmployee(model);
                        if (model.Id > 0)
                        {
                            SetMessage("Employee Saved Successfully");
                        }
                        else
                        {
                            SetErrorMessage("Having issues while saving Employee. Please Contact IT");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "EmployeeController.Post.Create");
                }
                SetErrorMessage(ex.Message.ToString());
                throw ex;
            }
            return RedirectToAction("Create", new { EmployeeId = Encrypt(model.Id.ToString()) });


        }
        private async Task LoadReportingto()
        {
            try
            {
                string query = "select Id as Value , name as Text from employee where is_trainer=0 order by name";
                using (RepoDropDown _repo = new RepoDropDown(MvcApplication.ConnectionString))
                {
                    ViewBag.employees = await _repo.LoadDropDown(query);
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