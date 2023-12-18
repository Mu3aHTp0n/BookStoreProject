using BookStoreProject.Infrastructure.Mappers;
using BookStoreProject.Infrastructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        #region Методы: удалить, добавить, обновить
        public PeopleViewModel Delete(long id)
        {
            using(var context = new Context())
            {
                var peopleRemove = context.Peoples.FirstOrDefault(y => y.ID == id);
                if (peopleRemove != null)
                {
                    context.Peoples.Remove(peopleRemove);
                    context.SaveChanges();
                }
                return PeopleMapper.Map(peopleRemove);
            }
        }
        public PeopleViewModel AddPeople(PeopleEntity entity)
        {
            entity.SecondName = entity.SecondName.Trim();
            entity.Name = entity.Name.Trim();
            entity.SurName = entity.SurName.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.Sex = entity.Sex.Trim();
            entity.UserLogin = entity.UserLogin.Trim();

            if (string.IsNullOrEmpty(entity.SecondName) || string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.Sex) || string.IsNullOrEmpty(entity.UserLogin))
            {
                throw new Exception("Не все поля заполнены");
            }
            using (var context = new Context())
            {
                context.Peoples.Add(entity);
                context.SaveChanges();
            }
            return PeopleMapper.Map(entity);
        }
        public List<PeopleViewModel> Search(string search)
        {
            search = search.Trim().ToLower();

            using (var context = new Context())
            {
                var result = context.Peoples
                    .Where(x =>
                        x.SecondName.ToLower().Contains(search) && x.SecondName.Length == search.Length ||
                        x.Name.ToLower().Contains(search) && x.Name.Length == search.Length ||
                        x.SurName.ToLower().Contains(search) && x.SurName.Length == search.Length)
                    .ToList();

                return PeopleMapper.Map(result);
            }
        }
        public PeopleViewModel Update(PeopleEntity entity)
        {
            entity.SecondName = entity.SecondName.Trim();
            entity.Name = entity.Name.Trim();
            entity.SurName = entity.SurName.Trim();
            entity.DateOfBirth = entity.DateOfBirth.Trim();
            entity.Sex = entity.Sex.Trim();
            entity.UserLogin = entity.UserLogin.Trim();

            if (string.IsNullOrEmpty(entity.SecondName) || string.IsNullOrEmpty(entity.Name) || string.IsNullOrEmpty(entity.SurName) || string.IsNullOrEmpty(entity.DateOfBirth) || string.IsNullOrEmpty(entity.Sex) || string.IsNullOrEmpty(entity.UserLogin))
            {
                throw new Exception("Не все поля засеяны, милорд!");
            }
            using (var context = new Context())
            {
                var existingClient = context.Peoples.Find(entity.ID);

                if (existingClient != null)
                {
                    context.Entry(existingClient).CurrentValues.SetValues(entity);
                    context.SaveChanges();
                }
            }
            return PeopleMapper.Map(entity);
        }
        #endregion
    }
}
