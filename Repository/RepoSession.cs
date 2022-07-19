using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using GYM.Models.Session;

namespace GYM.Repository
{
    public class RepoSession : IDisposable
    {
        public string _ConnectionString = string.Empty;
        public RepoSession(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

       
        public List<SessionModel> GetData(string username, string key)
        {
            try
            {
                List<SessionModel> session;
                session = GetSession(username,key);

                return session;
            }
            catch (Exception ex)
            {
                using (var repo = new RepoLogWriter())
                {
                    repo.WriteErrorLog("Exception", ex, "GetData");
                }
                throw ex;
            }
        }

        private List<SessionModel> GetSession(string username,string key)
        {
            List<SessionModel> list = new List<SessionModel>();
            try
            {
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                    string query = string.Empty;
                    if (!string.IsNullOrEmpty(username)&& !string.IsNullOrEmpty(key))
                    {
                        list = con.Query<SessionModel>(@"Exec sp_Logindata @username , @key", new { username = username, key = key }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                using (var repo = new RepoLogWriter())
                {
                    repo.WriteErrorLog("Exception", ex, "GetSession");
                }
                throw ex;
            }
            return list;
        } 
        public List<vu_mapping> GetMapping()
        {
            List<vu_mapping> list = new List<vu_mapping>();
            try
            {
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                  
                        list = con.Query<vu_mapping>(@"select code ,map_code,rec_st_title,visible_to ,idnt from vu_mapping").ToList();
                    
                }
            }
            catch (Exception ex)
            {
                using (var repo = new RepoLogWriter())
                {
                    repo.WriteErrorLog("Exception", ex, "GetMapping");
                }

                throw ex;
            }
            return list;
        }
        public async Task<bool> IsValiduser(string userId,string password)
        {
            bool result = false;
            try
            {
                string query = @"SELECT COUNT(*) as IsValid FROM USRS WHERE usr_nme=@usr_nme and password=@password";
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                    object obj = await con.ExecuteScalarAsync(query , new { usr_nme =userId , password=password});
                    if (obj != null)
                    {
                        int val = Convert.ToInt32(obj);
                        if (val > 0)
                        {
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               result = false;
               throw ex;
            }
            return result;
        }
        public void Dispose()
        {
            _ConnectionString = string.Empty;
        }

    }
}
