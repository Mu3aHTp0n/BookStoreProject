using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class RoleRepository
    {
        public List<RoleViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Role.ToList();
                return RoleMapper.Map(items);
            }
        }
        public RoleViewModel GetById(long id)
        {
            using (var context = new Context())
            {
                var item = context.Role.FirstOrDefault(x => x.ID == id);
                return RoleMapper.Map(item);
            }
        }

    }
}
