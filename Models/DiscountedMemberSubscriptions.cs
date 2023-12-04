using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectGym_management.Models
{
    public class DiscountedMemberSubscriptions
    {

        public int Id { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        public MemberSubscription? MemberSubscription { get; set; }

        public int SubscriptionId { get; set; }

        [ForeignKey(nameof(DiscountId))]

        public Discounts? Discount { get; set; }

        public int DiscountId { get; set; }
    }
}
