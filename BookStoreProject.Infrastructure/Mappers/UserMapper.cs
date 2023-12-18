using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class UserMapper
    {
        public static UserEntity Map(UserViewModel viewModel)
        {
            var entity = new UserEntity
            {
                Login = viewModel.Login, 
                Password = viewModel.Password,
                RoleId = viewModel.RoleId,
            };
            return entity;
        }

        public static UserViewModel Map(UserEntity entity)
        {
            var viewModel = new UserViewModel
            {
                Login = entity.Login,
                Password = entity.Password,
                RoleId = entity.RoleId,
            };
            return viewModel;
        }

        public static List<UserEntity> Map(List<UserViewModel> viewModels)
        {
            var entities = viewModels.Select(vm => Map(vm)).ToList();
            return entities;
        }

        public static List<UserViewModel> Map(List<UserEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }

    }
}
