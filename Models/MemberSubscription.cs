using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectGym_management.Models
{
    public class MemberSubscription
    {
        public int Id { get; set; }

        [ForeignKey(nameof(MemberId))]
        public Members? Member { get; set; }

        public int MemberId { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        public Subscriptions? Subscription { get; set; }
        
        public int SubscriptionId { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountValue { get; set; }

        public decimal PaidPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public  int  RemainingSessions { get; set; }

        public  bool IsDeleted { get; set; }
    }
}
