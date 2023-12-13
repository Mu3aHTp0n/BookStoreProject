using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class PublisherMapper
    {
        public static PublisherEntity Map(PublisherViewModel viewModel)
        {
            var entity = new PublisherEntity
            {
                ID = viewModel.ID,
                Title = viewModel.Title,
            };
            return entity;
        }

        #region кусок кода,
        public static PublisherViewModel Map(PublisherEntity entity)
        {
            var viewModel = new PublisherViewModel
            {
                ID = entity.ID,
                Title = entity.Title,
            };
            return viewModel;
        }

        public static List<PublisherViewModel> Map(List<PublisherEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        #endregion
    }
}
