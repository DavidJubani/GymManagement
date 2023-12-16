using Microsoft.EntityFrameworkCore;
using FinalProjectGym_management.Models;
using FinalProjectGym_management.BussinesLayer.Services.Interface;
using FinalProjectGym_management.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using Microsoft.AspNetCore.Components.Forms;

namespace FinalProjectGym_management.BussinesLayer.Services.Implementation
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationDbContext _dbcontext;

        public MemberService(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void RegisterMember(Members members)
        {
            try
            {
                var existingMember = _dbcontext.Members.FirstOrDefault(m => m.Id == members.Id);

                if (existingMember == null) 
                {
                    var newMember = new Members()
                    {
                        Id = members.Id,
                        FirstName = members.FirstName,
                        LastName = members.LastName,
                        Birthday = members.Birthday,
                        IdCardNumber = members.IdCardNumber,
                        Email = members.Email,
                        Registration_Date = DateTime.Now,
                        IsDeleted = members.IsDeleted,
                    };

                    _dbcontext.Members.Add(newMember);
                    _dbcontext.SaveChanges();

                }
            
                else
                {
                    throw new Exception("Member already exist");
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error in registering member", ex);
            }
        }



        public void DeleteMember(int id)
        {

            try
            {
                var member = _dbcontext.Members.FirstOrDefault(p => p.Id == id);
                

                if (member == null)
                {
                    throw new Exception("Member not found");
                } 
                member.IsDeleted = true ;

                var membersub = _dbcontext.MembersSubscription.FirstOrDefault(p => p.MemberId == id);
                if (membersub != null)
                {
                    membersub.IsDeleted = true;
                }


                _dbcontext.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception("Error in deleting member " , ex);
            }

        }

        public List<Members> GetAllMembers()
        {
            try
            {
                var AllMembers = _dbcontext.Members.ToList();
                var members = new List<Members>();
                foreach (var m in AllMembers)
                {
                    members.Add(new Members()
                    {
                        Id = m.Id,
                        FirstName = m.FirstName,
                        LastName = m.LastName,
                        Birthday = m.Birthday,
                        IdCardNumber = m.IdCardNumber,
                        Email = m.Email,
                        Registration_Date = m.Registration_Date,
                        IsDeleted = m.IsDeleted,

                    });

                }

                return members;
            }

            catch (Exception ex)
            {

                throw new Exception("Error in finding member", ex);
            }
        }

        public List<Members> Search(Members members)
        {
            var query = _dbcontext.Members.AsQueryable();

            if (members.IdCardNumber != 0)
            {
                query = query.Where(m => m.IdCardNumber == members.IdCardNumber);
            }
            if (!string.IsNullOrEmpty(members.FirstName))
            {
                query = query.Where(m => m.FirstName.Contains(members.FirstName));
            }
            if (!string.IsNullOrEmpty(members.LastName))
            {
                query = query.Where(m => m.LastName.Contains(members.LastName));
            }
            if (!string.IsNullOrEmpty(members.Email))
            {
                query = query.Where(m => m.Email.Contains(members.Email));
            }

            var result = query.ToList();

            return result;
        }

    }
}
   


