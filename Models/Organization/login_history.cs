using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM.Models.Organization
{
    public class login_history
    {
        public int app_sk { get; set; }
        public int usr_sk { get; set; }
        public int type_sk { get; set; }
        public string usr_ip { get; set; }
        public DateTime created_on { get; set; }
    }
}