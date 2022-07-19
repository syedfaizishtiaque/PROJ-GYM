using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Threading.Tasks;
using GYM.MODELS;

namespace GYM.Repository
{
    public class RepoLog : IDisposable
    {
        public string _ConnectionString = string.Empty;
        public RepoLog(string ConnectionString)
        {
            _ConnectionString = ConnectionString;
        }
        public async Task<int> GenerateLog(object obj , string refr , int key , int userid , string action , string code)
        {
            audit_log aud = new audit_log();
            try
            {
              aud.form_post_data =  JsonConvert.SerializeObject(obj);
                aud.form_ref = refr;
                aud.record_pk = key;
                aud.user_id = userid;
                aud.created_on = DateTime.Now;
                aud.action = action;
                aud.is_email_sent = 0;
                aud.sent_datetime = DateTime.Now;
                aud.rec_st_code = code;
                int result = 0;
                try
                {
                    using (IDbConnection con = new SqlConnection(_ConnectionString))
                    {
                        var id = await con.ExecuteScalarAsync(@"insert into audit_log
                                 (form_post_data,form_ref,record_pk,user_id,created_on,action,is_email_sent,rec_st_code)
                                 VALUES
                                 (@form_post_data,@form_ref,@record_pk,@user_id,@created_on,@action,@is_email_sent,@rec_st_code); SELECT CAST(SCOPE_IDENTITY() as int)", aud);
                        if (id != null)
                        {
                            aud.log_id = Convert.ToInt32(id);
                            result = Convert.ToInt32(id);
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return result;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
           
            //throw new NotImplementedException();
        }
    }
}
