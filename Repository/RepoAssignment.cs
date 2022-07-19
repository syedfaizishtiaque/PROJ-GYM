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
    public class RepoAssignment : IDisposable
    {
        public string Connection { get; set; }
        public RepoAssignment(string _connection)
        {
            Connection = _connection;
        }
        public async Task<package_assignment> SelectAdmissionForm(int Id)
        {
            package_assignment obj = new package_assignment();
            try
            {
                string query = @"SELECT Id as addmission_id,first_name,middle_name,last_name,gender,contact_number,cnic,is_resident,address,email,DOB,Age,purpose_of_joining,Height
           ,Weight,BMI,company_id,created_by,updated_by,created_on,updated_on,is_active,is_deleted FROM admission_form where Id=@Id";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    obj = con.Query<package_assignment>(query, new { Id = Id }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => obj);
        }
        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}