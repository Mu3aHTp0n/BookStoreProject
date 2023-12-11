using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class BookRepository
    {
        public List<BookViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Book.ToList();
                return BookMapper.Map(items);
            }
        }
        public BookViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Book.FirstOrDefault(x => x.ID == id);
                return BookMapper.Map(item);
            }
        }
    }
}
