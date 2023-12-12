using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class AuthorRepository
    {
        public List<AuthorViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Authors.ToList();
                return AuthorMapper.Map(items);
            }
        }
        public AuthorViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Authors.FirstOrDefault(x => x.ID == id);
                return AuthorMapper.Map(item);
            }
        }

    }
}
