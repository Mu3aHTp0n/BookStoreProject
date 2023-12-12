using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class BookMapper
    {
        public static BookViewModel Map(BookEntity entity)
        {
            var viewModel = new BookViewModel
            {
                ID = entity.ID,
                AuthorId = entity.AuthorId,
                PublisherId = entity.PublisherId,
                GenreId = entity.GenreId,
                Title = entity.Title,
                Cost = entity.Cost,
                Quantity = entity.Quantity,
            };
            return viewModel;
        }

        public static List<BookViewModel> Map(List<BookEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
