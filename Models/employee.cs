using System;


namespace GYM.Models
{
    public class employee
    {
        public int Id { get;set; }
        public string enc_id { get;set; }
        public string name { get;set; }
        public string contact_no { get;set; }
        public string date_of_joining { get;set; }
        public string job_title { get; set; }
        public string email_id { get; set; }
        public string from_time { get; set; }
        public string to_time { get; set; }
        public int reporting_id { get; set; }
        public string working_hours { get; set; }
        public string reporting_name { get; set; }
        public string address { get; set; }
        public decimal salary { get; set; }
        public string guardian_name { get; set; }
        public string guardian_no { get; set; }
        public int sick_leave { get; set; }
        public int annual_leave { get; set; }
        public int use_sick_leave { get; set; }
        public int unuse_annual_leave { get; set; }
        public int unuse_sick_leave { get; set; }
        public int use_annual_leave { get; set; }
        public bool is_trainer { get; set; }
        public int? company_id { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime? created_on { get; set; } = DateTime.UtcNow;
        public DateTime? updated_on { get; set; } = DateTime.UtcNow;
        public bool is_active { get; set; } = true;
        public bool is_deleted { get; set; } = false;
    }
}