using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.ViewModels
{
    public class PeopleViewModel
    {
        public long ID { get; set; }

        public string SecondName { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Sex { get; set; }

        public string DateOfBirth { get; set; }

        public long RoleId { get; set; }

        public string UserLogin { get; set; }
    }
}
