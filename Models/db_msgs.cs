using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.MODELS
{
    public class db_msgs
    {
        public int row_sk { get; set; }
        public int dept_sk { get; set; }
        public int role_sk { get; set; }
        public string msg { get; set; }
        public DateTime? created_on { get; set; }
        public bool msg_status { get; set; }
        public int viewed_by { get; set; }
        public DateTime? viewed_on { get; set; }
    }
}