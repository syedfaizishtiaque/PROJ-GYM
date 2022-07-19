using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM.Models
{
    public class MemberHistoryDbModel: BaseDbModel
    {
        public int? MemberId { get; set; }

        [ForeignKey("MemberId")]
        public MemberDbModel Member { get; set; }
        public DateTime? JoiningDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Remarks { get; set; }
        
    }
}
