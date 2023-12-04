using FinalProjectGym_management.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectGym_management.Data
{
    public  class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet <Members> Members { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<MemberSubscription> MembersSubscription { get; set; }
        public DbSet<Discounts> Discounts { get; set; }
        public DbSet<DiscountedMemberSubscriptions> DiscountedMembers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}