using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class DiscountRepository
    {
        public List<DiscountViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Discount.ToList();
                return DiscountMapper.Map(items);
            }
        }

        public DiscountViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Discount.FirstOrDefault(x => x.ID == id);
                return DiscountMapper.Map(item);
            }
        }
    }
}
