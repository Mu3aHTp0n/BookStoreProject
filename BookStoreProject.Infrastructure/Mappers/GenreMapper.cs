using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class GenreMapper
    {
        public static GenreViewModel Map(GenreEntity entity)
        {
            var viewModel = new GenreViewModel
            {
                ID = entity.ID,
                Title = entity.Title,

            };
            return viewModel;
        }

        public static List<GenreViewModel> Map(List<GenreEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
