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
                Genre = GenreMapper.Map(entity.Genre),
                Author = AuthorMapper.Map(entity.Author),
            };
            return viewModel;
        }

        public static BookEntity Map(BookViewModel viewModel)
        {
            var entity = new BookEntity
            {
                ID = viewModel.ID,
                AuthorId = viewModel.AuthorId,
                PublisherId = viewModel.PublisherId,
                GenreId = viewModel.GenreId,
                Title = viewModel.Title,
                Cost = viewModel.Cost,
                Quantity = viewModel.Quantity,
                Genre = GenreMapper.Map(viewModel.Genre),
                Author = AuthorMapper.Map(viewModel.Author),
            };
            return entity;
        }

        public static List<BookViewModel> Map(List<BookEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
