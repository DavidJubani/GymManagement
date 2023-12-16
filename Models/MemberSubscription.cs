using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.Currency)]
        public decimal OriginalPrice { get; set; }
        [DataType(DataType.Currency)]
        public decimal DiscountValue { get; set; }
        [DataType(DataType.Currency)]
        public decimal PaidPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public  int  RemainingSessions { get; set; }

        public  bool IsDeleted { get; set; }
    }
}
