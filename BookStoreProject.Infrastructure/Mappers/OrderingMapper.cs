using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class OrderingMapper
    {
        public static OrderingViewModel Map(OrderingEntity entity)
        {
            var viewModel = new OrderingViewModel
            {
                ID = entity.ID,
                PeopleId = entity.PeopleId,
                BookId = entity.BookId,
                Count = entity.Count,
                Date = entity.Date,
                People = PeopleMapper.Map(entity.People),
                Book = BookMapper.Map(entity.Book),
            };
            return viewModel;
        }

        public static OrderingEntity Map(OrderingViewModel viewModel)
        {
            var entity = new OrderingEntity
            {
                ID = viewModel.ID,
                PeopleId = viewModel.PeopleId,
                BookId = viewModel.BookId,
                Count = viewModel.Count,
                Date = viewModel.Date,
                People = PeopleMapper.Map(viewModel.People),
                Book = BookMapper.Map(viewModel.Book),
            };
            return entity;
        }

        public static List<OrderingViewModel> Map(List<OrderingEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
