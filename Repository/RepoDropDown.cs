using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Web.Mvc;

namespace GYM.Repository
{
    public class RepoDropDown : IDisposable
    {
        public string ConnectionString = string.Empty;
        public RepoDropDown(string _ConnectionString)
        {
            ConnectionString = _ConnectionString;
        }

        public async Task<List<SelectListItem>> LoadDropDown(string _query)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {

                if (string.IsNullOrEmpty(_query))
                {
                    return await Task.Run(() => list);
                }
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {

                    list = con.Query<SelectListItem>(_query).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public async Task<string> GetScalarValue(string _query)
        {
            string result = string.Empty;
            try
            {

                if (string.IsNullOrEmpty(_query))
                {
                    return await Task.Run(() => "");
                }
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {

                    object obj = await con.ExecuteScalarAsync(_query);
                    result = obj.ToString();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public async Task<List<SelectListItem>> LoadCasCadeDropDown(string _query , int Id)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                if (string.IsNullOrEmpty(_query) && Id==0)
                {
                    return await Task.Run(() => list);
                }
                else
                {
                    _query = string.Format(_query, Id);
                }
                using (IDbConnection con = new SqlConnection(ConnectionString))
                {
                    list = con.Query<SelectListItem>(_query).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
        public void Dispose()
        {
            ConnectionString = string.Empty;
        }
    }
}
