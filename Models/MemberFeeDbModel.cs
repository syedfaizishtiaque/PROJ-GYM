using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYM.Models
{
    public class MemberFeeDbModel :BaseDbModel
    {
        public int RegistrationId { get; set; }

        [ForeignKey("RegistrationId")]
        public MemberRegistrationDbModel Registration { get; set; }

        public int AccountHeadId { get; set; }
        [ForeignKey("AccountHeadId")]
        public AccountsHeadsDbModel AccountHead { get; set; }

        public double? BillAmount { get; set; }
        public double? ReceivedAmount { get; set; }
        public double? DiscountAmount { get; set; }

        public DateTime? BillDate { get; set; }
        public DateTime? ReceivedOn { get; set; }
        public string ReceiptNumber { get; set; }




    }
}
