using System.ComponentModel.DataAnnotations;

namespace GYM.Models
{
    public class AccountsHeadsDbModel : BaseDbModel
    {
        public double? FeeAmount { get; set; }
        public double? MaximumDiscount { get; set; }
        public int? IntervalsInDays { get; set; }
        public bool AutoGenerateBill { get; set; } = false;


    }
}
