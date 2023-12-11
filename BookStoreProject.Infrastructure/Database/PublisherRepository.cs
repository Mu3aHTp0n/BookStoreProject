using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class PublisherRepository
    {
        public List<PublisherViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Publisher.ToList();
                return PublisherMapper.Map(items);
            }
        }
        public PublisherViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Publisher.FirstOrDefault(x => x.ID == id);
                return PublisherMapper.Map(item);
            }
        }

    }
}
