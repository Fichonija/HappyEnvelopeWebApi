using HappyEnvelopeWebApi.Models.Codebook;
using HappyEnvelopeWebApi.Models.Main;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace HappyEnvelopeWebApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Locale> Locales{ get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Gift> Gifts{ get; set; }
        public DbSet<Calculation> Calculations { get; set; }
        public DbSet<Wedding> Weddings { get; set; }
    }
}