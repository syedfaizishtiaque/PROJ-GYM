using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class BaseDbModel
    {
        [Key]
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get;set; }=DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; }=false;
        public byte StatusId { get; set; }


    }
}
