using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreProject.Infrastructure.Mappers
{
    public static class PeopleMapper
    {
        public static PeopleEntity Map(PeopleViewModel viewModel)
        {
            var entity = new PeopleEntity
            {
                ID = viewModel.ID,
                SecondName = viewModel.SecondName,
                Name = viewModel.Name,
                SurName = viewModel.SurName,
                Sex = viewModel.Sex,
                DateOfBirth = viewModel.DateOfBirth,
                RoleId = viewModel.RoleId,
                UserLogin = viewModel.UserLogin,
            };
            return entity;
        }

        public static PeopleViewModel Map(PeopleEntity entity)
        {
            var viewModel = new PeopleViewModel()
            {
                ID = entity.ID,
                SecondName = entity.SecondName,
                Name = entity.Name,
                SurName = entity.SurName,
                Sex = entity.Sex,
                DateOfBirth = entity.DateOfBirth,
                RoleId = entity.RoleId,
                UserLogin = entity.UserLogin,
            };
            return viewModel;
        }

        public static List<PeopleViewModel> Map(List<PeopleEntity> entities)
        {
            var viewModels = entities.Select(x => Map(x)).ToList();
            return viewModels;
        }
    }
}
