using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security.AntiXss;
using System.Web.Mvc;
using Microsoft.Security.Application;
using GYM.Models.Session;
using GYM.Repository;

namespace GYM.Controllers
{
    [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class BaseController : Controller
    {
        public BaseController()
        {
            try
            {
                if (AppSession.Session == null)
                {
                    RedirectToAction("Index", controllerName: "LogIn");
                }
                else if (AppSession.Session.SessionRepo == null)
                {
                    RedirectToAction("Index", controllerName: "LogIn");
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Constructer");
                }
                RedirectToAction("Index", controllerName: "LogIn");
            }

        }
        protected async Task<string> GetUserName()
        {
            string username = string.Empty;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    username = AppSession.Session.SessionRepo[0].usr_nme;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetUserName");
                }
                throw ex;
            }
            return await Task.Run(() => username);
        }
        protected async Task<string> GetUserRole()
        {
            string userrole = string.Empty;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    userrole = AppSession.Session.SessionRepo[0].role_desc;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetUserRole");
                }
                throw ex;
            }
            return await Task.Run(() => userrole);
        }
        protected async Task<int> GetUserRoleSk()
        {
            int userrole = 0;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    userrole = AppSession.Session.SessionRepo[0].role_sk;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetUserRole");
                }
                throw ex;
            }
            return await Task.Run(() => userrole);
        }
        protected void SetErrorMessage(string ErrorMessage)
        {

            Session["ErrorMessage"] = ErrorMessage;

        }
        protected void SetMessage(string Message)
        {

            Session["Message"] = Message;

        }
        protected async Task<string> GetMessage()
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(Session["Message"] == null ? "" : Session["Message"].ToString()))
                {
                    result = Session["Message"].ToString();
                    Session["Message"] = "";
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetErrorMessage");
                }
                throw ex;
            }
            return await Task.Run(() => result);
        }
        protected async Task<string> GetSubClass()
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(Session["SubClass"] == null ? "" : Session["SubClass"].ToString()))
                {
                    result = Session["SubClass"].ToString();
                    Session["SubClass"] = "";
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetErrorMessage");
                }
                throw ex;
            }
            return await Task.Run(() => result);
        }
        protected async Task<string> GetActivityClass()
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(Session["ActivityClass"] == null ? "" : Session["ActivityClass"].ToString()))
                {
                    result = Session["ActivityClass"].ToString();
                    Session["ActivityClass"] = "";
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetActivityClass");
                }
                throw ex;
            }
            return await Task.Run(() => result);
        }
        protected void SetSubClass(string SubClass)
        {

            Session["SubClass"] = SubClass;

        }
        protected void SetActivityClass(string ActivityClass)
        {

            Session["ActivityClass"] = ActivityClass;

        }
        protected async Task<string> GetErrorMessage()
        {
            string result = "";
            try
            {
                if (!string.IsNullOrEmpty(Session["ErrorMessage"] == null ? "" : Session["ErrorMessage"].ToString()))
                {
                    result = Session["ErrorMessage"].ToString();
                    Session["ErrorMessage"] = "";
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetMessage");
                }
                throw ex;
            }
            return await Task.Run(() => result);
        }
        protected async Task<int> GetUserId()
        {
            int UserId = 0;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    UserId = AppSession.Session.SessionRepo[0].usr_sk;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetUserId");
                }
                throw ex;
            }
            return await Task.Run(() => UserId);
        }
        protected async Task<int> GetAppId()
        {
            int AppId = 0;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    AppId= AppSession.Session.SessionRepo[0].app_sk;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetAppId");
                }
                throw ex;
            }
            return await Task.Run(() => AppId);
        }

        protected async Task<string> GetInputter()
        {
            return string.Format("{0}_{1}_{2}", await GetUserId(), await GetUserRole(), await GetUserName());
        }
      
        #region Encode Properties -- Prevent XSS Attack 
        public T ValidateData<T>(T data)
        {
            foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    if (propertyInfo.GetValue(data, null) != null)
                    {
                        string value = propertyInfo.GetValue(data, null).ToString();
                        value = Sanitizer.GetSafeHtmlFragment(value);
                        propertyInfo.SetValue(data, value);
                    }
                }
            }
            return data;
        }
        #endregion

        #region Encrypt Decrypt
        public static string Encrypt(string input)
        {
            try
            {
                string key = "GYM.V01.ISB.SMFA";
                byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateEncryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                return Convert.ToBase64String(resultArray, 0, resultArray.Length).Replace("+", "%2B");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int Decrypt(string input)
        {
            try
            {
                input = input.Replace(" ", "+");
                input = input.Replace("%2B", "+");
                string key = "GYM.V01.ISB.SMFA";
                byte[] inputArray = Convert.FromBase64String(input);
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
                tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
                tripleDES.Mode = CipherMode.ECB;
                tripleDES.Padding = PaddingMode.PKCS7;
                ICryptoTransform cTransform = tripleDES.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
                tripleDES.Clear();
                string value = UTF8Encoding.UTF8.GetString(resultArray);
                return Convert.ToInt32(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
      
    }
}