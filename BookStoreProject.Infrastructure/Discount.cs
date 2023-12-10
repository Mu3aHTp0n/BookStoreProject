namespace BookStoreProject.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Discount")]
    public partial class DiscountEntity
    {
        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Title { get; set; }

        public long Value { get; set; }
    }
}
