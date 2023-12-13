using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Database
{
    public class UserRepository
    {
        public UserEntity Login(string login, string password)
        {
            if (login == null || password == null) return null;
            using (var context = new Context())
            {
                var item = context.Users
                    //.Include(x => x.Role)
                    .FirstOrDefault(x => x.Login == login && x.Password == password);
                return item;
            }
        }

        #region Методы: получить список,
        public List<UserViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Users.ToList();
                return UserMapper.Map(items);
            }
        }
        #endregion
    }
}
