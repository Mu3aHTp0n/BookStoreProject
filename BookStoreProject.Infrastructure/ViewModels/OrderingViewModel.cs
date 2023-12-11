using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.ViewModels
{
    public class OrderingViewModel
    {
        public long ID { get; set; }

        public long PeopleId { get; set; }

        public long BookId { get; set; }

        public long Count { get; set; }

        public decimal Date { get; set; }
    }
}
