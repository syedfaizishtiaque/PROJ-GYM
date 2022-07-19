using System;


namespace GYM.Models
{
    public class package_assignment
    {
        public int addmission_id { get; set; }
        public int package_id { get; set; }
        public decimal package_fee { get; set; }
        public decimal session_adj { get; set; }
        public string expiry_date { get; set; }

        public string enc_packageid { get; set; }
        public string enc_admission_id { get; set; }
        public string enc_id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get { return first_name + " " + middle_name + " " + last_name; } }
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

        //Assignment
        public int Id { get; set; }
        public decimal registration_fee_discount { get; set; }
        public decimal package_fee_discount { get; set; }
        public decimal special_discount { get; set; }
        public string joining_date { get; set; }
        public string effective_date { get; set; }
        //end
        public int? company_id { get; set; }
        public int created_by { get; set; }
        public int updated_by { get; set; }
        public DateTime? created_on { get; set; } = DateTime.UtcNow;
        public DateTime? updated_on { get; set; } = DateTime.UtcNow;
        public bool is_active { get; set; } = true;
        public bool is_deleted { get; set; } = false;
    }
}