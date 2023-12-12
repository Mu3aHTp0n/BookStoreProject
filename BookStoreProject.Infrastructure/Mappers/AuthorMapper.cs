using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class AuthorMapper
    {
        public static AuthorViewModel Map(AuthorEntity entity)
        {
            var viewModel = new AuthorViewModel
            {
                ID = entity.ID,
                SurName = entity.SurName,
                Name = entity.Name,
                SecondName = entity.SecondName,
            };
            return viewModel;
        }

        public static AuthorEntity Map(AuthorViewModel viewModel)
        {
            var entity = new AuthorEntity
            {
                ID = viewModel.ID,
                SurName = viewModel.SurName,
                Name = viewModel.Name,
                SecondName = viewModel.SecondName,
            };
            return entity;
        }

        public static List<AuthorViewModel> Map(List<AuthorEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
