using System;


namespace GYM.Models
{
    public class AdmissionForm
    {
        public int Id { get; set; }
        public string enc_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string gender { get; set; }
        public string CNIC { get; set; }
        public string contact_number { get; set; }
        public bool is_resident { get; set; } = true;
        public string address { get; set; }
        public string email { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string purpose_of_joining { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; }
        public int? company_id { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime? created_on { get; set; } = DateTime.UtcNow;
        public DateTime? updated_on { get; set; } = DateTime.UtcNow;
        public bool is_active { get; set; } = true;
        public bool is_deleted { get; set; } = false;
    }
}