using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using GYM.Models.Session;
using GYM.Interface;
using Dapper;

namespace GYM.Controllers.Service
{
    public class Serv_Session: ILogin
    {
        public string _ConnectionString = string.Empty;
        public Serv_Session(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public List<SessionModel> GetData(string username)
        {
            try
            {
                List<SessionModel> session;
                session = GetSession(username);
                return session;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<SessionModel> GetSession(string username)
        {
            List<SessionModel> list = new List<SessionModel>();
            try
            {
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                    string query = string.Empty;
                    if (!string.IsNullOrEmpty(username))
                    {
                        list = con.Query<SessionModel>(@"Exec sp_Logindata @username , @appId", new { username = username, appId = 9 }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}