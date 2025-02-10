﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
            builder.Entity<TemplateEmail>().ToTable("TemplateEmail").HasKey(x => x.Id);
            builder.Entity<Book>().ToTable("Book").HasKey(x => x.Id);
            builder.Entity<UserBook>().ToTable("UserBook").HasKey(x => x.Id);
            builder.Entity<UserTranscation>().ToTable("UserTranscation").HasKey(x => x.Id);
            builder.Entity<UserTranscationBook>().ToTable("UserTranscationBook").HasKey(x => x.Id);
            builder.Entity<Category>().ToTable("Category").HasKey(x => x.Id);
            builder.Entity<Comment>().ToTable("Comment").HasKey(x => x.Id);
        }

        public virtual DbSet<TemplateEmail> TemplateEmails { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<UserBook> UserBooks { get; set; }
        public virtual DbSet<UserTranscation> UserTranscations { get; set; }
        public virtual DbSet<UserTranscationBook> UserTranscationBooks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}
