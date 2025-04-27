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
            builder.Entity<TemplateEmail>().ToTable("TemplateEmail").HasKey(x => x.Id);
            builder.Entity<Book>().ToTable("Book").HasKey(x => x.Id);
            builder.Entity<UserBook>().ToTable("UserBook").HasKey(x => x.Id);
            builder.Entity<BookCategory>().ToTable("BookCategory").HasKey(x => x.Id);
            builder.Entity<UserTransaction>().ToTable("UserTransaction").HasKey(x => x.Id);
            builder.Entity<UserTransactionBook>().ToTable("UserTransactionBook").HasKey(x => x.Id);
            builder.Entity<Category>().ToTable("Category").HasKey(x => x.Id);
            builder.Entity<Comment>().ToTable("Comment").HasKey(x => x.Id);
            builder.Entity<BasicKnowledge>().ToTable("BasicKnowledge").HasKey(x => x.Id);
            builder.Entity<Conspectus>().ToTable("Conspectus").HasKey(x => x.Id);
            builder.Entity<Notification>().ToTable("Notification").HasKey(x => x.Id);
            builder.Entity<UserReport>().ToTable("UserReport").HasKey(x => x.Id);
            builder.Entity<UserBookView>().ToTable("UserBookView").HasKey(x => x.Id);
            builder.Entity<Room>().ToTable("Room").HasKey(x => x.Id);
            builder.Entity<NoteManager>().ToTable("NoteManager").HasKey(x => x.Id);
            builder.Entity<NoteUser>().ToTable("NoteUser").HasKey(x => x.Id);
            builder.Entity<CommentUser>().ToTable("CommentUsers").HasKey(x => x.Id);
            builder.Entity<Bank>().ToTable("Banks").HasKey(x => x.Id);
            builder.Entity<NotificationManager>().ToTable("NotificationManagers").HasKey(x => x.Id);
            builder.Entity<AuthorTransaction>().ToTable("AuthorTransactions").HasKey(x => x.Id);
        }

        public virtual DbSet<TemplateEmail> TemplateEmails { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }
        public virtual DbSet<UserBook> UserBooks { get; set; }
        public virtual DbSet<UserTransaction> UserTranscations { get; set; }
        public virtual DbSet<UserTransactionBook> UserTranscationBooks { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<BasicKnowledge> BasicKnowledges { get; set; }
        public virtual DbSet<Conspectus> Conspectuses { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<UserReport> UserReports { get; set; }
        public virtual DbSet<UserReportComment> UserReportComments { get; set; }
        public virtual DbSet<UserBookView> UserBookViews { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<PaymentItem> PaymentItems { get; set; }
        public virtual DbSet<NoteManager> NoteManagers { get; set; }
        public virtual DbSet<NoteUser> NoteUsers { get; set; }
        public virtual DbSet<MeilisearchLog> MeilisearchLogs { get; set; }
        public virtual DbSet<CommentUser> CommentUsers { get; set; }
        public virtual DbSet<NotificationManager> NotificationManagers { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<AuthorTransaction> AuthorTransactions { get; set; }
    }
}
