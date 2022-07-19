using GYM.Models;
using GYM.Models.Session;
using GYM.Repos;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GYM.Controllers
{

    public class LogInController : Controller
    {
        // GET: LogIn

        public ActionResult Index()
        {
            if (Session["Message"] != null)
            {
                ViewBag.ErrorMessage = Session["Message"];
                Session["Message"] = null;
            }
            if (AppSession.Session == null)
            {
                return View();
            }
            else if (AppSession.Session.SessionRepo == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Index(vu_usercred model)
        {
            try
            {
                model.securitykey = "MINI-GYM-001";
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.password = Encrypt(model.password);
                model.username = Encrypt(model.username.ToLower());

                AppSessionRepo session = new AppSessionRepo();
                bool result = await session.ValidateUserandGenerateSession(model.username, model.password, model.securitykey);
                if (!result)
                {
                    Session["Message"] = "You are not authorized";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return RedirectToAction("Index", controllerName: "Home");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private string UserFullId(string DomainName, string userId)
        {
            string value = string.Format(@"{0}@{1}", userId, DomainName);
            return value;
        }
        private string LdapPath(string DomainName, int PortNumber)
        {
            string value = string.Format(@"LDAP://DC={0},DC=local", DomainName);
            return value;
        }
        #region Encrypt Decrypt
        private static string Encrypt(string input)
        {
            try
            {
                string key = "GYM.PWD.ISB.SMFA";
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
        private static int Decrypt(string input)
        {
            try
            {
                input = input.Replace(" ", "+");
                input = input.Replace("%2B", "+");
                string key = "GYM.PWD.ISB.SMFA";
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