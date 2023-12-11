using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class GenreRepository
    {
        public List<GenreViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Genre.ToList();
                return GenreMapper.Map(items);
            }
        }
        public GenreViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Genre.FirstOrDefault(x => x.ID == id);
                return GenreMapper.Map(item);
            }
        }
    }
}
