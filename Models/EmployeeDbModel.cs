using System;

namespace GYM.Models
{
    public class EmployeeDbModel: BaseDbModel
    {
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PostalAddress { get; set; }
        public string ContactNumber { get; set; }
        public string ContactEmail { get; set; }
        public DateTime? HiredOn { get; set; }= DateTime.UtcNow;
        public string HiringDesignation { get; set; }
        public double? HiringSalary { get; set; }
        public string Gender { get; set; } = "Male";
        public uint? PayrollID { get; set; }
        public string CurrentSalary { get; set; }
        public string CurrentDesignation { get; set; }


    }
}
