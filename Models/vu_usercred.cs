using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM.Models
{
    public class vu_usercred
    {
        [Required(ErrorMessage = "Domain Id is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }
        public string securitykey { get; set; }
    }
}
