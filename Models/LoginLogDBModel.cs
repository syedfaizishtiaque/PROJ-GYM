using System;
using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class LoginLogDBModel
    {
        [Key]
        public int? Id { get; set; }
        public string IPAddress { get; set; }
        public string UserName { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Status { get; set; }
        public string Remarks { get; set; }
    }
}