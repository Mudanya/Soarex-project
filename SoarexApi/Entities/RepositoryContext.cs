using Entities.Configurations;
using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserConfiguration());
            builder.ApplyConfiguration(new IdentityUserRoleConfiguration());
            builder.ApplyConfiguration(new IdentityRoleConfiguration());
        }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<CustomerFeedback> CustomerFeedback { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicy { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Terms> Terms { get; set; }
        public DbSet<KeyAreas> KeyAreas { get; set; }

    }
}