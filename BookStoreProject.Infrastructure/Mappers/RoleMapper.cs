using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public class RoleMapper
    {
        public static RoleViewModel Map(RoleEntity entity)
        {
            var viewModel = new RoleViewModel
            {
                ID = entity.ID, 
                Name = entity.Name,
            };
            return viewModel;
        }
        public static RoleEntity Map(UserViewModel viewModel)
        {
            var entity = new RoleEntity
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
            };
            return entity;
        }

        #region кусок кода,
        public static RoleViewModel Map(RoleEntity entity)
        {
            var viewModel = new RoleViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
            };
            return viewModel;
        }

        public static List<RoleViewModel> Map(List<RoleEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
        #endregion 
    }
}
