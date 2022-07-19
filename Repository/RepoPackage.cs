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
    public class RepoPackage : IDisposable
    {
        public string  Connection { get; set; }         
        public RepoPackage(string _connection)
        {
            Connection = _connection;
        }
        public async Task<List<Package>> SelectPackages()
        {
            List<Package> list = new List<Package>();
            try
            {
                string query = @"SELECT Id , package_name,package_fee,registration_fee,session_adj,expiry_date,company_id,created_by,created_on,is_active,is_deleted FROM package";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    list = con.Query<Package>(query).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => list);
        }
        public async Task<Package> SelectPackage(int Id)
        {
            Package obj= new Package();
            try
            {
                string query = @"SELECT Id, package_name,package_fee,registration_fee,session_adj,expiry_date,company_id,created_by,created_on,is_active,is_deleted FROM package where Id=@Id";
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    obj= con.Query<Package>(query ,  new { Id=Id}).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return await Task.Run(() => obj);
        }
        public async Task<int> InsertPackage(Package model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    var id = await con.ExecuteScalarAsync(@"insert into package
(package_name,registration_fee,package_fee,session_adj,expiry_date,company_id,created_by,created_on,is_active,is_deleted)
                                 VALUES
                                 (@package_name,@registration_fee,@package_fee,@session_adj,@expiry_date,@company_id,@created_by,@created_on,@is_active,@is_deleted); SELECT CAST(SCOPE_IDENTITY() as int)", model);
                    if (id != null)
                    {
                        model.Id = Convert.ToInt32(id);
                        await Generate_Log(model, "Package/Create", model.Id, model.created_by, "Insert", "INS");
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
        public async Task<int> UpdatePackage(Package model)
        {
            int result = 0;
            try
            {
                using (IDbConnection con = new SqlConnection(Connection))
                {
                    result = await con.ExecuteAsync(@"update Package set
                            package_name=@package_name,registration_fee=@registration_fee,package_fee=@package_fee,session_adj=@session_adj,expiry_date=@expiry_date,updated_by=@updated_by,updated_on=@updated_on,is_active=@is_active,is_deleted=@is_deleted
                            where Id=@Id;", model);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            await Generate_Log(model, "Package/UpdatePackage", model.Id, model.created_by, "update", "UPD");
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