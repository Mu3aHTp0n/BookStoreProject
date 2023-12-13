using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.ViewModels
{
    public class PeopleViewModel
    {
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


        [StringLength(2147483647)]
        public string UserLogin { get; set; }
    }
}
