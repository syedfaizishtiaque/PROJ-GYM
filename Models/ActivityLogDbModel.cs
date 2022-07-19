using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class ActivityLogDbModel
    {
        [Key]
        public int Id { get; set; }
        public string ActivityType { get; set; }
        public string ActivityDetail { get; set; }
        public int UserId { get; set; }
        public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;

       


    }
}
