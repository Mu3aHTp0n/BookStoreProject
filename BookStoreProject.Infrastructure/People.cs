namespace BookStoreProject.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PeopleEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PeopleEntity()
        {
            Ordering = new HashSet<OrderingEntity>();
        }

        public long ID { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string SecondName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Name { get; set; }

        [StringLength(2147483647)]
        public string SurName { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string Sex { get; set; }

        [Required]
        [StringLength(2147483647)]
        public string DateOfBirth { get; set; }

        public long Role_ID { get; set; }

        [StringLength(2147483647)]
        public string UserLogin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderingEntity> Ordering { get; set; }

        public virtual RoleEntity Role { get; set; }
    }
}
