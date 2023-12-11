using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class OrderingRepository
    {
        public List<OrderingViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Ordering.ToList();
                return OrderingMapper.Map(items);
            }
        }
        public OrderingViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Ordering.FirstOrDefault(x => x.ID == id);
                return OrderingMapper.Map(item);
            }
        }
    }
}
