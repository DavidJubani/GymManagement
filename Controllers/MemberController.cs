using FinalProjectGym_management.BussinesLayer.Services.Implementation;
using FinalProjectGym_management.BussinesLayer.Services.Interface;
using FinalProjectGym_management.Data;
using FinalProjectGym_management.Models;
using FinalProjectGym_management.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace FinalProjectGym_management.Controllers
{
    public class MemberController : Controller
    {

        private readonly IMemberService memberService;
       

        public MemberController (IMemberService _memberService)
        {
            memberService = _memberService;
            

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            var model = new MembersVM();

            return View (model);
        }



        public IActionResult Search()
        {
            var search = new Members();

            return View(search);
        }

        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,Birthday,IdCardNumber,Email")] Members member)
        {
            if (ModelState.IsValid)
            {

                memberService.RegisterMember(member);
                return RedirectToAction("Index", "Home");
            }
            TempData["ErrorMessage"] = "There was an error. Please check your input.";
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var members =   memberService.GetAllMembers();
            return View("MemberList", members);
        }

        [HttpPost]
        public async Task <IActionResult> Delete(int id)
        {
            memberService.DeleteMember(id);
            var members =  memberService.GetAllMembers(); // Fetch the updated list of members
            return View("MemberList", members);
        }

        [HttpGet]
        public IActionResult Search(Members members)
        {
            
            var searchResults = memberService.Search(members);

            // Ensure that the result is a collection (even if it contains only one item)
            var searchResultsList = searchResults.ToList();

            return View("MemberList", searchResultsList);
        }



    }
}
