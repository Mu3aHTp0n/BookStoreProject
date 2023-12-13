namespace BookStoreProject.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class UserEntity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2147483647)]
        public string Login { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2147483647)]
        public string Password { get; set; }

        [Column("Role_ID")]
        public long RoleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual RoleEntity Role { get; set; }
    }
}
