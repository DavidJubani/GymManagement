using FinalProjectGym_management.Models;
using System.Diagnostics.Metrics;

namespace FinalProjectGym_management.BussinesLayer.Services.Interface
{
    public interface IMemberService
    {

        public void RegisterMember(Members members);

        // public Members GetMemberByIdCardNumber(int IdCardNumber);

        // public Task<List<Members>> GetMemberByFirstName(string firstname);

        // public Task<List<Members>> GetMemberByLastName(string lastname);

        // public  Task<List<Members>> GetMemberByEmail(string email);

        public void DeleteMember(int id);

        public List<Members> GetAllMembers();
        public List<Members> Search(Members members);
    }
}
