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
    public class RepoAdmission: IDisposable
    {
        public string  Connection { get; set; }         
        public RepoAdmission(string _connection)
        {
            Connection = _connection;
        }
        public async Task<List<AdmissionForm>> SelectAdmissionForms()
        {
            List<AdmissionForm> list = new List<AdmissionForm>();
            try
            {
                string query = @"SELECT Id ,first_name,middle_name,last_name,gender,contact_number,cnic,is_resident,address,email,DOB,Age,purpose_of_joining,Height
           ,Weight,BMI,company_id,created_by,updated_by,created_on,updated_on,is_active,is_deleted FROM admission_form ";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    list = con.Query<AdmissionForm>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => list);
        }
        public async Task<AdmissionForm> SelectAdmissionForm(int Id)
        {
            AdmissionForm obj = new AdmissionForm();
            try
            {
                string query = @"SELECT Id,first_name,middle_name,last_name,gender,contact_number,cnic,is_resident,address,email,DOB,Age,purpose_of_joining,Height
           ,Weight,BMI,company_id,created_by,updated_by,created_on,updated_on,is_active,is_deleted FROM admission_form where Id=@Id";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    obj= con.Query<AdmissionForm>(query ,  new { Id=Id}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => obj);
        }
        public async Task<int> InsertAdmissionForm(AdmissionForm model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    var id = await con.ExecuteScalarAsync(@"insert into admission_form
(first_name,middle_name,last_name,gender,contact_number,cnic,is_resident,address,email,DOB,Age,purpose_of_joining,Height
           ,Weight,BMI,company_id,created_by,created_on,is_active,is_deleted)
                                 VALUES
                                 (@first_name,@middle_name,@last_name,@gender,@contact_number,@cnic,@is_resident,@address,@email,@DOB,@Age,@purpose_of_joining,@Height
           ,@Weight,@BMI,@company_id,@created_by,@created_on,@is_active,@is_deleted); SELECT CAST(SCOPE_IDENTITY() as int)", model);
                    if (id != null)
                    {
                        model.Id = Convert.ToInt32(id);
                        await Generate_Log(model, "AdmissionForm/Create", model.Id, model.created_by, "Insert", "INS");
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
        public async Task<int> UpdateAdmissionForm(AdmissionForm model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    result = await con.ExecuteAsync(@"update admission_form set
                             first_name=@first_name,middle_name=@middle_name,last_name=@last_name,gender=@gender,contact_number=@contact_number,cnic=@cnic,is_resident=@is_resident
           ,address=@address,email=@email,DOB=@DOB,Age=@Age,purpose_of_joining=@purpose_of_joining,Height=@Height,Weight=@Weight
           ,BMI=@BMI,company_id=@company_id,updated_by=@updated_by,updated_on=@updated_on
           ,is_active=@is_active,is_deleted=@is_deleted
                            where Id=@Id;", model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await Generate_Log(model, "AdmissionForm/Update", model.Id, model.created_by, "update", "UPD");
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