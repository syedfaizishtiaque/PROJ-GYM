using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using GYM.MODELS;
using GYM.Models.Organization;

namespace GYM.Repository
{
    public class RepoMessages : IDisposable
    {
        public string _ConnectionString = string.Empty;
        public RepoMessages(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }

        public async Task<int> UpdateMessage(int row_sk , int userid)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                    result = await con.ExecuteAsync(@"update db_msgs set
                                viewed_by=@viewed_by , viewed_on=@viewed_on , msg_status=@msg_status
                                where row_sk=@row_sk and viewed_by is null", new { viewed_by =userid , viewed_on = DateTime.Now , msg_status=true , row_sk= row_sk });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public List<db_msgs> GetMessages(int DeptId , int RoleSk)
        {
           
            List<db_msgs> list = new List<db_msgs>();
            try
            {
                //string query = $"SELECT top 25 row_sk,dept_sk,role_sk,msg,created_on,msg_status,viewed_by,viewed_on FROM vu_msgs where dept_sk=@dept_sk and role_sk=@role_sk";
                //using (IDbConnection con = new SqlConnection(_ConnectionString))
                //{
                //    list = con.Query<db_msgs>(query, new { dept_sk = DeptId, role_sk = RoleSk}).ToList();
                //}
                if (list == null || list.Count==0)
                {
                    list = new List<db_msgs>();
                }
            }
            catch (Exception ex)
            {
                using (RepoLogWriter _repo = new RepoLogWriter())
                {
                    _repo.WriteErrorLog("Error", ex, "RepoMessages.GetMessages");
                }
                throw ex;
            }
            return list;
        }

        

        public async Task SaveLoginHistory(login_history login)
        {
          
            try
            {
                using (IDbConnection con = new SqlConnection(_ConnectionString))
                {
                   await con.ExecuteScalarAsync(@"insert into login_history (app_sk,usr_sk,type_sk,usr_ip,created_on)
                                 VALUES (@app_sk,@usr_sk,@type_sk,@usr_ip,@created_on);", login);                   

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
