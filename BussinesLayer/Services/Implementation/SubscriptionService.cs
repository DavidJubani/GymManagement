using FinalProjectGym_management.BussinesLayer.Services.Interface;
using FinalProjectGym_management.Data;
using FinalProjectGym_management.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinalProjectGym_management.BussinesLayer.Services.Implementation
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _context;


        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void RegisterSubscription(Subscriptions subscriptions)
        {
            try
            {
                var existingSubscription = _context.Subscriptions.FirstOrDefault(s => s.Code == subscriptions.Code);

                if (existingSubscription == null)
                {

                    int totalNumberOfSessions = subscriptions.WeekFrequency * subscriptions.NumberOfMonths * 4;

                    var newSubscription = new Subscriptions()
                    {
                        Id = subscriptions.Id,
                        Code = subscriptions.Code,
                        TotalNumberOfSessions = totalNumberOfSessions,
                        Description = subscriptions.Description,
                        TotalPrice = subscriptions.TotalPrice,
                        NumberOfMonths = subscriptions.NumberOfMonths,
                        WeekFrequency = subscriptions.WeekFrequency,
                        IsDeleted = subscriptions.IsDeleted,

                    };
                    _context.Subscriptions.Add(newSubscription);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Subscription with the same code already exists");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in registering Subscription", ex);
            }
        }


        public void ActiveSubscription(MemberSubscription memberSubscription)
        {
            try
            {
                // Retrieve the existing member and subscription based on their Ids
                var existingMember = _context.Members.Find(memberSubscription.MemberId);
                var existingSubscription = _context.Subscriptions.Find(memberSubscription.SubscriptionId);

                if (existingMember != null && existingSubscription != null && !existingMember.IsDeleted && !existingSubscription.IsDeleted)
                {
                    var HasActiveSubscription = _context.MembersSubscription.Any(s => s.MemberId == existingMember.Id && !s.Subscription.IsDeleted);

                    if (!HasActiveSubscription)
                    {
                        var newMemberSubscription = new MemberSubscription
                        {
                            MemberId = existingMember.Id,
                            SubscriptionId = existingSubscription.Id,
                            OriginalPrice = memberSubscription.OriginalPrice,
                            DiscountValue = memberSubscription.DiscountValue,
                            PaidPrice = memberSubscription.PaidPrice,
                            StartDate = memberSubscription.StartDate,
                            EndDate = memberSubscription.EndDate,
                            RemainingSessions = memberSubscription.RemainingSessions,
                            // Set other properties of MemberSubscription as needed
                        };


                        // Perform logic to save newMemberSubscription to the database
                        _context.MembersSubscription.Add(newMemberSubscription);
                        _context.SaveChanges();

                    }
                }
                else
                {
                    // Handle the case where either the member or subscription does not exist
                    throw new Exception("Cant active subscription");
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or rethrow if needed
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        } 

        public void DeleteSubscription(int ID)
        {
            try
            {
             var subscripion = _context.Subscriptions.FirstOrDefault(s => s.Id == ID);

             if (subscripion == null)
                {
                  throw new Exception("Subscripion not found ");
                }

             subscripion.IsDeleted = true;
             _context.SaveChanges();
             }

            catch (Exception ex)
            {
                throw new Exception("Error in deleting subscription ", ex);
            }

        }

        public  List <Subscriptions> GetAllSubscriptions()
        {
            try
            {
                var AllSubscriptions = _context.Subscriptions;
                var subscriptions = new List<Subscriptions>();
                foreach (var s in AllSubscriptions)
                {
                    subscriptions.Add(new Subscriptions()
                    {
                        Id = s.Id,
                        Code = s.Code,
                        Description = s.Description,
                        NumberOfMonths = s.NumberOfMonths,
                        WeekFrequency = s.WeekFrequency,
                        TotalNumberOfSessions = s.TotalNumberOfSessions,
                        TotalPrice = s.TotalPrice,
                        IsDeleted = s.IsDeleted,

                    });

                }

                return subscriptions;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in finding subscription", ex);
            }
        }


        public List<Subscriptions> Search(Subscriptions subscriptions)
        {
            /// under construction
            /// 
            var query = _context.Subscriptions.AsQueryable();

            if (subscriptions.Code != 0)
            {
                query = query.Where(s=>s.Code == subscriptions.Code);
            }
            if(!string.IsNullOrEmpty(subscriptions.Description))
            {
                query = query.Where(s=>s.Description.Contains(subscriptions.Description));
            }
            if (subscriptions.NumberOfMonths != 0)
            {
                query = query.Where(s => s.NumberOfMonths == subscriptions.NumberOfMonths);
            }
            if (subscriptions.WeekFrequency != 0)
            {
                query = query.Where(s => s.WeekFrequency == subscriptions.WeekFrequency);
            }
            var result = query.ToList();

            return result;

        }

        public List<MemberSubscription> DisplayAllMemebersWithSubscription()
        {
            {
                try
                {
                    var membersubscriptions = _context.MembersSubscription
    .Include(ms => ms.Member)
    .Include(ms => ms.Subscription)
    .Where(ms => !ms.Member.IsDeleted && !ms.Subscription.IsDeleted)
    .ToList();
                    var memsubscriptions = new List<MemberSubscription>();

                    
                    foreach (var s in membersubscriptions)
                    {
                        memsubscriptions.Add(new MemberSubscription()
                        {
                            Id = s.Id,
                            MemberId = s.MemberId,                           
                            SubscriptionId = s.SubscriptionId,
                            OriginalPrice = s.OriginalPrice,
                            DiscountValue = s.DiscountValue,
                            PaidPrice = s.PaidPrice,
                            StartDate = s.StartDate,
                            EndDate = s.EndDate,
                            RemainingSessions =s.RemainingSessions,
                            IsDeleted = s.IsDeleted,
                           

                        });

                    }

                    return memsubscriptions;
                }

                catch (Exception ex)
                {

                    throw new Exception("Error in finding subscription", ex);
                }
            }

        }

    }
}

 








