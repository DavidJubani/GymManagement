using FinalProjectGym_management.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectGym_management.ViewModels
{
    public class MemberSubscriptionVM
    {
        [ForeignKey(nameof(MemberId))]
        public Members? Member { get; set; }

        public int MemberId { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        public Subscriptions? Subscription { get; set; }

        public int SubscriptionId { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountValue { get; set; }

        public DateTime EndDate { get; set; }

        public int RemainingSessions { get; set; }
    }
}
