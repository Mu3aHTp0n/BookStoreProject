using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookStoreProject.Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<AuthorEntity> Author { get; set; }
        public virtual DbSet<BookEntity> Book { get; set; }
        public virtual DbSet<DiscountEntity> Discount { get; set; }
        public virtual DbSet<GenreEntity> Genre { get; set; }
        public virtual DbSet<OrderingEntity> Ordering { get; set; }
        public virtual DbSet<PeopleEntity> People { get; set; }
        public virtual DbSet<PublisherEntity> Publisher { get; set; }
        public virtual DbSet<RoleEntity> Role { get; set; }
        public virtual DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.Author_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookEntity>()
                .HasMany(e => e.Ordering)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.Book_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GenreEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Genre)
                .HasForeignKey(e => e.Genre_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderingEntity>()
                .Property(e => e.Date)
                .HasPrecision(53, 0);

            modelBuilder.Entity<PeopleEntity>()
                .HasMany(e => e.Ordering)
                .WithRequired(e => e.People)
                .HasForeignKey(e => e.People_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublisherEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.Publisher_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.Role_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
