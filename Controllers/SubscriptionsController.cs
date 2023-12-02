using FinalProjectGym_management.BussinesLayer.Services.Implementation;
using FinalProjectGym_management.BussinesLayer.Services.Interface;
using FinalProjectGym_management.Data;
using FinalProjectGym_management.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectGym_management.Controllers
{
    public class SubscriptionsController : Controller
    {

        private readonly ISubscriptionService subscriptionService;
        private readonly ApplicationDbContext context;

        public SubscriptionsController(ISubscriptionService _subscriptionService, ApplicationDbContext _context)
        {
            subscriptionService = _subscriptionService;
            context = _context;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateSubscription()
        {

            var subscriptions = new Subscriptions();

            return View(subscriptions);
        }

        public IActionResult ActiveSubscription()
        {

            var memberSubscription = new MemberSubscription();

            return View(memberSubscription);
        }

        [HttpPost]
        public IActionResult CreateSubscription([Bind("Code ,Description,NumberOfMonths,WeekFrequency,TotalNumberOfSessions,TotalPrice")] Subscriptions subscriptions)
        {
            if (ModelState.IsValid)
            {

                subscriptionService.RegisterSubscription(subscriptions);
                return RedirectToAction("Index", "Home");
            }
            return View(subscriptions);
        }

        [HttpPost]
        public IActionResult ActiveSubscription(MemberSubscription memberSubscription)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (var error in errors)
                    {
                        Console.WriteLine($"ModelState Error: {error.ErrorMessage}");
                    }

                    // Handle validation errors, return a view, or redirect as needed
                    return View(memberSubscription); // or another view
                }

                subscriptionService.ActiveSubscription(memberSubscription);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                ModelState.AddModelError(string.Empty, "An error occurred while creating the active subscription.");
            }
            return RedirectToAction("Error");
            }

        [HttpPost]
        public IActionResult DeleteSubscription(int id)
        {
                     
            subscriptionService.DeleteSubscription(id);

            var subscription = subscriptionService.GetAllSubscriptions();

            return View("SubscriptionsList", subscription);

        }

        [HttpGet]
        public IActionResult GetAllSubscriptions()
        {
            var subscriptions = subscriptionService.GetAllSubscriptions();
            return View("SubscriptionsList" ,subscriptions);
        }

        [HttpGet] 
        public IActionResult Search(Subscriptions subscriptions)
        {
            var searchSubscription = subscriptionService.Search(subscriptions);

            var resultList = searchSubscription.ToList();

            return View("SubscriptionsList", resultList);
        }

        [HttpGet]
        public IActionResult GetAllMembersWithSubscriptions()
        {
            var subscriptions = subscriptionService.DisplayAllMemebersWithSubscription();
            return View("MemberSubscriptions", subscriptions);
        }


    }

}


