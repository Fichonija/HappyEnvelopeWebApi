using HappyEnvelopeWebApi.Models.Codebook;
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

    }
}