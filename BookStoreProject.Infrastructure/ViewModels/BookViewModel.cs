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

        public string Cost { get; set; }

        public string Quantity { get; set; }

        public AuthorViewModel Author { get; set; }

        public PublisherViewModel Publisher { get; set; }

        public GenreViewModel Genre { get; set; }
    }
}
