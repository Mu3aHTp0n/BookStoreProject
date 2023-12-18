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
                    //.Include(x => x.RoleId)
                    .FirstOrDefault(x => x.Login == login && x.Password == password);
                return item;
            }
        }

        public UserViewModel GetByRoleId(long id)
        {
            using (var context = new Context())
            {
                var item = context.Users.FirstOrDefault(x => x.RoleId == id);
                return UserMapper.Map(item);
            }
        }

        
        public List<UserViewModel> GetList()
        {
            using (var context = new Context())
            {
                var items = context.Users.ToList();
                //Console.WriteLine(typeof (
                //    items));
                return UserMapper.Map(items);
            }
        }
        #region Методы: Удалить, Добавить
        public void Delete()
        {
            using (var context = new Context())
            {
                UserEntity user = context.Users.FirstOrDefault();
                if (user != null)
                {
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
            }
        }

        public UserViewModel AddUser(UserEntity entity)
        {
            entity.Login = entity.Login.Trim();
            entity.Password = entity.Password.Trim();
            entity.RoleId = entity.RoleId;
            if (string.IsNullOrEmpty(entity.Login) || string.IsNullOrEmpty(entity.Password))
            {
                throw new Exception("Не все поля заполены");
            }
            using(var context = new Context())
            {
                context.Users.Add(entity);
                context.SaveChanges();
            }

            return UserMapper.Map(entity);
        }
        #endregion
    }
}
