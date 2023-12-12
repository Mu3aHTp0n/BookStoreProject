using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class DiscountMapper
    {
        public static DiscountViewModel Map(DiscountEntity entity)
        {
            var viewModel = new DiscountViewModel
            {
                ID = entity.ID,
                Title = entity.Title,
                Value = entity.Value,
            };
            return viewModel;
        }

        public static List<DiscountViewModel> Map(List<DiscountEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
