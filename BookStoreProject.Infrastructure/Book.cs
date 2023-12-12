namespace BookStoreProject.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class BookEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookEntity()
        {
            Ordering = new HashSet<OrderingEntity>();
        }

        public long ID { get; set; }

        [Column("Author_ID")]
        public long AuthorId { get; set; }

        [Column("Publisher_ID")]
        public long PublisherId { get; set; }

        [Column("Genre_ID")]
        public long GenreId { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Title { get; set; }

        public long Cost { get; set; }

        public long Quantity { get; set; }

        public virtual AuthorEntity Author { get; set; }

        public virtual PublisherEntity Publisher { get; set; }

        public virtual GenreEntity Genre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderingEntity> Ordering { get; set; }
    }
}
