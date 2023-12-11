using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.ViewModels
{
    public class BookViewModel
    {
        public long ID { get; set; }

        public long AuthorId { get; set; }

        public long PublisherId { get; set; }

        public long GenreId { get; set; }

        public string Title { get; set; }

        public long Cost { get; set; }

        public long Quantity { get; set; }
    }
}
