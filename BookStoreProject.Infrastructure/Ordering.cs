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

        [Column("People_ID")]
        public long PeopleId { get; set; }

        [Column("Book_ID")]
        public long BookId { get; set; }

        public string Count { get; set; }

        public string Date { get; set; }

        public virtual BookEntity Book { get; set; }

        public virtual PeopleEntity People { get; set; }
    }
}
