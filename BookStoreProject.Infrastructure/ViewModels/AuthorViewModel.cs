using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.ViewModels
{
    internal class AuthorViewModel
    {
        public long ID { get; set; }

        public string SurName { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }
    }
}
