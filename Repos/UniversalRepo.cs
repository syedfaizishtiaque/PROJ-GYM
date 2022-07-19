using GYM.Models.Organization;
using GYM.Models.Session;
using GYM.MODELS;
using GYM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GYM.Repos
{
    public class UniversalRepo
    {
        public async Task<int> GetDepId()
        {
            int UserId = 0;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    UserId = AppSession.Session.SessionRepo[0].dept_sk;
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Private.GetDepId");
                }
                throw ex;
            }
            return await Task.Run(() => UserId);
        }

        public async Task<int> GetUserId()
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

        public async Task<string> GetStatusRole()
        {
            string result = string.Empty;
            try
            {
                if (AppSession.Session != null && AppSession.Session.SessionRepo.Count > 0)
                {
                    string Role = AppSession.Session.SessionRepo[0].role_desc;
                    if (Role == "Compliance Inputter")
                    {
                        result = "CI";
                    }
                    else if (Role == "Compliance Authorizer")
                    {
                        result = "CA";
                    }
                    else if (Role == "Business Authroizer")
                    {
                        result = "BA";
                    }
                    else if (Role == "Business Inputter")
                    {
                        result = "BI";
                    }
                    else if (Role.ToLower() == "super user")
                    {
                        result = "SU";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => result);
        }

        public List<db_msgs> GetMessages()
        {
            int DeptId = AppSession.Session.SessionRepo[0].dept_sk;
            int RoleSk = AppSession.Session.SessionRepo[0].role_sk;
            List<db_msgs> list = new List<db_msgs>();
            try
            {
                using (RepoMessages _repo = new RepoMessages(MvcApplication.ConnectionString))
                {
                    list = _repo.GetMessages(DeptId, RoleSk);
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.GetMessages");
                }
                throw ex;
            }
            return list;
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

        public async Task SaveLogin(login_history login)
        {
            try
            {
                using (RepoMessages _repo = new RepoMessages(MvcApplication.ConnectionString))
                {
                    await _repo.SaveLoginHistory(login);
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "UniversalRepo.SaveLogin");
                }
                throw ex;
            }
        }
      
        public string GetIpAddress(string hostAddress)
        {
            var userIp = hostAddress;
            if (userIp != null)
            {
                long macInfo = new long();
                string macSrc = macInfo.ToString("X");

                if (macSrc == "0")
                {
                    if (userIp == "::1")
                    {
                        return "Visited LocalHost";
                    }
                    else
                    {
                        return userIp;
                    }
                }
            }
            return "";
        }
    }
}