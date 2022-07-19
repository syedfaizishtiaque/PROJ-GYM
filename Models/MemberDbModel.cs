using System;

namespace GYM.Models
{
    public class MemberDbModel : BaseDbModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PostalAddress { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public string SMSNumber { get; set; }
        public string WhatsAppNumber { get; set; }
        public DateTime? FirstJoiningDate { get; set; } = DateTime.UtcNow;
        public string Gender { get; set; } = "Male";
        public DateTime? DOB { get; set; }

        public string Qualification { get; set; }
        public string Occupation { get; set; }



    }
}
