using GYM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GYM.Repository
{
    public class RepoEmployee : IDisposable
    {
        public string  Connection { get; set; }         
        public RepoEmployee(string _connection)
        {
            Connection = _connection;
        }
        public async Task<List<employee>> SelectEmployees()
        {
            List<employee> list = new List<employee>();
            try
            {
                string query = @"SELECT Id,Name,contact_no,date_of_joining,job_title,email_id,from_time,to_time,reporting_id,address,salary,guardian_name
      ,guardian_no,sick_leave,annual_leave,use_sick_leave,use_annual_leave,unuse_annual_leave,unuse_sick_leave,is_trainer,company_id
      ,created_by,updated_by,created_on,updated_on,is_active,is_deleted FROM employee";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    list = con.Query<employee>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => list);
        }
        public async Task<employee> SelectEmployee(int Id)
        {
            employee obj = new employee();
            try
            {
                string query = @"SELECT Id,Name,contact_no,date_of_joining,job_title,email_id,from_time,to_time,reporting_id,address,salary,guardian_name
      ,guardian_no,sick_leave,annual_leave,use_sick_leave,use_annual_leave,unuse_annual_leave,unuse_sick_leave,is_trainer,company_id
      ,created_by,updated_by,created_on,updated_on,is_active,is_deleted FROM employee where Id=@Id";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    obj= con.Query<employee>(query ,  new { Id=Id}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => obj);
        }
        public async Task<int> InsertEmployee(employee model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    var id = await con.ExecuteScalarAsync(@"INSERT INTO employee
           (Name,contact_no,date_of_joining,job_title,email_id,from_time,to_time,reporting_id,address,salary,guardian_name,guardian_no
           ,sick_leave,annual_leave,use_sick_leave,use_annual_leave,unuse_annual_leave,unuse_sick_leave,is_trainer,company_id,created_by
           ,created_on,is_active,is_deleted)
		   values
			(@Name,@contact_no,@date_of_joining,@job_title,@email_id,@from_time,@to_time,@reporting_id,@address,@salary,@guardian_name
           ,@guardian_no,@sick_leave,@annual_leave,@use_sick_leave,@use_annual_leave,@unuse_annual_leave,@unuse_sick_leave,@is_trainer,@company_id
           ,@created_by,@created_on,@is_active,@is_deleted); SELECT CAST(SCOPE_IDENTITY() as int)", model);
                    if (id != null)
                    {
                        model.Id = Convert.ToInt32(id);
                        await Generate_Log(model, "Employee/Create", model.Id, model.created_by, "Insert", "INS");
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
        public async Task<int> UpdateEmployee(employee model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    result = await con.ExecuteAsync(@"update employee set
           Name=@Name,contact_no=@contact_no,date_of_joining=@date_of_joining,job_title=@job_title,email_id=@email_id,from_time=@from_time
           ,to_time=@to_time,reporting_id=@reporting_id,address=@address,salary=@salary,guardian_name=@guardian_name,guardian_no=@guardian_no
           ,sick_leave=@sick_leave,annual_leave=@annual_leave,use_sick_leave=@use_sick_leave,use_annual_leave=@use_annual_leave,unuse_annual_leave=@unuse_annual_leave
           ,unuse_sick_leave=@unuse_sick_leave,company_id=@company_id,updated_by=@updated_by,updated_on=@updated_on,is_trainer=@is_trainer,is_active=@is_active,
		   is_deleted=@is_deleted where Id=@Id;", model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await Generate_Log(model, "Employee/Update", model.Id, model.created_by, "update", "UPD");
            return result;
        }
        private async Task<int> Generate_Log(object obj, string refr, int key, int userid, string action, string code)
        {
            try
            {
                using (RepoLog _repo = new RepoLog(Connection))
                {
                    return await _repo.GenerateLog(obj, refr, key, userid, action, code);
                }
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