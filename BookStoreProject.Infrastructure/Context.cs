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

        public virtual DbSet<AuthorEntity> Authors { get; set; }
        public virtual DbSet<BookEntity> Books { get; set; }
        public virtual DbSet<DiscountEntity> Discounts { get; set; }
        public virtual DbSet<GenreEntity> Genres { get; set; }
        public virtual DbSet<OrderingEntity> Orderings { get; set; }
        public virtual DbSet<PeopleEntity> Peoples { get; set; }
        public virtual DbSet<PublisherEntity> Publishers { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Author)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BookEntity>()
                .HasMany(e => e.Ordering)
                .WithRequired(e => e.Book)
                .HasForeignKey(e => e.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GenreEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Genre)
                .HasForeignKey(e => e.GenreId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderingEntity>()
                .Property(e => e.Date)
                .HasPrecision(53, 0);

            modelBuilder.Entity<PeopleEntity>()
                .HasMany(e => e.Ordering)
                .WithRequired(e => e.People)
                .HasForeignKey(e => e.PeopleId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PublisherEntity>()
                .HasMany(e => e.Book)
                .WithRequired(e => e.Publisher)
                .HasForeignKey(e => e.PublisherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RoleEntity>()
                .HasMany(e => e.People)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete(false);
        }
    }
}
