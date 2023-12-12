using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class PeopleRepository
    {
        public List<PeopleViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Peoples.ToList();
                return PeopleMapper.Map(items);
            }
        }
        public PeopleViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Peoples.FirstOrDefault(x => x.ID == id);
                return PeopleMapper.Map(item);
            }
        }
        
    }
}
