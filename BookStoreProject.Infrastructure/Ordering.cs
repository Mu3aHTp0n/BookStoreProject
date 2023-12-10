namespace BookStoreProject.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ordering")]
    public partial class OrderingEntity
    {
        public long ID { get; set; }

        public long People_ID { get; set; }

        public long Book_ID { get; set; }

        public long Count { get; set; }

        public decimal Date { get; set; }

        public virtual BookEntity Book { get; set; }

        public virtual PeopleEntity People { get; set; }
    }
}
