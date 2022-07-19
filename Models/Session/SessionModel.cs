using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Models.Session
{
    public class SessionModel
    {
        public int usr_sk { get; set; }
        public string usr_nme { get; set; }
        public string usr_full_nme { get; set; }
        public int app_sk { get; set; }
        public string app_desc { get; set; }
        public int role_sk { get; set; }
        public string role_desc { get; set; }
        public int mnu_sk { get; set; }
        public string mnu_desc { get; set; }
        public string mnu_url { get; set; }
        public string mnu_icon { get; set; }
        public int parent_mnu_sk { get; set; }
        public int seq_no { get; set; }
        public bool can_slct { get; set; }
        public bool can_insrt { get; set; }
        public bool can_updt { get; set; }
        public bool can_del { get; set; }
        public int dept_sk { get; set; }
        public string dept_name { get; set; }
        public int branch_code { get; set; }
        public string bran_name { get; set; }
        public int dept_type_sk { get; set; }
        public string dept_type_name { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
     public List<vu_mapping> mapping { get; set; }
    }

    public class CardStatus
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public bool IsClose { get; set; }
    }

    public class vu_mapping
    {
        public string  code { get; set; }
        public string map_code { get; set; }
        public string rec_st_title { get; set; }
        public string visible_to { get; set; }
        public string idnt { get; set; }
    }
}
