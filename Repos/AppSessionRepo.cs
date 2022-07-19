using GYM.Models.Organization;
using GYM.Models.Session;
using GYM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GYM.Repos
{
    public class AppSessionRepo
    {
        public AppSessionRepo()
        {
           

        }

        public async Task<bool> ValidateUserandGenerateSession(string userid , string password ,string key)
        {
            bool result = false;
            try
            {
                if (AppSession.Session != null)
                {
                    if (AppSession.Session.SessionRepo != null)
                    {
                        if(!string.IsNullOrEmpty(userid)){
                            if(userid.ToLower() == AppSession.Session.SessionRepo[0].usr_nme.ToLower())
                            {
                                return true;
                            }
                            else
                            {
                                result= false;
                            }
                        }                       
                    }
                }
                if (AppSession.Session == null && !string.IsNullOrEmpty(userid))
                {  
                    using (RepoSession sess = new RepoSession(MvcApplication.ConnectionString))
                    {
                        
                        string username = userid;
                        bool IsValidUser = false;
                        using(RepoSession repo = new RepoSession(MvcApplication.ConnectionString))
                        {
                            IsValidUser= await repo.IsValiduser(userid,password);
                        }
                        if (!IsValidUser)
                        {
                            return result;
                        }
                        
                        List<SessionModel> list = sess.GetData(username,key);


                       
                        AppSession.Session = new SessionRepositoryModel()
                        {
                           SessionRepo = list
                        };
                        result = true;
                        if (list != null && list.Count > 0)
                        {
                            await SaveLoginHistory();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                AppSession.Session = new SessionRepositoryModel()
                {
                    SessionRepo = null,
                  
                };
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "BaseController.Constructer");
                }

                throw ex;
            }

            return result;
        }

        private async Task SaveLoginHistory()
        {
            try
            {
                var uni = new UniversalRepo();
                if (AppSession.Session != null)
                {
                    if (AppSession.Session.SessionRepo != null)
                    {
                        await uni.SaveLogin(new login_history
                        {

                            usr_ip = uni.GetIpAddress(HttpContext.Current.Request.UserHostAddress),
                            usr_sk = AppSession.Session.SessionRepo[0].usr_sk,
                            app_sk = 9,
                            type_sk = 1,
                            created_on = DateTime.Now
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "HomeController.SaveLoginHistory");
                }
                throw;
            }
        }


    }
}