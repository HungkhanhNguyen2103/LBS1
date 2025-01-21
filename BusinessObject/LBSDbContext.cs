using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject
{
    public class LBSDbContext : IdentityDbContext<Account>
    {
        public LBSDbContext(DbContextOptions<LBSDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();

            // Config Identity
            builder.Entity<Account>().ToTable("Account").HasKey(x => x.Id);
            //builder.Entity<Post>().ToTable("Post").HasKey(x => x.Id);
            //builder.Entity<PostCategory>().ToTable("PostCategory").HasKey(x => x.Id);
            //builder.Entity<AboutUs>().ToTable("AboutUs").HasKey(x => x.Id);
            //builder.Entity<Service>().ToTable("Service").HasKey(x => x.Id);
            //builder.Entity<ServiceOrder>().ToTable("ServiceOrder").HasKey(x => x.Id);
            //builder.Entity<ServiceOrderHistory>().ToTable("ServiceOrderHistory").HasKey(x => x.Id);
            //builder.Entity<UserQuestion>().ToTable("UserQuestion").HasKey(x => x.Id);
            //builder.Entity<Feedbacks>().ToTable("Feedbacks").HasKey(x => x.Id);
            builder.Entity<TemplateEmail>().ToTable("TemplateEmail").HasKey(x => x.Id);

        }

        public virtual DbSet<TemplateEmail> TemplateEmails { get; set; }
    }
}
