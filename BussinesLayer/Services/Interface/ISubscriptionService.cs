using FinalProjectGym_management.Models;

namespace FinalProjectGym_management.BussinesLayer.Services.Interface
{
    public interface ISubscriptionService
    {
        public void RegisterSubscription(Subscriptions subscriptions);
        public void ActiveSubscription(MemberSubscription memberSubscription);
        public void DeleteSubscription(int ID);
        public List<Subscriptions> GetAllSubscriptions();
        public List<Subscriptions> Search(Subscriptions subscriptions);
        public List<MemberSubscription> DisplayAllMemebersWithSubscription();
    }
}
