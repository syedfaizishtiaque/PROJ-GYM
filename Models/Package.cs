using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GYM.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string enc_id { get; set; }
        public string package_name { get; set; }
        public double package_fee { get; set; }
        public double registration_fee { get; set; }
        public double session_adj { get; set; }
        public string expiry_date { get; set; }
        public int? company_id { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime? created_on { get; set; } = DateTime.UtcNow;
        public DateTime? updated_on { get; set; } = DateTime.UtcNow;
        public bool is_active { get; set; } = true;
        public bool is_deleted { get; set; } = false;
        
    }
}