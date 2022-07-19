using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.MODELS
{
    public class audit_log
    {
        public int log_id { get; set; }
        public int record_pk { get; set; }
        public string form_ref { get; set; }
        public string form_post_data { get; set; }
        public int user_id { get; set; }
        public DateTime created_on { get; set; }
        public string action { get; set; }
        public string rec_st_code { get; set; }
        public int? is_email_sent { get; set; }
        public DateTime? sent_datetime { get; set; }
    }
}