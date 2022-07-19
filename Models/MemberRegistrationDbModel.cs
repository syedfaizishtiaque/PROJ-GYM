using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM.Models
{
    public class MemberRegistrationDbModel : BaseDbModel
    {
        public int MemberId { get; set; }
        
        [ForeignKey("MemberId")]
        public MemberDbModel Member { get; set; }
        public uint RegistrationID { get; set; }
        public string ProfilePhoto { get; set; }
        public string MemberSignature { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string GymRepresentativeName { get; set; }
        public string RepresentativeSignature { get; set; }
        public string JoiningReason { get; set; }
        public double? RegistrationFee { get; set; }
        public double? MonthlyFee { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public double? BMI { get; set; }
    }
}
